﻿#pragma checksum "..\..\VkStatus.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "9FE5438E5E92F43BB3922155D455594D5E792A698B31A2F01B134120E57F5C06"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using Vk_App;


namespace Vk_App {
    
    
    /// <summary>
    /// VkStatus
    /// </summary>
    public partial class VkStatus : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 41 "..\..\VkStatus.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label welcomuser;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\VkStatus.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox status_text;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\VkStatus.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button get;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Vk_App;component/vkstatus.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\VkStatus.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.welcomuser = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.status_text = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            
            #line 53 "..\..\VkStatus.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.outFromAcc);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 69 "..\..\VkStatus.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.NewStatus);
            
            #line default
            #line hidden
            return;
            case 5:
            this.get = ((System.Windows.Controls.Button)(target));
            
            #line 72 "..\..\VkStatus.xaml"
            this.get.Click += new System.Windows.RoutedEventHandler(this.GetStatus);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 76 "..\..\VkStatus.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.magicStatus);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 79 "..\..\VkStatus.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteStatus);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

