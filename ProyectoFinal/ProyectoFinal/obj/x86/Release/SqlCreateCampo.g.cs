﻿#pragma checksum "C:\dev\Proyecto Final DAM\Proyecto-Final-DAM\ProyectoFinal\ProyectoFinal\SqlCreateCampo.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "589A752C01BC2CEE618E166CB235AB23"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoFinal
{
    partial class SqlCreateCampo : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // SqlCreateCampo.xaml line 12
                {
                    this.volverBtn = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.volverBtn).Click += this.volver_Click;
                }
                break;
            case 3: // SqlCreateCampo.xaml line 13
                {
                    this.añadirBtn = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.añadirBtn).Click += this.añadir_Click;
                }
                break;
            case 4: // SqlCreateCampo.xaml line 14
                {
                    this.NombreTextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 5: // SqlCreateCampo.xaml line 15
                {
                    this.NombreTextBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 6: // SqlCreateCampo.xaml line 16
                {
                    this.TipoDatoTextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 7: // SqlCreateCampo.xaml line 17
                {
                    this.TipoDatoComboBox = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

