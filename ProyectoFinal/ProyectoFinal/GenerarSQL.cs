using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal
{
    class GenerarSQL
    {
        public string bbDd { get; set; }
        public string tabla { get; set; }
        public List<Campo> listAtributos { get; set; }

        public GenerarSQL(string bbDD,string tabla, List<Campo> listAtributos)
        {
            this.bbDd = this.bbDd;
            this.tabla = this.tabla;
            this.listAtributos = listAtributos;
        }

        public string generarClass()
        {
            return "CREATE TABLE `proyecto_final_dam`. ( `nolA` VARCHAR(60) NOT NULL ) ENGINE = InnoDB;";
        }
    }
}
