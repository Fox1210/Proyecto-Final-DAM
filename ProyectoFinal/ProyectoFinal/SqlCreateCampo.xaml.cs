using System;
using System.Collections.Generic;
using System.Globalization;
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
    public sealed partial class SqlCreateCampo : Page
    {
        public SqlCreateCampo()
        {
            this.InitializeComponent();
        }
        private async void mensaje(String mensaje)
        {
            //muestra un mensaje de usuario o contraseña erroneos
            var msg = new MessageDialog(mensaje);
            await msg.ShowAsync();
        }//Fin mensaje
        private string extraeAtributo()
        {
            string tipo = TipoDatoComboBox.Items[TipoDatoComboBox.SelectedIndex].ToString();
            string nombre = NombreTextBox.Text;
            TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
            nombre = myTI.ToLower(nombre);//hola mundo
            nombre = myTI.ToTitleCase(nombre);// Hola Mundo
            nombre = nombre.Replace(" ", String.Empty);//HolaMundo
            char[] arrayNombre = nombre.ToCharArray();//H,o,l,a,M,u,n,d,o
            arrayNombre[0] = Char.ToLower(nombre[0]);//h
            nombre = String.Empty;
            foreach (char letra in arrayNombre)
            {
                nombre += letra;
            }
            return tipo + "." + nombre;//String.holaMundo
        }//Fin de extraeAtributo
        private void añadir_Click(object sender, RoutedEventArgs e)
        {
            bool isCheck = comprobarElementos();
            if (isCheck)
            {
                string atributo = extraeAtributo();
                this.Frame.Navigate(typeof(JavaClass), atributo);
            }
        }

        private bool comprobarElementos()
        {
            return true;
        }

        private void volver_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SqlCreate));
        }
    }
}
