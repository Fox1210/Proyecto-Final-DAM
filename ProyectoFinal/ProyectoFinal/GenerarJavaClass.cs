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

        public GenerarJavaClass(string path, string nombre, List<Atributo> listAtriburos)
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
                result += item.Datatype + " " + item.DataName + ";\n";
            }
            return result;
        }
        public string generarEntradaConstructor()
        {
            string result = String.Empty;
            if (listAtriburos.Any())
            {
                result += listAtriburos[0].Datatype + " " + listAtriburos[0].DataName;
                for (int i = 1; i < listAtriburos.Capacity; i++)
                {
                    result += ", "+listAtriburos[i].Datatype + " " + listAtriburos[i].DataName;
                }

            }
            return result;
        }
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
        }
        public string generarConstructores()
        {
            string result = $"{nombre} ({this.generarEntradaConstructor()}){{\n";

            return result;
        }
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
