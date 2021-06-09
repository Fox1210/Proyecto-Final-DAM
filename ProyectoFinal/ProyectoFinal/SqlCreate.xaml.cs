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
    public class Campo
    {
        public string Tipo { get; set; }
        public string Nombre { get; set; }
        public string Tamaño { get; set; }
        //private string AllDataType =[""];

        public Campo(string datatype, string dataName, string dataSize)
        {
            Tipo = datatype;
            Nombre = dataName;
            Tamaño = dataSize;
        }
        public override string ToString()
        {
            return Nombre + " " + Tipo+" "+Tamaño;
        }
    }//Fin class Atributo
    public sealed partial class SqlCreate : Page
    {
        //Lista que toma los datos de la lista Global, la cual enlazamos con ItemSource="{x:Bind (Lista)}" al datagrid
        public List<Campo> campos = App.CampoList;

        public SqlCreate()
        {
            this.InitializeComponent();
            AtributosDataGrid.ItemsSource = App.CampoList;
        }

        private async void mensaje(String mensaje)
        {
            //muestra un mensaje de usuario o contraseña erroneos
            var msg = new MessageDialog(mensaje);
            await msg.ShowAsync();
        }//Fin de mensaje
        private void volver_Click(object sender, RoutedEventArgs e)
        {
            campos.Clear();
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
        private void generarBtn_Click(object sender, RoutedEventArgs e)
        {
            //string ruta= RutaTextBox.Text;
            //string nombre = NombreTextBox.Text;
            //List<Atributo> listAtributos = (List<Atributo>)AtributosDataGrid.ItemsSource;
            //GenerarJavaClass javaClass = new GenerarJavaClass(nombre, listAtributos);
            //string classJava = javaClass.generarClass();


            // Create the file, or overwrite if the file exists.
            TextWriter textWriter = new StreamWriter("C:\\dev\\test.txt");//TODO sustituir la ruta de prueba por la ruta donde se debe genrar el Archivo
            // Add some information to the file.
            textWriter.WriteLine("hola");//TODO sustituir el texto de prueba por la classJava
            textWriter.Close();

        }//Fin de generarBtn_Click
        private void AñadirCampoBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SqlCreateCampo));
        }//Fin de AñadirCampoBtn_Click

        private void load(object sender, Microsoft.Toolkit.Uwp.UI.Controls.DataGridRowEventArgs e)
        {
            AtributosDataGrid.ItemsSource = App.AtributosList;
        }//Fin de load

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {
                string value = (string)e.Parameter;
                string[] word = new string[3];
                word = value.Split('.');
                paramsBuilder(word);
            }
        }//Fin de OnNavigatedTo

        private void paramsBuilder(string[] word)
        {
            if (word.Length < 3)
            {

            }
            else
            {
                string dataType = word[0];
                string dataName = word[1];
                string dataSize = word[2];
                addTeamWithParams(dataType, dataName,dataSize);
            }
        }//Fin de paramsBuilder
        
        public void addTeamWithParams(string dataType, string dataName, string dataSize)
        {
            this.campos.Add(new Campo(dataType, dataName,dataSize));
        }//Fin de addTeamWithParams
    }
}
