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
        public List<Campo> listCampos { get; set; }

        public GenerarSQL(string bbDD, string tabla, List<Campo> listAtributos)
        {
            this.bbDd = this.bbDd;
            this.tabla = this.tabla;
            this.listCampos = listAtributos;
        }

        public string generarClass()
        {
            string resul;
            resul = $"CREATE TABLE '{this.bbDd}'. '{this.tabla}'( {this.generaListaCampos()} );";
            return resul;
        }
        private string generaListaCampos()
        {
            string result = String.Empty;
            if (this.listCampos[0].Tamaño.Equals(String.Empty)) 
            { 
                result += $" '{this.listCampos[0].Nombre}' {this.listCampos[0].Tipo}  NOT NULL";
            }
            else
            {
                result += $" '{this.listCampos[0].Nombre}' {this.listCampos[0].Tipo}({this.listCampos[0].Tamaño})  NOT NULL";
            }
           
            for (int i = 1; i < listCampos.Count; i++)
            {
                if (this.listCampos[i].Tamaño.Equals(String.Empty))
                {
                    result += $", '{this.listCampos[i].Nombre}' {this.listCampos[i].Tipo}  NOT NULL";
                }
                else
                {
                    result += $", '{this.listCampos[i].Nombre}' {this.listCampos[i].Tipo}({this.listCampos[i].Tamaño})  NOT NULL";
                }
               
            }


            return result;
        }
    }
}
