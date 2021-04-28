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
        public string Email { get; set; }
        public int Type { get; set; }

        public Usuario(int idUser, string name, string password, string email, int type)
        {
            IdUser = idUser;
            Name = name;
            Password = password;
            Email = email;
            Type = type;
        }

    }
}
