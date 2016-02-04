using FA.Shared.Enum;
using System;

namespace FA.Shared.Attribs
{
    public class GridCol : Attribute
    {
        public DataGridColumnType Type { get; set; }
        public string Label { get; set; }
        public GridCol(DataGridColumnType type, string label)
        {
            Type = type;
            Label = label;
        }
    }
}