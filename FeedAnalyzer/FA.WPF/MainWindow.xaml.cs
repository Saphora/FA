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
using PieControls;
using System.Collections.ObjectModel;
using FA.WPF.Util;
using FA.WPF.Windows;

namespace FA.WPF
{
    public class PieDataCollection<T> : ObservableCollection<T> where T : PieSegment
    {
        public string CollectionName { get; set; }
    }
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
            InitializeComponent();
            InitializeRadPieChart();
            Dialog.FileOk += Dialog_FileOk;
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
            LblFileStatus.Content = string.Format("Totaal aantal producten: {0}", Products.Count());
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
            RandomColor color = new RandomColor();
            _CountProductsByCategory();
            PieDataCollection<PieSegment> collection1 = new PieDataCollection<PieSegment>();
            foreach (KeyValuePair<string, int> kvp in ProductCatCount)
            {
                collection1.Add(new PieSegment { Color = color.NextColor(), Value = kvp.Value, Name = kvp.Key });
            }
            collection1.CollectionName = "Categories";
            chart1.Data = collection1;            
        }

        private void ProductsGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ProductDetail win = new ProductDetail();
            win.ShowProduct(new ProductGridViewModel());
        }
    }
}
