using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace FA.WPF.Util
{
    public class RandomColor
    {
        private Type ColorType = typeof(System.Drawing.Color);
        private PropertyInfo[] pinfo;
        private Random rand = new Random();
        public RandomColor()
        {
            pinfo = ColorType.GetProperties(BindingFlags.Static | BindingFlags.Public);

        }
        public System.Windows.Media.Color NextColor()
        {
            System.Drawing.Color ColorName = System.Drawing.Color.FromName(pinfo[rand.Next(0, pinfo.Length)].Name);
            System.Windows.Media.Color newColor = System.Windows.Media.Color.FromRgb(ColorName.R, ColorName.G, ColorName.B);
            return newColor;
        }
    }
}
