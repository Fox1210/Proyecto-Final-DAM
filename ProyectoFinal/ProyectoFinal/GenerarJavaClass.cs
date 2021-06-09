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
        public string nombre { get; set; }
        public List<Atributo> listAtriburos { get; set; }

        //CONSTRUCTORES
        public GenerarJavaClass(string nombre, List<Atributo> listAtriburos)
        {
            Inicio = $"public class {nombre} {{\n";
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
        private string generarAtributos()
        {
            string result = "\n";
            foreach (Atributo item in listAtriburos)
            {
                result += item.Tipo + " " + item.Nombre + ";\n";
            }
            return result;
        }//Fin de generarAtributos
        private string generarEntradaConstructor()
        {
            string result = String.Empty;
            if (listAtriburos.Any())
            {
                result += listAtriburos[0].Tipo + " " + listAtriburos[0].Nombre;
                for (int i = 1; i < listAtriburos.Capacity; i++)
                {
                    result += ", " + listAtriburos[i].Tipo + " " + listAtriburos[i].Nombre;
                }

            }
            return result;
        }//Fin de generarEntradaConstructor
        private string generarContenidoConstructor()
        {
            string result = String.Empty;
            if (listAtriburos.Any())
            {
                foreach (Atributo item in listAtriburos)
                {
                    result += $"\tthis.{item.Nombre} = {item.Nombre};\n";
                }


            }
            return result;
        }//Fin de generarContenidoConstructor
        private string generarConstructores()
        {
            string result = $"{nombre} ({this.generarEntradaConstructor()}){{\n";

            return result;
        }//Fin de generarConstructores
        private string generarGetterySetters()
        {
            string result = "\n";

            foreach (Atributo atributo in listAtriburos)
            {
                string get = $"public {atributo.Tipo} get{atributo.Nombre}(){{\n\treturn {atributo.Nombre};\n}}\n";
                string set = $"public {atributo.Tipo} set{atributo.Nombre}({atributo.Tipo} {atributo.Nombre}){{\n\tthis.{atributo.Nombre} = {atributo.Nombre};\n}}\n";
                result += get + set;
            }

            return result;
        }//Fin de generarGetterySetters
    }
}
