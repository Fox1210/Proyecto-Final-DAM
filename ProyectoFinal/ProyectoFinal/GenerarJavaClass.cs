using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal
{
    class GenerarJavaClass
    {
        //PROPIEDADES
        public string Inicio { get; set; }
        public string Fin { get; set; }
        public string path { get; set; }
        public string nombre { get; set; }
        public List<Atributo> listAtriburos { get; set; }

        //CONSTRUCTORES
        public GenerarJavaClass(string path, string nombre, List<Atributo> listAtriburos)
        {
            Inicio = $"public class {nombre} {{\n";
            this.path = path;
            this.nombre = nombre;
            this.listAtriburos = listAtriburos;
            Fin = $"}}";
        }

        //METODES DE GENRACIÓN DE ARCHIVOS
        public string generarClass()
        {
            string result = String.Empty;
            result += Inicio;
            if (nombre.Equals("Main"))
            {
                result += generarMain();
            }
            else
            {
                result += generarAtributos();
                result += generarConstructores();
                result += generarGetterySetters();
            }

            result += Fin;
            return result;
        }//Fin de generarClass
        private string generarMain()
        {
            string result = String.Empty;
            result = $"public static void main(String[] args) {{\n\tSystem.out.println(\"Hola Mundo\");\n}}\n";
            return result;
        }//Fin de generarMain
        public string generarAtributos()
        {
            string result = "\n";
            foreach (Atributo item in listAtriburos)
            {
                result += item.Datatype + " " + item.DataName + ";\n";
            }
            return result;
        }//Fin de generarAtributos
        public string generarEntradaConstructor()
        {
            string result = String.Empty;
            if (listAtriburos.Any())
            {
                result += listAtriburos[0].Datatype + " " + listAtriburos[0].DataName;
                for (int i = 1; i < listAtriburos.Capacity; i++)
                {
                    result += ", " + listAtriburos[i].Datatype + " " + listAtriburos[i].DataName;
                }

            }
            return result;
        }//Fin de generarEntradaConstructor
        public string generarContenidoConstructor()
        {
            string result = String.Empty;
            if (listAtriburos.Any())
            {
                foreach (Atributo item in listAtriburos)
                {
                    result += $"\tthis.{item.DataName} = {item.DataName};\n";
                }


            }
            return result;
        }//Fin de generarContenidoConstructor
        public string generarConstructores()
        {
            string result = $"{nombre} ({this.generarEntradaConstructor()}){{\n";

            return result;
        }//Fin de generarConstructores
        public string generarGetterySetters()
        {
            string result = "\n";

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
