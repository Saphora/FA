using FA.Shared.Enum;
using System;

namespace FA.Shared.Attribs
{
    public class GridCol : Attribute
    {
        public DataGridColumnType Type { get; set; }
        public string Label { get; set; }
        public bool Sortable { get; set; }

        public string SortMember { get; set; }
        public GridCol(DataGridColumnType type, string label)
        {
            Type = type;
            Label = label;
            Sortable = true;
        }
        public GridCol(DataGridColumnType type, string label, bool sortable)
        {
            Type = type;
            Label = label;
            Sortable = sortable;
        }
        public GridCol(DataGridColumnType type, string label, string sortMember)
        {
            Type = type;
            Label = label;
            Sortable = true;
            SortMember = sortMember;
        }
    }
}