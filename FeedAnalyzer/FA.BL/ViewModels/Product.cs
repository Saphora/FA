using FA.Shared.Attribs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.BL.ViewModels
{
    public class Product
    {
        //Please, feel free to play with the commented code ([CSVMap()])

        //[CSVMap(0)]
        [CSVMap("Categorie")]
        public Category ProductCategory { get; set; }

        //[CSVMap(2)]
        [CSVMap("Subcategorie")]
        public Category ProductSubCategory { get; set; }

        //[CSVMap(3)]
        [CSVMap("Merk")]
        public string Brand { get; set; }

        //[CSVMap(4)]
        [CSVMap("Titel")]
        public string Title { get; set; }

        public string StartPrice { get; }

        //[CSVMap(5)]
        [CSVMap("Van-Prijs")]
        public float NumStartPrice { get; set; }

        public string Price { get; }
        
        //[CSVMap(6)]
        [CSVMap("Prijs")]
        public float NumPrice { get; set; }

        //[CSVMap(7)]
        [CSVMap("Levertijd")]
        public string DeliveryTime { get; set; }

        //[CSVMap(8)]
        [CSVMap("Omschrijving")]
        public string Description { get; set; }

        //[CSVMap(9)]
        [CSVMap("Verzendkosten")]
        public string TransmitCost { get; set; }

        //[CSVMap(10)]
        [CSVMap("EAN")]
        public string EAN { get; set; }

        //[CSVMap(11)]
        [CSVMap("Artikelcodefabrikant")]
        public string ManArtCode { get; set; }

        //[CSVMap(12)]
        [CSVMap("Winkelproductcode")]
        public string ShopProductCode { get; set; }
    }
}
