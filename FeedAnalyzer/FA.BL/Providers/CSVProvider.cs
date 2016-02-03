using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
        public CSVProvider(string filename)
        {
            //if(File.Exists(filename))
            //{
            //    StartTime = new TimeSpan(DateTime.Now.Ticks);
            //    StreamReader reader = new StreamReader(filename);
            //    string line = string.Empty;
            //    int index = 0;
            //    while(!String.IsNullOrEmpty(reader.ReadLine()))
            //    {
            //        line = reader.ReadLine();
            //        if (index == 0 && ColsOnFirstRow == true)
            //        {
            //            string[] res = line.Split(';');
            //            Console.WriteLine("COLS: "+line);
            //        } else
            //        {
            //            Console.WriteLine(line);
            //            string[] res = line.Split(';');
            //        }
            //        index++;
            //    }
            //    EndTime = new TimeSpan(DateTime.Now.Ticks);
            //    long ms = EndTime.Ticks - StartTime.Ticks;
            //    Console.WriteLine("Time elapsed:" + ms);
            //}

            if(File.Exists(filename))
            {
                StartTime = new TimeSpan(DateTime.Now.Ticks);
                string[] r = File.ReadAllLines(filename);

                for(int i = 0; i<= r.Length-1; i++)
                {
                    if (i == 0 && ColsOnFirstRow)
                    {
                        string[] l = r[i].Split(';');
                    }
                }
                EndTime = new TimeSpan(DateTime.Now.Ticks);
                long ms = EndTime.Ticks - StartTime.Ticks;
                Console.WriteLine("Time elapsed:" + ms);
            }
        }
    }
}
