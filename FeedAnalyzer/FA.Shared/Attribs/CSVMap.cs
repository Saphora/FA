using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.Shared.Attribs
{
    public class CSVMap : Attribute
    {
        private bool _IsSetByName { get; set; }
        private bool _IsSetByCol { get; set; }
        public bool IsSetByName { get { return _IsSetByName; } }
        public bool IsSetByCol { get { return _IsSetByCol; } }

        public string ColName { get; set; }
        public int ColNum { get; set; }

        public CSVMap(string name)
        {
            _IsSetByName = true;
            _IsSetByCol = false;
            ColName = name;
        }
        public CSVMap(int colnum)
        {
            ColNum = colnum;
            ColName = colnum.ToString();
            _IsSetByCol = true;
            _IsSetByName = false;
        }
    }
}
