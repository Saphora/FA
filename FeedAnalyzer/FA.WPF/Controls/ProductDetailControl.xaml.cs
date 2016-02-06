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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FA.WPF.Controls
{
    /// <summary>
    /// Interaction logic for ProductDetailControl.xaml
    /// </summary>
    public partial class ProductDetailControl : UserControl
    {
        public ProductDetailControl()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            Button _Sender = (Button)sender;
           
        }

        public void SetProduct(ProductDetailViewModel model)
        {
            ProductStack.Children.Clear();
            foreach (PropertyInfo info in model.GetType().GetProperties())
            {

                FieldLabel label = info.GetCustomAttribute<FieldLabel>();
                Label lbl = new Label();
                
                if (label != null)
                {
                    lbl.Content = String.Format("{0} : {1}", label.Label, info.GetValue(model).ToString());
                    ProductStack.Children.Add(lbl);
                }
            }
            this.Visibility = Visibility.Visible;
            
        }
    }
}
