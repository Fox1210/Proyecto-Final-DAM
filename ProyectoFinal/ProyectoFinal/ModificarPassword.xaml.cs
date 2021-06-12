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
    public sealed partial class ModificarPassword : Page
    {
        private Usuario usuario = App.user;
        private ConnectionBBDD ConnectionBBDD = App.bbdd;
        public ModificarPassword()
        {
            this.InitializeComponent();
        }

        private void volver_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(configuracion));
        }

        private void actualizar_Click(object sender, RoutedEventArgs e)
        {
            //Validamos que las password actual es correcta
            if (usuario.Password.Equals(OldPasswordBox.Password))
            {
                if (NewPasswordBox.Password != String.Empty && New2PasswordBox.Password != String.Empty)
                { 
                    //Valida que se la nueva password
                    if (NewPasswordBox.Password == New2PasswordBox.Password)
                    {

                        int result = ConnectionBBDD.updatePassword(usuario, NewPasswordBox.Password);
                        if (result != 0)
                        {
                            //muestra un mensaje de usuario o contraseña erroneos
                            mensaje("La contraseña ha sido modificada");

                            //modificamos el usuario en eso Actual
                            App.user.Password = NewPasswordBox.Password;

                        }
                        else
                        {
                            mensaje("Se produjo un error al modificar la Base de Datos");
                        }
                    }
                    else
                    {
                        mensaje("Error en la nueva contraseña o en la confirmación");
                    }
                }
                else
                {
                    mensaje("La nueva contraseña o la confirmacion no se han rellenado");
                }


            }
            else
            {
                mensaje("La contraseña actual es erronea");
            }

        }
        private async void mensaje(String mensaje)
        {
            //muestra un mensaje de usuario o contraseña erroneos
            var msg = new MessageDialog(mensaje);
            await msg.ShowAsync();
        }
    }
}
