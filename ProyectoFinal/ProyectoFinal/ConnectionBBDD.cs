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
                command.CommandText = "select * from usuario";
                command.Connection = connection;

                List<Usuario> userList = new List<Usuario>();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read()) 
                    {
                        Usuario user = new Usuario();
                        user.IdUser=Convert.ToInt32(reader["IdUser"]);
                        user.Name = reader["name"].ToString();
                        user.Password = reader["Password"].ToString();
                        user.Type= Convert.ToInt32(reader["Type"]);
                        userList.Add(user);
                    }
                }
                return userList;

            }
               
        }
        public Usuario logingUser(string username, string password)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                //Codigo para un Select 
                connection.Open();//abre la conexion con la bbdd
                MySqlCommand command = new MySqlCommand();
                command.CommandText = $"SELECT * FROM `usuario`as us WHERE us.Name='{username}' AND us.Password='{password}'";
                command.Connection = connection;

                Usuario user = new Usuario();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        user.IdUser = Convert.ToInt32(reader["IdUser"]);
                        user.Name = reader["name"].ToString();
                        user.Password = reader["Password"].ToString();
                        user.Type = Convert.ToInt32(reader["Type"]);

                    }
                }
                return user;

            }

        }
    }
}
