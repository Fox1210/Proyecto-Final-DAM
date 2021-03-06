using System;
using System.Collections.Generic;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;



// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace ProyectoFinal
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ConnectionBBDD BASE_DATOS = App.bbdd;


        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void accederLoging(object sender, RoutedEventArgs e)
        {
            if (UserTextBox.Text == String.Empty | UserPasswordBox.Password == String.Empty)
            {
                //muestra mensaje sobre los campos requeridos
                var msg = new MessageDialog("Los campos USUARIO y CONTRASEÑA deben estar rellenos");
                await msg.ShowAsync();
            }
            else
            {

                //consulta a la vase de datos
                Usuario usuario = BASE_DATOS.logingUser(UserTextBox.Text, UserPasswordBox.Password);

                if (usuario.isEmpty())
                {
                    //muestra un mensaje de usuario o contraseña erroneos
                    var msg = new MessageDialog("El usuario o la contraseña son invalidos");
                    await msg.ShowAsync();
                }
                else
                {
                    //resultado.Text = usuario.ToString();
                    App.user = usuario;
                    if (usuario.Type == 1)
                    {
                        this.Frame.Navigate(typeof(PaginaInicioAdmin));
                    }
                    else
                    {
                        this.Frame.Navigate(typeof(PaginaInicioUser));
                    }

                }

            }

        }// Fin accederLoging

    }// Fin class
}
