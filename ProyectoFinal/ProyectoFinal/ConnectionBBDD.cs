using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ProyectoFinal
{
    class ConnectionBBDD
    {
        public const string connectionString = "server=127.0.0.1; Port=3306;Database=proyecto_final_dam;Uid=pablo;password=pablo";

        public ConnectionBBDD()
        {

        }

        public List<Usuario> allUser()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                //Codigo para un Select 
                connection.Open();//abre la conexion con la bbdd
                MySqlCommand command = new MySqlCommand();
                command.CommandText = "select * from usuarios";
                command.Connection = connection;

                List<Usuario> userList = new List<Usuario>();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Usuario user = new Usuario();
                        user.IdUser = Convert.ToInt32(reader["IdUser"]);
                        user.Name = reader["name"].ToString();
                        user.Password = reader["Password"].ToString();
                        user.Type = Convert.ToInt32(reader["Type"]);
                        user.Boss = Convert.ToInt32(reader["Supervisor"]);
                        userList.Add(user);
                    }
                }
                return userList;

            }

        }// Fin allUser
        public Usuario logingUser(string username, string password)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                //Codigo para un Select 
                connection.Open();//abre la conexion con la bbdd
                MySqlCommand command = new MySqlCommand();
                command.CommandText = $"SELECT * FROM `usuarios`as us WHERE us.Nombre='{username}' AND us.Password='{password}'";
                command.Connection = connection;

                Usuario user = new Usuario();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        user.IdUser = Convert.ToInt32(reader["IdUser"]);
                        user.Name = reader["Nombre"].ToString();
                        user.Password = reader["Password"].ToString();
                        user.Type = Convert.ToInt32(reader["Type"]);
                        user.Boss = Convert.ToInt32(reader["Supervisor"]);
                    }
                }
                return user;

            }

        }//Fin logingUser
        public int updatePassword(Usuario usuario, string password)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                //Codigo para un Select 
                connection.Open();//abre la conexion con la bbdd
                MySqlCommand command = new MySqlCommand();
                command.CommandText = $"UPDATE `usuarios` SET `Password`='{password}' WHERE `IdUser`={usuario.IdUser};";
                command.Connection = connection;

                int reader = command.ExecuteNonQuery();

                return reader;

            }
        }//Fin updatePassword

        public bool insertNewUser(Usuario usuario)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                //Codigo para un Select 
                connection.Open();//abre la conexion con la bbdd
                MySqlCommand command = new MySqlCommand();
                command.CommandText = $"INSERT INTO `usuarios`(`IdUser`, `Nombre`, `Password`, `Type`, `Supervisor`) VALUES (null,'{usuario.Name}','{usuario.Password}','{usuario.Type}','{usuario.Boss}');";
                command.Connection = connection;
                try
                {
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }


            }
        }//Fin insertNewUser
        public bool insertNewProyecto(Proyecto proyecto)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                //Codigo para un Select 
                connection.Open();//abre la conexion con la bbdd
                MySqlCommand command = new MySqlCommand();
                command.CommandText = $"INSERT INTO `proyecto`(`IdProyecto`, `user`, `lenguaje`, `fecha`) VALUES (null,'{proyecto.User}','{proyecto.lenguaje}','{proyecto.fecha}');";
                command.Connection = connection;
                try
                {
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }


            }
        }//Fin insertNewUser


    }//Fin clase
}
