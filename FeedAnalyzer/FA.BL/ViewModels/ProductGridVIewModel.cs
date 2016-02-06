using FA.BL.Model;
using FA.Shared.Attribs;
using FA.Shared.Enum;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.BL.ViewModels
{
    public class ProductGridViewModel
    {
        public ProductGridViewModel()
        {

        }

        public ProductGridViewModel(Product p)
        {
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
            this.NumPrice = p.NumPrice;
            this.NumStartPrice = p.NumStartPrice;
            
        }

        [GridCol(DataGridColumnType.DataGridTextColumn, "Shop produkt #")]
        public string ShopProductCode { get; set; }

        [GridCol(DataGridColumnType.DataGridTextColumn, "Prijs", "NumPrice")]
        public string Price { get { return NumPrice.ToString("C2", CultureInfo.CreateSpecificCulture("nl-NL")); } }

        [GridCol(DataGridColumnType.DataGridTextColumn, "Verzendkosten", "TransmitCostNum")]
        public string TransmitCost { get { return TransmitCostNum.ToString("C2", CultureInfo.CreateSpecificCulture("nl-NL")); } }

        [GridCol(DataGridColumnType.DataGridTextColumn, "%", "NumRatio")]
        public string PriceTransmitCostRatio
        {
            get
            {
                return string.Format("%{0}", Math.Round(((TransmitCostNum / NumPrice) * 100)).ToString());
            }
        }

        [GridCol(DataGridColumnType.DataGridTextColumn, "Categorie")]
        public string ProductCategory { get; set; }


        [GridCol(DataGridColumnType.DataGridTextColumn, "Sub-categorie")]
        public string ProductSubCategory { get; set; }


        [GridCol(DataGridColumnType.DataGridTextColumn, "Merk")]
        public string Brand { get; set; }

        [GridCol(DataGridColumnType.DataGridTextColumn, "Titel")]
        public string Title { get; set; }

        public float NumStartPrice { get; set; }

        public double NumPrice { get; set; }

        public double NumRatio { get { return Math.Round(((TransmitCostNum / NumPrice) * 100)); } }

        //[GridCol(DataGridColumnType.DataGridTextColumn, "Start prijs")]
        public string StartPrice { get { return NumStartPrice.ToString("C2", CultureInfo.CreateSpecificCulture("nl-NL")); } }
        
        //[GridCol(DataGridColumnType.DataGridTextColumn, "Levertijd")]
        public string DeliveryTime { get; set; }

        //[GridCol(DataGridColumnType.DataGridTextColumn, "Omschrijving")]
        public string Description { get; set; }

        public double TransmitCostNum { get; set; }


        //[GridCol(DataGridColumnType.DataGridTextColumn, "EAN")]
        public string EAN { get; set; }


        //[GridCol(DataGridColumnType.DataGridTextColumn, "# fabrikant")]
        public string ManArtCode { get; set; }



    }
}
