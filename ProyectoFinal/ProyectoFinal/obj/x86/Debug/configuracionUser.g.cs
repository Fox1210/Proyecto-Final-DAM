﻿#pragma checksum "C:\dev\Proyecto Final DAM\Proyecto-Final-DAM\ProyectoFinal\ProyectoFinal\configuracionUser.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "0DDB925E0C47DD8666ACD6F13C81EF65"
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
    partial class configuracionUser : 
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
            case 2: // configuracionUser.xaml line 12
                {
                    this.volver = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.volver).Click += this.volver_Click;
                }
                break;
            case 3: // configuracionUser.xaml line 13
                {
                    this.actualizar = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.actualizar).Click += this.actualizar_Click;
                }
                break;
            case 4: // configuracionUser.xaml line 14
                {
                    this.textBlockUserName = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 5: // configuracionUser.xaml line 15
                {
                    this.UserNameTextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 6: // configuracionUser.xaml line 16
                {
                    this.textBlockUserPassword = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 7: // configuracionUser.xaml line 18
                {
                    this.UserPassword = (global::Windows.UI.Xaml.Controls.PasswordBox)(target);
                }
                break;
            case 8: // configuracionUser.xaml line 19
                {
                    this.UserPassword2 = (global::Windows.UI.Xaml.Controls.PasswordBox)(target);
                }
                break;
            case 9: // configuracionUser.xaml line 21
                {
                    this.textBlockUserType = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 10: // configuracionUser.xaml line 22
                {
                    this.UserTypeTextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
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

