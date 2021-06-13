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
    public sealed partial class NuevoUsuario : Page
    {
        public NuevoUsuario()
        {
            this.InitializeComponent();
            NewUserTypeComboBox.Items.Add("Usuario");
            NewUserTypeComboBox.Items.Add("Administrador");

        }

        private void volver_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PaginaInicioAdmin));
        }//Fin volver

        private void guardarNuevoUsuario_click(object sender, RoutedEventArgs e)
        {
            if (NewUserNameTextBlock.Text != String.Empty)
            {
                if (NewUserPasswordBox.Password != String.Empty)
                {
                    if (NewUserTypeComboBox.SelectedIndex != -1)
                    {
                        insertUserInBBDD();
                    }
                    else
                    {
                        mensaje("El campo tipo no esta relleno");
                    }

                }
                else
                {
                    mensaje("El campo contraseña no esta relleno");
                }
            }
            else
            {
                mensaje("El campo nombre no esta relleno");
            }

        }//Fin Guardar Nuevo Usuario

        private void insertUserInBBDD()
        {
            int type = 1;
            string tipo = NewUserTypeComboBox.Items[NewUserTypeComboBox.SelectedIndex].ToString();
            if (tipo.Equals("Usuario"))
            {
                type = 2;
            }
            Usuario newUser = new Usuario(NewUserNameTextBlock.Text, NewUserPasswordBox.Password, type, App.user.IdUser);
            bool realizado = App.bbdd.insertNewUser(newUser);
            if (realizado)
            {
                mensaje("El usuario se creo sin problemas");
                this.Frame.Navigate(typeof(PaginaInicioAdmin));
            }
            else
            {
                mensaje("Error al crear un nuevo usuario");
            }
        }

        private async void mensaje(String mensaje)
        {
            //muestra un mensaje de usuario o contraseña erroneos
            var msg = new MessageDialog(mensaje);
            await msg.ShowAsync();
        }//Fin mensaje

        
    }// Fin class
}
