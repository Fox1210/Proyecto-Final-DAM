using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal
{
    class Usuario
    {
        public int IdUser { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Type { get; set; }

        public Usuario(int idUser, string name, string password, int type)
        {
            IdUser = idUser;
            Name = name;
            Password = password;
            Type = type;
        }

        public Usuario()
        {
        }

        public override string ToString()
        {
            string result = $"Id User: {IdUser}\nName: {Name}\nPassword: {Password}\nTipo de permiso: {Type}";
            return result;
        }
        public bool isEmpty()
        {
            if (IdUser == 0 | Name == String.Empty | Password == String.Empty | Type == 0)
            {
                return true;
            }
            else { return false; }

        }

        public string whatType()
        {
            string result = "";
            switch (Type)
            {
                case 1:
                    result= "Administrador";
                    break;
                case 2:
                    result= "Usuario";
                    break;
            }
            return result;
            
        }
            
    }
}
