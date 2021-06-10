using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal
{
    class GenerarSQL
    {
        public string nombre { get; set; }
        public List<Campo> listAtributos { get; set; }

        public GenerarSQL(string nombre, List<Campo> listAtributos)
        {
            this.nombre = nombre;
            this.listAtributos = listAtributos;
        }

        public string generarClass()
        {
            return "CREATE TABLE `proyecto_final_dam`. ( `nolA` VARCHAR(60) NOT NULL ) ENGINE = InnoDB;";
        }
    }
}
