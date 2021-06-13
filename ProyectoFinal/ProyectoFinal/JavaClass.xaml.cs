using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
        public string Tipo { get; set; }
        public string Nombre { get; set; }
        //private string AllDataType =[""];

        public Atributo(string datatype, string dataName)
        {
            Tipo = datatype;
            Nombre = dataName;
        }
        public override string ToString()
        {
            return Nombre + " " + Tipo;
        }
    }//Fin class Atributo

    //Ventana y acciones relacionadas con la misma
    public sealed partial class JavaClass : Page
    {
        //Lista que toma los datos de la lista Global, la cual enlazamos con ItemSource="{x:Bind (Lista)}" al datagrid
        public List<Atributo> atributos = App.AtributosList;

        public JavaClass()
        {
            this.InitializeComponent();


            AtributosDataGrid.ItemsSource = App.AtributosList;

        }
        private async void mensaje(String mensaje)
        {
            //muestra un mensaje de usuario o contraseña erroneos
            var msg = new MessageDialog(mensaje);
            await msg.ShowAsync();
        }//Fin de mensaje
        private void volver_Click(object sender, RoutedEventArgs e)
        {
            atributos.Clear();
            App.datosClass = String.Empty;
            switch (App.user.whatType())
            {
                case "Administrador":
                    this.Frame.Navigate(typeof(PaginaInicioAdmin));
                    break;
                case "Usuario":
                    this.Frame.Navigate(typeof(PaginaInicioUser));
                    break;
            }
        }//Fin de volver

        private void load(object sender, Microsoft.Toolkit.Uwp.UI.Controls.DataGridRowEventArgs e)
        {
            AtributosDataGrid.ItemsSource = App.AtributosList;
        }//Fin de load
        private void generarBtn_Click(object sender, RoutedEventArgs e)
        {
            
            if (NombreTextBox.Text != String.Empty)
            {
                string nombre = NombreTextBox.Text;
                List<Atributo> listAtributos = (List<Atributo>)AtributosDataGrid.ItemsSource;
                GenerarJavaClass javaClass = new GenerarJavaClass(nombre, listAtributos);
                App.archivos.classJava = javaClass.generarClass();

                this.Frame.Navigate(typeof(MostrarCodigo), "java");
                //inserta el proyecto en bbdd
                DateTime thisDay = DateTime.Today;
                string fecha = thisDay.ToString("d");
                Proyecto newProyect = new Proyecto(App.user.IdUser,"Java",fecha);
                bool realizado = App.bbdd.insertNewProyecto(newProyect);
                if (realizado)
                {
                    Console.WriteLine("se ha añadido un proyecto con exito");
                }
                else
                {
                    Console.WriteLine("se ha producido un error al añadir el proyecto a la bbdd");
                }

                atributos.Clear();
                App.datosClass = String.Empty;

            }
            else
            {
                mensaje("El campo Nombre esta vacio");
            }


        }//Fin de generarBtn_Click

        private void AñadirAtributoBtn_Click(object sender, RoutedEventArgs e)
        {
            App.datosClass = NombreTextBox.Text;
            this.Frame.Navigate(typeof(JavaClassAttributes));
        }//Fin de AñadirAtributoBtn_Click

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            NombreTextBox.Text= App.datosClass;
            if (e.Parameter != null)
            {
                string value = (string)e.Parameter;
                string[] word = new string[2];
                word = value.Split('.');
                paramsBuilder(word);
            }
        }//Fin de OnNavigatedTo

        private void paramsBuilder(string[] word)
        {
            
            if (word.Length < 2)
            {

            }
            else
            {


                string dataType = word[0];
                string dataName = word[1];
                addAtributo(dataType, dataName);
            }
        }//Fin de paramsBuilder
        public void addAtributo(string dataType, string dataName)
        {
            this.atributos.Add(new Atributo(dataType, dataName));
        }//Fin de addAtributo
    }//fin class JavaClass
}
