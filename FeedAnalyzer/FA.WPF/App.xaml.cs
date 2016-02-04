using FA.BL.Providers;
using FA.BL.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FA.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        List<ProductGridViewModel> Products = new List<ProductGridViewModel>();
        public App()
        {

        }
    }
}
