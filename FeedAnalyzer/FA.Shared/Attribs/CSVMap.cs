using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.Shared.Attribs
{
    public class CSVMap : Attribute
    {
        public string ColName { get; set; }
        public int ColNum { get; set; }
        public Type To { get; set; }
        public CSVMap(string name, Type to)
        {
            To = to;
            ColName = name;
        }
        public CSVMap(int colnum, Type to)
        {
            ColNum = colnum;
            To = to;
            ColName = colnum.ToString();
        }

        public CSVMap(string name)
        {
            To = typeof(string);
            ColName = name;
        }
        public CSVMap(int colnum)
        {
            To = typeof(string);
            ColNum = colnum;
            ColName = colnum.ToString();
        }
    }
}
