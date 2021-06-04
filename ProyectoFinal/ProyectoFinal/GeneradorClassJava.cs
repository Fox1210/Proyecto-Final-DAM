using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal
{
    class GeneradorClassJava
    {
        public string ruta { get; set; }
        public string nombre { get; set; }
        public List<Atributo> MyProperty { get; set; }

        public GeneradorClassJava(string ruta, string nombre, List<Atributo> myProperty)
        {
            this.ruta = ruta;
            this.nombre = nombre;
            MyProperty = myProperty;
        }
        generar
    }
}
