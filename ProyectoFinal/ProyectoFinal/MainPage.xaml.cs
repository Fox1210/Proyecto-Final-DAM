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
        private ConnectionBBDD BASE_DATOS = new ConnectionBBDD();
       

        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void accederLoging(object sender, RoutedEventArgs e)
        {
            if (UserTextBox.Text == String.Empty | UserPasswordBox.Password == String.Empty) 
            {
                // MessageBox.Show("Los campos deben estar rellenos"); //PROBLEMA
                var msg = new MessageDialog("Los campos USUARIO y CONTRASEÑA deben estar rellenos");
                await msg.ShowAsync();
            }
            string lista="resultado: \n";
            //consulta a la vase de datos
            List<Usuario> userList = BASE_DATOS.logingUser(UserTextBox.Text,UserPasswordBox.Password);
            foreach (Usuario user in userList)
            {  
                lista += user.IdUser+" "+user.Name+" "+user.Password+" "+user.Type+"\n";
            }
            resultado.Text = lista;
        }
    }
}
