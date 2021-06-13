using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal
{
    class Proyecto
    {
        public int IdProyecto { get; set; }
        public int User { get; set; }
        public string lenguaje { get; set; }
        public string fecha { get; set; }

        public Proyecto(int idProyecto, int user, string lenguaje, string fecha)
        {
            IdProyecto = idProyecto;
            User = user;
            this.lenguaje = lenguaje;
            this.fecha = fecha;
        }
        public Proyecto(int user, string lenguaje, string fecha)
        {
            User = user;
            this.lenguaje = lenguaje;
            this.fecha = fecha;
        }
        public Proyecto()
        {
        }

    }
}
