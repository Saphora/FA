using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FeedAnalyzer.BL
{
    public class CSVProvider
    {
        private string _CSVString = "";
        private List<IDataRecord> Records = new List<IDataRecord>();

        //open csv file for reading
        public void Open(string file)
        {
            if (File.Exists(file))
            {

            }
            else
            {
                throw new FileNotFoundException();
            }
        }


    }
}
