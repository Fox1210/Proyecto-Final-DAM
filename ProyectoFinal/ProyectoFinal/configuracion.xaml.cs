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
    public sealed partial class configuracion : Page
    {
        private Usuario usuario = App.user;
        private ConnectionBBDD ConnectionBBDD = App.bbdd;
        public configuracion()
        {
            this.InitializeComponent();
            UserNameTextBlock.Text = usuario.Name;

            UserPassword.Text = usuario.Password;

            UserTypeTextBlock.Text = usuario.WhatType();

        }

        private void volver_Click(object sender, RoutedEventArgs e)
        {
            if (usuario.IsUser())
            {
                this.Frame.Navigate(typeof(PaginaInicioUser));
            }
            if(usuario.IsAdmin())
            {
                this.Frame.Navigate(typeof(PaginaInicioAdmin));
            }

        }



        private void modificarPassword_click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ModificarPassword));
        }
    }
}
