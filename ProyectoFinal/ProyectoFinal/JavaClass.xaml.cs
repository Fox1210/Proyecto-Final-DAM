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
    public class Atributo
    {
        public string Datatype { get; set; }
        public string DataName { get; set; }
        //private string AllDataType =[""];

        public Atributo(string datatype, string dataName)
        {
            Datatype = datatype;
            DataName = dataName;
        }
        public override string ToString()
        {
            return DataName + " " + Datatype;
        }
    }//Fin class Atributo

    //Ventana y acciones relacionadas con la misma
    public sealed partial class JavaClass : Page
    {
        //Lista que toma los datos de la lista Global, la cual enlazamos con ItemSource="{x:Bind (Lista)}" al datagrid
        public List<Atributo> atributos = App.AtributosList;

        public JavaClass()
        {
            this.InitializeComponent();

            App.AtributosList.Sort();
            AtributosDataGrid.ItemsSource = App.AtributosList;

        }
        private void volver_Click(object sender, RoutedEventArgs e)
        {
            switch (App.user.whatType())
            {
                case "Administrador":
                    this.Frame.Navigate(typeof(PaginaInicioAdmin));
                    break;
                case "Usuario":
                    this.Frame.Navigate(typeof(PaginaInicioUser));
                    break;
            }
        }//Fin volver

        //Metodo extra para el evento de carga de filas de Datagrid, está puesto para evitar algunos
        //bugs que se causan a veces con el movimiento de varias puntuaciones.
        private void load(object sender, Microsoft.Toolkit.Uwp.UI.Controls.DataGridRowEventArgs e)
        {
            App.AtributosList.Sort();
            AtributosDataGrid.ItemsSource = App.AtributosList;
        }

       /* private void generarBtn_Click(object sender, RoutedEventArgs e)
        {

            //Atributo atributo_selecionado = (Atributo)DatosAtributosDataGrid.SelectedItem;
            //prueba.Text = atributo_selecionado.ToString() + " " + DatosAtributosDataGrid.SelectedIndex;
            App.AtributosList.Add(new Atributo("int", "Nombre"));
            this.InitializeComponent();

            //dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
           //AtributosList.RemoveAt(DatosAtributosDataGrid.SelectedIndex);
        }*///Fin de Pruebas
    }//fin class JavaClass
}
