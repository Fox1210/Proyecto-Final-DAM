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
        public string Datatype { get; set; }
        public string DataName { get; set; }
        //private string AllDataType =[""];

        public Atributo(string datatype, string dataName)
        {
            Datatype = datatype;
            DataName = dataName;
        }
        public override string ToString()
        {
            return DataName + " " + Datatype;
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
            //string ruta= "c:\\dev\\test.txt";
            
            // Create the file, or overwrite if the file exists.
            using (TextWriter textWriter = new StreamWriter("C:\\Users\\pablo\\OneDrive\\Desktop\\test.txt"))
            {
                // Add some information to the file.
                textWriter.WriteLine("hola");
                textWriter.Close();
            }

        }//Fin de generarBtn_Click

        private void AñadirAtributoBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(JavaClassAttributes));
        }//Fin de AñadirAtributoBtn_Click

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //Si no es null, lo pasamos a una variable, y dividimos el string en 2 segun el formato de llegada, que son
            //2 palabras separadas por un . ejemplo: "String.Nombre", tras eso llama un metodo que hace el resto.
            if (e.Parameter != null)
            {
                string value = (string)e.Parameter;
                string[] word = new string[2];
                word = value.Split('.');
                paramsBuilder(word);
            }
        }//Fin de OnNavigatedTo
        
        //Metodo que se ocupa de añadir el equipo nuevo a la lista, 
        private void paramsBuilder(string[] word)
        {
            //hacemos esto para que no crashee, ya que el metodo OnNavigatedTo se activa tambien al cargar el programa
            //por primera vez, por tanto, e.Parameter seria igual a Null o "", dando lugar a un array de [1], y crasheando
            //Por indexOutOfBound al llegar a teamProvincia = words[1], por eso para evitarlo, nos aseguramos de que no haga nada
            //si no hay al menos 2 items en el Array.
            if (word.Length < 2)
            {

            }
            else
            {

                 
                string dataType = word[0];
                string dataName = word[1];
                addTeamWithParams(dataType, dataName);
            }
        }//Fin de paramsBuilder
        public void addTeamWithParams(string dataType, string dataName)
        {
            this.atributos.Add(new Atributo(dataType, dataName));
        }//Fin de addTeamWithParams
    }//fin class JavaClass
}
