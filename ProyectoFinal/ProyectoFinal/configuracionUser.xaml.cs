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
    public sealed partial class configuracionUser : Page
    {
        private Usuario usuario = App.user;
        private ConnectionBBDD ConnectionBBDD = App.bbdd;
        public configuracionUser()
        {
            this.InitializeComponent();
            UserNameTextBlock.Text = usuario.Name;

            UserPassword.Password = usuario.Password;
            UserPassword.PasswordRevealMode = PasswordRevealMode.Peek;

            UserPassword2.Password = usuario.Password;
            UserPassword2.PasswordRevealMode = PasswordRevealMode.Peek;

            UserTypeTextBlock.Text = usuario.whatType();

        }

        private void volver_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PaginaInicioUser));
        }

        private async void actualizar_Click(object sender, RoutedEventArgs e)
        {
            if (UserPassword.Password == UserPassword2.Password)
            {
                int result = ConnectionBBDD.updatePassword(usuario, UserPassword.Password);
                if (result != 0)
                {
                    //muestra un mensaje de usuario o contraseña erroneos
                    var msg = new MessageDialog("La contraseña ha sido modificada");
                    await msg.ShowAsync();
                }
            }
            else
            {
                //muestra un mensaje de usuario o contraseña erroneos
                var msg = new MessageDialog("No se pude actualizar los campos contrasña no son iguales");
                await msg.ShowAsync();
            }
        }
    }
}
