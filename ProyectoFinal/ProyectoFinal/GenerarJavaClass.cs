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
            result = $"\tpublic static void main(String[] args) {{\n\t\tSystem.out.println(\"Hola Mundo\");\n\t}}\n";
            return result;
        }//Fin de generarMain
        private string generarAtributos()
        {
            string result = "\n";
            foreach (Atributo item in listAtriburos)
            {
                result += "\t"+item.Tipo + " " + item.Nombre + ";\n";
            }
            return result + "\n";
        }//Fin de generarAtributos
        private string generarEntradaConstructor()
        {
            string result = String.Empty;
            if (listAtriburos.Any())
            {
                if (listAtriburos.Count == 1)
                {
                    result += listAtriburos[0].Tipo + " este " + listAtriburos[0].Nombre;
                }
                else
                {
                    result += listAtriburos[0].Tipo + " " + listAtriburos[0].Nombre;
                    for (int i = 1; i < listAtriburos.Count; i++)
                    {
                        result += ", " + listAtriburos[i].Tipo + " " + listAtriburos[i].Nombre;
                    }
                }
            }
            return result;
        }//Fin de generarEntradaConstructor
        private string generarContenidoConstructor()
        {
            string result = "\n";
            if (listAtriburos.Any())
            {
                foreach (Atributo item in listAtriburos)
                {
                    result += $"\t\tthis.{item.Nombre} = {item.Nombre};\n";
                }


            }
            return result;
        }//Fin de generarContenidoConstructor
        private string generarConstructores()
        {
            string result = $"\t{nombre} ({this.generarEntradaConstructor()}){{\n{this.generarContenidoConstructor()}\n\t}}\n";

            return result;
        }//Fin de generarConstructores
        private string generarGetterySetters()
        {
            string result = "\n";

            foreach (Atributo atributo in listAtriburos)
            {
                string get = $"\tpublic {atributo.Tipo} get{atributo.Nombre}(){{\n\t\treturn {atributo.Nombre};\n\t}}\n";
                string set = $"\tpublic {atributo.Tipo} set{atributo.Nombre}({atributo.Tipo} {atributo.Nombre}){{\n\t\tthis.{atributo.Nombre} = {atributo.Nombre};\n\t}}\n";
                result += get + set+"\n";
            }

            return result;
        }//Fin de generarGetterySetters
    }
}
