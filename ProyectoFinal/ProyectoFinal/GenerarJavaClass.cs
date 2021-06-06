using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal
{
    class GenerarJavaClass
    {
        public string Inicio { get; set; }
        public string Fin { get; set; }
        public string path { get; set; }
        public string nombre { get; set; }
        public List<Atributo> listAtriburos { get; set; }

        public GenerarJavaClass( string path, string nombre, List<Atributo> listAtriburos)
        {
            Inicio = $"public class {nombre} {{\n";
            this.path = path;
            this.nombre = nombre;
            this.listAtriburos = listAtriburos;
            Fin = $"}}";
        }
        public string generarAtributos()
        {
            string result = "\n";
            foreach (Atributo item in listAtriburos)
            {

            }
            return result;
        }
        public string generarConstructores()
        {
            string result="\n";

            return result;
        }
        public string generarGetterySetters() {
            string result="\n";

            foreach (Atributo atributo in listAtriburos)
            {
                string get = $"public {atributo.Datatype} get{atributo.DataName}(){{\n\treturn {atributo.DataName};\n}}\n";
                string set = $"public {atributo.Datatype} set{atributo.DataName}({atributo.Datatype} {atributo.DataName}){{\n\tthis.{atributo.DataName} = {atributo.DataName};\n}}\n";
                result += get + set;
            }
           
            return result;
        }//Fin de generarGetterySetters
    }
}
