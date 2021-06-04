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
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class JavaClassAttributes : Page
    {
        public JavaClassAttributes()
        {
            this.InitializeComponent();
            TipoDatoComboBox.Items.Add("String");
            TipoDatoComboBox.Items.Add("Int");
            TipoDatoComboBox.Items.Add("Double");


        }
        private async void mensaje(String mensaje)
        {
            //muestra un mensaje de usuario o contraseña erroneos
            var msg = new MessageDialog(mensaje);
            await msg.ShowAsync();
        }//Fin mensaje

        private void volver_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(JavaClass));
        }

        private void añadir_Click(object sender, RoutedEventArgs e)
        {
            bool isCheck = comprobarElementos();
            if (isCheck)
            {
                string atributo = extraeAtributo();
                this.Frame.Navigate(typeof(JavaClass),atributo);
            }
        }

        private string extraeAtributo()
        {
            string tipo = TipoDatoComboBox.Items[TipoDatoComboBox.SelectedIndex].ToString();
            string nombre= NombreTextBox.Text;
            return tipo + "." +nombre;
        }//Fin de extraeAtributo

        private bool comprobarElementos()
        {
            bool isCheck = false;
            if (NombreTextBox.Text != String.Empty)
            {
                if (TipoDatoComboBox.SelectedIndex != -1)
                {
                    isCheck = true;
                }
                else
                {
                    mensaje("El selector Tipo de dato debe estar relleno");
                }
            }
            else
            {
                mensaje("El campo Nombre del atributo debe estar relleno");
            }
            return isCheck;
        }//Fin de comprobarElementos


    }//fin class JavaClassAttributes
}
