using FA.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.BL.ViewModels
{
    public class ProductPieChartViewModel
    {
        public ProductPieChartViewModel(Product p)
        {
            this.ProductCategory = p.ProductCategory;
            this.ProductSubCategory = p.ProductSubCategory;
            this.Brand = p.Brand;
            this.Title = p.Title;
            this.NumStartPrice = p.NumStartPrice;
            this.NumPrice = p.NumPrice;
            this.DeliveryTime = p.DeliveryTime;
            this.Description = p.Description;
            this.EAN = p.EAN;
            this.TransmitCostNum = p.TransmitCostNum;
            this.ManArtCode = p.ManArtCode;
            this.ShopProductCode = p.ShopProductCode;
        }
        public string ProductCategory { get; set; }
        
        public string ProductSubCategory { get; set; }
        
        public string Brand { get; set; }

        public string Title { get; set; }

        public string StartPrice { get { return NumStartPrice.ToString(); } }

        public float NumStartPrice { get; set; }

        public double NumPrice { get; set; }

        public string Price { get { return NumPrice.ToString(); } }

        public string DeliveryTime { get; set; }

        public string Description { get; set; }

        public double TransmitCostNum { get; set; }

        public string TransmitCost { get { return TransmitCostNum.ToString(); } }

        public string EAN { get; set; }

        public string ManArtCode { get; set; }

        public string ShopProductCode { get; set; }
    }
}
