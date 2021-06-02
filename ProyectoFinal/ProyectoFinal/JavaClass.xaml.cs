using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace ProyectoFinal
{
    public class Atributo
    {
        public string Datatype { get; set; }
        public string DataName { get; set; }
        //private string AllDataType =[""];

        public Atributo(string datatype, string dataName)
        {
            Datatype = datatype;
            DataName = dataName;
        }
    }
    //Ventana y acciones relacionadas con la misma
    public sealed partial class JavaClass : Page
    {
        public List<Atributo> AtributosList { get; set; }
        public JavaClass()
        {
            this.InitializeComponent();
            AtributosList = new List<Atributo>();

            AtributosList.Add(new Atributo("String", "Nombre"));
            AtributosList.Add(new Atributo("String", "Nombre"));
            AtributosList.Add(new Atributo("String", "Nombre"));
            AtributosList.Add(new Atributo("String", "Nombre"));
        }
        private void volver_Click(object sender, RoutedEventArgs e)
        {
            switch (App.user.whatType())
            {
                case "Administrador":
                    this.Frame.Navigate(typeof(PaginaInicioAdmin));
                    break;
                case "Usuario":
                    this.Frame.Navigate(typeof(PaginaInicioUser));
                    break;
            }
        }//Fin volver

        private void generarBtn_Click(object sender, RoutedEventArgs e)
        {
            DatosAtributosDataGrid
            //prueba.Text;
        }
    }//fin class JavaClass
}
