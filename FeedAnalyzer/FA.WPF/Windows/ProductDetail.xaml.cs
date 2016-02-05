using FA.BL.ViewModels;
using FA.Shared.Attribs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FA.WPF.Windows
{
    /// <summary>
    /// Interaction logic for ProductDetail.xaml
    /// </summary>
    public partial class ProductDetail : Window
    {
        public ProductDetail()
        {
            InitializeComponent();
            StackItems.Children.Add(new Label());
        }
        public void ShowProduct(ProductGridViewModel model) 
        {
            foreach(PropertyInfo info in model.GetType().GetProperties()) {
                GridCol colAttrib = info.GetCustomAttribute<GridCol>();
                if (colAttrib != null)
                {
                    StackItems.Children.Add(new Label { Content = String.Format("{0} : {1}", colAttrib.Label, info.GetValue(info)) });
                }
            }
        }
    }
}
