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
            return Nombre + " " + Tipo + " " + Tamaño;
        }
    }//Fin class Atributo
    public sealed partial class SqlCreate : Page
    {
        //Lista que toma los datos de la lista Global, la cual enlazamos con ItemSource="{x:Bind (Lista)}" al datagrid
        public List<Campo> campos = App.CampoList;
        public bool isEmpty = true;

        public SqlCreate()
        {
            this.InitializeComponent();
            CampoDataGrid.ItemsSource = App.CampoList;
            if (!isEmpty)
            {

            }
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
            App.datosTabla[0] = String.Empty;
            App.datosTabla[1] = String.Empty;
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
            if (chek())
            {

                string bbDD = "proyecto_final_dam";//NombreBBDDTextBox.Text;
                string tabla = NombreTablaTextBox.Text;
                List<Campo> listAtributos = (List<Campo>)CampoDataGrid.ItemsSource;
                GenerarSQL sqlClass = new GenerarSQL(bbDD, tabla, listAtributos);
                App.archivos.sqlCreate = sqlClass.generarCreate();

                this.Frame.Navigate(typeof(MostrarCodigo), "sql");

                campos.Clear();
                App.datosTabla[0] = String.Empty; 
                App.datosTabla[1] = String.Empty;

            }

        }//Fin de generarBtn_Click

        private bool chek()
        {
            bool result = false;
            if (NombreBBDDTextBox.Text != String.Empty)
            {
                if (NombreTablaTextBox.Text != String.Empty)
                {
                    result = true;
                }
                else
                {
                    mensaje("El campo Nombre de la Tabla no esta relleno");
                }
            }
            else
            {
                mensaje("El campo Nombre BBDD no esta relleno");
            }
            return result;
        }

        private void AñadirCampoBtn_Click(object sender, RoutedEventArgs e)
        {
            if (relleno())
            {
                App.datosTabla[0] = NombreBBDDTextBox.Text;
                App.datosTabla[1] = NombreTablaTextBox.Text;
            }
            this.Frame.Navigate(typeof(SqlCreateCampo));
        }//Fin de AñadirCampoBtn_Click

        private bool relleno()
        {
            bool result = false;
            if (NombreBBDDTextBox.Text != String.Empty)
            {
                if (NombreTablaTextBox.Text != String.Empty)
                {
                    result = true;
                }
            }
            return result;
        }

        private void load(object sender, Microsoft.Toolkit.Uwp.UI.Controls.DataGridRowEventArgs e)
        {
            CampoDataGrid.ItemsSource = App.CampoList;
        }//Fin de load

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
                NombreBBDDTextBox.Text = App.datosTabla[0];
                NombreTablaTextBox.Text = App.datosTabla[1];
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
            if (word.Length < 3) { }
            else
            {
                string dataType = word[0];
                string dataName = word[1];
                string dataSize = word[2];
                addCampo(dataType, dataName, dataSize);
            }
        }//Fin de paramsBuilder

        public void addCampo(string dataType, string dataName, string dataSize)
        {
            this.campos.Add(new Campo(dataType, dataName, dataSize));
        }//Fin de addCampo


    }
}
