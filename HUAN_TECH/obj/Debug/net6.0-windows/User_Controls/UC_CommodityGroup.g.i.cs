﻿#pragma checksum "..\..\..\..\User_Controls\UC_CommodityGroup.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8D9C3E91A690F813C100C6622079C406FD532058"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using HUAN_TECH.User_Controls;
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


namespace HUAN_TECH.User_Controls {
    
    
    /// <summary>
    /// UC_CommodityGroup
    /// </summary>
    public partial class UC_CommodityGroup : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 42 "..\..\..\..\User_Controls\UC_CommodityGroup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_groupname;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\User_Controls\UC_CommodityGroup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_description;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\..\User_Controls\UC_CommodityGroup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_add;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\..\User_Controls\UC_CommodityGroup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dtg_commodity_group;
        
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
            System.Uri resourceLocater = new System.Uri("/HUAN_TECH;component/user_controls/uc_commoditygroup.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\User_Controls\UC_CommodityGroup.xaml"
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
            this.txt_groupname = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txt_description = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.btn_add = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\..\..\User_Controls\UC_CommodityGroup.xaml"
            this.btn_add.Click += new System.Windows.RoutedEventHandler(this.btn_add_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.dtg_commodity_group = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 5:
            
            #line 52 "..\..\..\..\User_Controls\UC_CommodityGroup.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Event_EditItem);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

