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
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MostrarCodigo : Page
    {
        public string codigo;
        public string lenguaje;

        public MostrarCodigo()
        {
            this.InitializeComponent();

        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {
                lenguaje = (string)e.Parameter;
                
                codigo = extraerCodigo();
                CodigoTextBlock.Text = codigo;

            }
        }//Fin de OnNavigatedTo

        private string extraerCodigo()
        {
            string result=String.Empty;
            switch (lenguaje)
            {
                case "sql":
                    result = App.archivos.sqlCreate;
                    break;
                case "java":
                    result = App.archivos.classJava;
                    break;
                default:
                    result = "Se produjo algun problema al generar el código";
                    break;
            }
            return result;
        }

        private void volver_Click(object sender, RoutedEventArgs e)
        {
            switch (lenguaje)
            {
                case "sql":
                    this.Frame.Navigate(typeof(SqlCreate));
                    break;
                case "java":
                    this.Frame.Navigate(typeof(JavaClass));
                    break;
                default:
                    Menu();
                    break;
            }
        }

        private void Menu()
        {
            int tipo = App.user.Type;
            switch (tipo)
            {
                case 1:
                    this.Frame.Navigate(typeof(PaginaInicioAdmin));
                    break;
                case 2:
                    this.Frame.Navigate(typeof(PaginaInicioUser));
                    break;
                default:
                    this.Frame.Navigate(typeof(MainPage));
                    break;
            }
        }
    }
}
