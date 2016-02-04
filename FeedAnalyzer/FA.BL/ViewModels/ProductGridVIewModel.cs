using FA.BL.Model;
using FA.Shared.Attribs;
using FA.Shared.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.BL.ViewModels
{
    public class ProductGridViewModel
    {
        private Product _Product { get; set; }
        public ProductGridViewModel()
        {

        }

        public ProductGridViewModel(Product p)
        {
            _Product = p;
            this.ProductCategory = p.ProductCategory;
            this.ProductSubCategory = p.ProductSubCategory;
            this.Brand = p.Brand;
            this.Title = p.Title;
            this.DeliveryTime = p.DeliveryTime;
            this.Description = p.Description;
            this.EAN = p.EAN;
            this.TransmitCostNum = p.TransmitCostNum;
            this.ManArtCode = p.ManArtCode;
            this.ShopProductCode = p.ShopProductCode;
        }        

        [GridCol(DataGridColumnType.DataGridTextColumn, "Categorie")]
        public string ProductCategory { get; set; }


        [GridCol(DataGridColumnType.DataGridTextColumn, "Sub-categorie")]
        public string ProductSubCategory { get; set; }


        [GridCol(DataGridColumnType.DataGridTextColumn, "Merk")]
        public string Brand { get; set; }

        [GridCol(DataGridColumnType.DataGridTextColumn, "Titel")]
        public string Title { get; set; }

        [GridCol(DataGridColumnType.DataGridTextColumn, "Start prijs")]
        public string StartPrice { get { return _Product.NumPrice.ToString(); } }
        
        [GridCol(DataGridColumnType.DataGridTextColumn, "Prijs")]
        public string Price { get { return _Product.NumPrice.ToString(); } }


        [GridCol(DataGridColumnType.DataGridTextColumn, "Levertijd")]
        public string DeliveryTime { get; set; }


        [GridCol(DataGridColumnType.DataGridTextColumn, "Omschrijving")]
        public string Description { get; set; }

        public double TransmitCostNum { get; set; }


        [GridCol(DataGridColumnType.DataGridTextColumn, "Verzendkosten")]
        public string TransmitCost { get { return TransmitCostNum.ToString(); } }

        [GridCol(DataGridColumnType.DataGridTextColumn, "EAN")]
        public string EAN { get; set; }


        [GridCol(DataGridColumnType.DataGridTextColumn, "# fabrikant")]
        public string ManArtCode { get; set; }


        [GridCol(DataGridColumnType.DataGridTextColumn, "Shop produkt #")]
        public string ShopProductCode { get; set; }
    }
}
