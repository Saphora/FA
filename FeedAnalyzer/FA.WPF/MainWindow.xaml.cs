using FA.BL.Providers;
using FA.BL.ViewModels;
using Microsoft.Win32;
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
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
using FA.Shared.Attribs;
using FA.Shared.Enum;
using FA.WPF.Factories;
using FA.BL.Model;
using Telerik.Windows.Controls.Legend;
using Telerik.Windows.Controls.ChartView;
using Telerik.Charting;

namespace FA.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private OpenFileDialog Dialog = new OpenFileDialog();
        private List<Product> Products = new List<Product>();
        private Dictionary<string, int> ProductCatCount = new Dictionary<string, int>();
        public MainWindow()
        {
            Dialog.FileOk += Dialog_FileOk;
            InitializeComponent();
            TxtCSVPath.IsReadOnly = true;
            SetEllipseDisabled();
            InitializeProductsGrid();
        }

        private void BtnSelectFeed_Click(object sender, RoutedEventArgs e)
        {
            Dialog.DefaultExt = ".csv";
            bool? dialogOpen = Dialog.ShowDialog();
        }

        private void Dialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TxtCSVPath.Clear();
            TxtCSVPath.Text = Dialog.FileName;
            try
            {
                
                CSVProvider provider = new CSVProvider(true);
                provider.LoadCSV(Dialog.FileName);
                Products = provider.GetDataByColNames<Product>();
                SetGridData(Products);
                SetEllipseSucces();
                InitializeRadPieChart();
            } catch
            {
                SetEllipseFailed();
            }
        }

        private void SetGridData(List<Product> products)
        {
            List<ProductGridViewModel> result = (from p in products.OrderBy(o=>o.ProductCategory) select new ProductGridViewModel(p)).ToList();
            foreach(ProductGridViewModel m in result)
            {
                ProductsGrid.Items.Add(m);
            }
        }

        private void SetEllipseDisabled()
        {
            EllipseStatus.Fill = new SolidColorBrush(Color.FromRgb(186, 186, 186));
            LblFileStatus.Content = "Bestand nog niet geladen";
        }

        private void SetEllipseSucces()
        {
            EllipseStatus.Fill = new SolidColorBrush(Color.FromRgb(0, 255, 0));
            LblFileStatus.Content = "Bestand succesvol geladen";
        }

        private void SetEllipseFailed()
        {
            EllipseStatus.Fill = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            LblFileStatus.Content = "Bestand kan niet geladen worden,"+Environment.NewLine+"controleer uw rechten op het bestand en probeer opnieuw.";

        }

        private void InitializeProductsGrid()
        {
            foreach(PropertyInfo info in typeof(ProductGridViewModel).GetProperties())
            {
                GridCol attrib = (GridCol) info.GetCustomAttribute<GridCol>();
                if (attrib != null)
                {
                    DataGridColumn col = DataGridColumnFactory.CreateColumn(attrib, info);
                    ProductsGrid.Columns.Add(col);
                }
            }
        }
        private void _CountProductsByCategory()
        {

            List<string> r = Products.Select(s => s.ProductCategory).Distinct().ToList();
            foreach (string c in r)
            {
                ProductCatCount.Add(c, Products.Where(w => w.ProductCategory == c).Count());
            }
        }
        private void InitializeRadPieChart()
        {
            _CountProductsByCategory();
            List<PieDataPoint> Categories = (from c in 
                                                        Products.Select(s=>s.ProductCategory).Distinct<string>()
                                                         select new PieDataPoint { IsSelected = false,
                                                         Label = c, Value =ProductCatCount[c]} ).ToList();
            try {
                foreach(string c in ProductCatCount.Keys)
                {
                    Random r = new Random();
                    Random g = new Random();
                    Random b = new Random();
                    RadPieChart.LegendItems.Add(new LegendItem { Title = c ,  MarkerFill = new SolidColorBrush(Color.FromRgb(Convert.ToByte(255/r.Next(255)),Convert.ToByte(255/g.Next(255)), Convert.ToByte(255/b.Next(255)))) });
                    RadPieChart.DataContext = Categories;
                    

                }
                RadPieChart.Name = "Producten per categorie";

            }
            catch(Exception ex)
            {
                Console.Write(ex.Message);
            }
            
        }
    }
}
