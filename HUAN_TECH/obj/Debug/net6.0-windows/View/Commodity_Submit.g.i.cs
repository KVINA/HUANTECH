﻿#pragma checksum "..\..\..\..\View\Commodity_Submit.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "FFA0ECDD7F0332942CFD6CD85B931A0E0547E7CC"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using HUAN_TECH.View;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
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


namespace HUAN_TECH.View {
    
    
    /// <summary>
    /// Commodity_Submit
    /// </summary>
    public partial class Commodity_Submit : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\..\View\Commodity_Submit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grid_body;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\View\Commodity_Submit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox txt_commodityGroup;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\View\Commodity_Submit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_commodityName;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\View\Commodity_Submit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_description;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\View\Commodity_Submit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_price;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\View\Commodity_Submit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_quantity;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\View\Commodity_Submit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_unit;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\View\Commodity_Submit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_submit;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.3.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/HUAN_TECH;component/view/commodity_submit.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\Commodity_Submit.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.3.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.grid_body = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.txt_commodityGroup = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.txt_commodityName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txt_description = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txt_price = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.txt_quantity = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.txt_unit = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.btn_submit = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\..\..\View\Commodity_Submit.xaml"
            this.btn_submit.Click += new System.Windows.RoutedEventHandler(this.Event_Submit);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

