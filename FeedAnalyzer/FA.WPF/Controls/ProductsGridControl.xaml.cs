using FA.BL.Collections;
using FA.BL.Model;
using FA.BL.ViewModels;
using FA.Shared.Attribs;
using FA.WPF.Factories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for ProductsGridControl.xaml
    /// </summary>
    public partial class ProductsGridControl : UserControl
    {
        private bool _AndOr { get; set; } //true = and | false = or.
        private string _SelectedCategory { get; set; }
        private string _SelectedSubCategory { get; set; }
        private ObservableRangeCollection<ProductGridViewModel> _GridViewResult;

        List<Product> Products = new List<Product>();
        List<ProductGridViewModel> GridProducts = new List<ProductGridViewModel>();

        public ProductsGridControl()
        {
            _GridViewResult = new ObservableRangeCollection<ProductGridViewModel>();
            _GridViewResult.CollectionChanged += Result_CollectionChanged;
            InitializeComponent();
            InitializeProductsGrid();
            ProductDetailCtrl.CloseModalBtn.Click += CloseModalBtn_Click;

        }

        private void CloseModalBtn_Click(object sender, RoutedEventArgs e)
        {
            ProductsGrid.Visibility = Visibility.Visible;
        }

        private void InitializeFilters()
        {
            foreach (string catName in Products.OrderBy(o=>o.ProductCategory).Select(s => s.ProductCategory).Distinct<string>())
            {
                CategoryDd.Items.Add(catName);
            }
            _SelectedCategory = CategoryDd.Items[0].ToString();
            CategoryDd.SelectedItem = _SelectedCategory;
            foreach (string catName in Products.OrderBy(o=>o.ProductSubCategory).Select(s => s.ProductSubCategory).Distinct<string>())
            {
                SubCategory.Items.Add(catName);
            }
            _SelectedSubCategory = SubCategory.Items[0].ToString();
            SubCategory.SelectedItem = _SelectedSubCategory;
        }
        public void SetGridData(List<Product> products)
        {
            Products = products;
            InitializeFilters();
            _GridViewResult.Clear();
            _GridViewResult.AddRange((from p in products.OrderBy(o => o.ProductCategory) select new ProductGridViewModel(p)));
            foreach (ProductGridViewModel m in _GridViewResult)
            {
                ProductsGrid.Items.Add(m);
            }
        }

        private void Result_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            ProductsGrid.Items.Clear();
        }

        private void InitializeProductsGrid()
        {
            ProductDetailCtrl.Visibility = Visibility.Hidden;
            foreach (PropertyInfo info in typeof(ProductGridViewModel).GetProperties())
            {
                GridCol attrib = (GridCol)info.GetCustomAttribute<GridCol>();
                if (attrib != null)
                {
                    DataGridColumn col = DataGridColumnFactory.CreateColumn(attrib, info);

                    if(attrib.SortMember != null)
                    {
                        col.SortMemberPath = attrib.SortMember;
                    }
                    col.CanUserSort = attrib.Sortable;
                    ProductsGrid.Columns.Add(col);
                }
            }
        }
        private void ProductsGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGrid grid = (DataGrid)sender;
            ProductGridViewModel p = (ProductGridViewModel)grid.SelectedItem;

            if (p != null)
            {
                Product product = Products.Single<Product>(w => w.ShopProductCode == p.ShopProductCode);
                ProductDetailViewModel m = new ProductDetailViewModel(product);
                ProductDetailCtrl.SetProduct(m);
                this.ProductsGrid.Visibility = Visibility.Hidden;
                this.ProductDetailCtrl.Visibility = Visibility.Visible;
            }
           
        }
        private void radioButton_AND_Checked(object sender, RoutedEventArgs e)
        {
            this._AndOr = true;
            if (!String.IsNullOrEmpty(_SelectedCategory) && !String.IsNullOrEmpty(_SelectedSubCategory))
            {
                _GridViewResult.Clear();
                _GridViewResult.AddRange((from p in Products where p.ProductSubCategory == _SelectedSubCategory && p.ProductCategory == _SelectedCategory select new ProductGridViewModel(p)));

            }
            foreach (ProductGridViewModel m in _GridViewResult)
            {
                ProductsGrid.Items.Add(m);
            }
        }

        private void radioButton_OR_Checked(object sender, RoutedEventArgs e)
        {
            this._AndOr = false;
            if (!String.IsNullOrEmpty(_SelectedCategory) && !String.IsNullOrEmpty(_SelectedSubCategory))
            {
                _GridViewResult.Clear();
                _GridViewResult.AddRange((from p in Products where p.ProductSubCategory == _SelectedSubCategory || p.ProductCategory == _SelectedCategory select new ProductGridViewModel(p)));
            }
            foreach (ProductGridViewModel m in _GridViewResult)
            {
                ProductsGrid.Items.Add(m);
            }
        }

        private void SubCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox s = (ComboBox)sender;
            _SelectedSubCategory = s.SelectedItem.ToString();

            if (_AndOr == true) //-- AND
            {
                _GridViewResult.Clear();
                if (String.IsNullOrEmpty(_SelectedCategory))
                {
                    _GridViewResult.AddRange((from p in Products where p.ProductSubCategory == _SelectedSubCategory select new ProductGridViewModel(p)));
                }
                else
                {
                    _GridViewResult.AddRange((from p in Products where p.ProductSubCategory == _SelectedSubCategory && p.ProductCategory == _SelectedCategory select new ProductGridViewModel(p)));

                }
            }
            else //OR
            {
                _GridViewResult.Clear();
                if (String.IsNullOrEmpty(_SelectedCategory))
                {
                    _GridViewResult.AddRange((from p in Products where p.ProductSubCategory == _SelectedSubCategory select new ProductGridViewModel(p)));
                }
                else
                {
                    _GridViewResult.AddRange((from p in Products where p.ProductSubCategory == _SelectedSubCategory || p.ProductCategory == _SelectedCategory select new ProductGridViewModel(p)));

                }
            }
            foreach (ProductGridViewModel m in _GridViewResult)
            {
                ProductsGrid.Items.Add(m);
            }
        }

        private void CategoryDd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox s = (ComboBox)sender;
            _SelectedCategory = s.SelectedItem.ToString();
            if (_AndOr == true) //-- AND
            {
                _GridViewResult.Clear();
                if (String.IsNullOrEmpty(_SelectedSubCategory))
                {
                    _GridViewResult.AddRange((from p in Products where (p.ProductCategory == _SelectedCategory) select new ProductGridViewModel(p)));
                }
                else
                {
                    _GridViewResult.AddRange((from p in Products where (p.ProductCategory == _SelectedCategory && p.ProductSubCategory == _SelectedSubCategory) select new ProductGridViewModel(p)));
                }

            }
            else //OR
            {
                _GridViewResult.Clear();
                if (String.IsNullOrEmpty(_SelectedSubCategory))
                {
                    _GridViewResult.AddRange((from p in Products where (p.ProductCategory == _SelectedCategory) select new ProductGridViewModel(p)));
                }
                else
                {
                    _GridViewResult.AddRange((from p in Products where (p.ProductCategory == _SelectedCategory || p.ProductSubCategory == _SelectedSubCategory) select new ProductGridViewModel(p)));

                }
            }
            foreach (ProductGridViewModel m in _GridViewResult)
            {
                ProductsGrid.Items.Add(m);
            }
        }
    }
}
