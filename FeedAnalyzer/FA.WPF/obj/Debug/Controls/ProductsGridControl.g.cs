﻿#pragma checksum "..\..\..\Controls\ProductsGridControl.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6C05B7B4387496046120C53C2A8BB9A2"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FA.WPF.Controls;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


namespace FA.WPF.Controls {
    
    
    /// <summary>
    /// ProductsGridControl
    /// </summary>
    public partial class ProductsGridControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\Controls\ProductsGridControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid ProductsGrid;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\Controls\ProductsGridControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CategoryDd;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\Controls\ProductsGridControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Controls\ProductsGridControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label1;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Controls\ProductsGridControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox SubCategory;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Controls\ProductsGridControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton radioButton_AND;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\Controls\ProductsGridControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton radioButton_OR;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Controls\ProductsGridControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal FA.WPF.Controls.ProductDetailControl ProductDetailCtrl;
        
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
            System.Uri resourceLocater = new System.Uri("/FA.WPF;component/controls/productsgridcontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Controls\ProductsGridControl.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            this.ProductsGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 12 "..\..\..\Controls\ProductsGridControl.xaml"
            this.ProductsGrid.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.ProductsGrid_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 2:
            this.CategoryDd = ((System.Windows.Controls.ComboBox)(target));
            
            #line 13 "..\..\..\Controls\ProductsGridControl.xaml"
            this.CategoryDd.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CategoryDd_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.label = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.label1 = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.SubCategory = ((System.Windows.Controls.ComboBox)(target));
            
            #line 16 "..\..\..\Controls\ProductsGridControl.xaml"
            this.SubCategory.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.SubCategory_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.radioButton_AND = ((System.Windows.Controls.RadioButton)(target));
            
            #line 18 "..\..\..\Controls\ProductsGridControl.xaml"
            this.radioButton_AND.Checked += new System.Windows.RoutedEventHandler(this.radioButton_AND_Checked);
            
            #line default
            #line hidden
            return;
            case 7:
            this.radioButton_OR = ((System.Windows.Controls.RadioButton)(target));
            
            #line 19 "..\..\..\Controls\ProductsGridControl.xaml"
            this.radioButton_OR.Checked += new System.Windows.RoutedEventHandler(this.radioButton_OR_Checked);
            
            #line default
            #line hidden
            return;
            case 8:
            this.ProductDetailCtrl = ((FA.WPF.Controls.ProductDetailControl)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

