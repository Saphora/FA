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
    public class ProductDetailViewModel
    {
        private Product _Product { get; set; }
        public ProductDetailViewModel()
        {

        }

        public ProductDetailViewModel(Product p)
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
            this.NumStartPrice = p.NumStartPrice;
            this.NumPrice = p.NumPrice;
            this.ManArtCode = p.ManArtCode;
            this.ShopProductCode = p.ShopProductCode;
        }        

        [FieldLabel("Categorie")]
        public string ProductCategory { get; set; }


        [FieldLabel("Sub-categorie")]
        public string ProductSubCategory { get; set; }


        [FieldLabel("Merk")]
        public string Brand { get; set; }

        [FieldLabel("Titel")]
        public string Title { get; set; }

        [FieldLabel("Start prijs")]
        public string StartPrice { get { return NumStartPrice.ToString("C2", CultureInfo.CreateSpecificCulture("nl-NL")); } }
        
        [FieldLabel("Prijs")]
        public string Price { get { return NumPrice.ToString("C2",CultureInfo.CreateSpecificCulture("nl-NL")); } }
        
        public float NumStartPrice { get; set; }
        
        public double NumPrice { get; set; }

        [FieldLabel("Levertijd")]
        public string DeliveryTime { get; set; }


        [FieldLabel("Omschrijving")]
        public string Description { get; set; }

        public double TransmitCostNum { get; set; }


        [FieldLabel("Verzendkosten")]
        public string TransmitCost { get { return TransmitCostNum.ToString("C2", CultureInfo.CreateSpecificCulture("nl-NL")); } }

        [FieldLabel("EAN")]
        public string EAN { get; set; }


        [FieldLabel("# fabrikant")]
        public string ManArtCode { get; set; }


        [FieldLabel("Shop produkt #")]
        public string ShopProductCode { get; set; }


        [FieldLabel("Percentage verzendkosten / prijs")]
        public string PriceTransmitCostRatio
        {
            get
            {
                return string.Format("%{0}", Math.Round(((TransmitCostNum / _Product.NumPrice) * 100)).ToString());
            }
        }
    }
}
