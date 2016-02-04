using FA.Shared.Attribs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.BL.Model
{
    public class Product
    {
        public Product()
        {

        }
        //[CSVMap(0)]
        [CSVMap("Categorie")]
        public string ProductCategory { get; set; }

        //[CSVMap(1)]
        [CSVMap("Subcategorie")]
        public string ProductSubCategory { get; set; }

        //[CSVMap(2)]
        [CSVMap("Merk")]
        public string Brand { get; set; }

        //[CSVMap(3)]
        [CSVMap("Titel")]
        public string Title { get; set; }
        
        //[CSVMap(4)]
        [CSVMap("Van-Prijs")]
        public float NumStartPrice { get; set; }

        //[CSVMap(5)]
        [CSVMap("Prijs")]
        public double NumPrice { get; set; }
        
        //[CSVMap(6)]
        [CSVMap("Levertijd")]
        public string DeliveryTime { get; set; }

        //[CSVMap(7)]
        [CSVMap("Omschrijving")]
        public string Description { get; set; }

        //[CSVMap(8)]
        [CSVMap("Verzendkosten")]
        public double TransmitCostNum { get; set; }
       
        //[CSVMap(9)]
        [CSVMap("EAN")]
        public string EAN { get; set; }

        //[CSVMap(10)]
        [CSVMap("Artikelcodefabrikant")]
        public string ManArtCode { get; set; }

        //[CSVMap(11)]
        [CSVMap("Winkelproductcode")]
        public string ShopProductCode { get; set; }

    }
}
