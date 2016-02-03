using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.BL.ViewModels
{
    public class Category
    {
        public string Name { get; set; }
        public List<Category> Children = new List<Category>();
    }
}
