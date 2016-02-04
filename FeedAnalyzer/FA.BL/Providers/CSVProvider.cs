using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using FA.BL.Mappers;

namespace FA.BL.Providers
{
    /// <summary>
    /// CSV provider class
    /// </summary>
    public class CSVProvider
    {
        public Boolean ColsOnFirstRow = true;
        private TimeSpan StartTime;
        private TimeSpan EndTime;
        public string[] ColNames = { };
        public List<Dictionary<string, string>> DataWithColNames = new List<Dictionary<string, string>>();
        public List<Dictionary<int, string>> DataWithColNum = new List<Dictionary<int, string>>(); 
        public CSVProvider(bool colsOnFirstRow)
        {
            ColsOnFirstRow = colsOnFirstRow;
        }
        public void LoadCSV(string filename)
        {
            if (File.Exists(filename))
            {
                StartTime = new TimeSpan(DateTime.Now.Ticks);
                string[] r = File.ReadAllLines(filename);

                for (int i = 0; i <= r.Length - 1; i++)
                {
                    if (i == 0 && ColsOnFirstRow)
                    {
                        ColNames = r[i].Split(';');
                    }
                    else if (ColsOnFirstRow && ColNames.Length > 0)
                    {
                        _AddRecordWithColName(r[i]);
                    }
                    else
                    {
                        _AddRecordWithColNum(r[i]);
                    }
                }
                EndTime = new TimeSpan(DateTime.Now.Ticks);
                long ms = EndTime.Ticks - StartTime.Ticks;
                Console.WriteLine("Time elapsed:" + ms);
            }
        }
        public List<T> GetDataByColNames<T>()
        {
            CSVEntityMapper _Mapper = new CSVEntityMapper();
            return _Mapper.MapTo<T>(DataWithColNames);
        }
        public List<T> GetDataByColNum<T>()
        {
            CSVEntityMapper _Mapper = new CSVEntityMapper();
            return _Mapper.MapTo<T>(DataWithColNum);
        }

        private void _AddRecordWithColName(string line)
        {
            int key = 0;
            string[] record = line.Split(';');
            Dictionary<string, string> recordDict = new Dictionary<string, string>();
            foreach (string colName in ColNames)
            {
                recordDict.Add(colName, record[key]);
                key++;
            }
            DataWithColNames.Add(recordDict);
        }

        private void _AddRecordWithColNum(string line)
        {
            string[] record = line.Split(';');
            int key = 0;
            Dictionary<int, string> recordDict = new Dictionary<int, string>();
            foreach (string value in record)
            {
                recordDict.Add(key, value);
                key++;
            }
            DataWithColNum.Add(recordDict);
        }
    }
}
