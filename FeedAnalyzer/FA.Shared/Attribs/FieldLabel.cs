using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.Shared.Attribs
{
    public class FieldLabel : Attribute
    {
        public string Label { get; set; }
        public FieldLabel(string label)
        {
            Label = label;
        }
    }
}
