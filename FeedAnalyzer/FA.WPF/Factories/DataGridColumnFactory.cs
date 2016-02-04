using FA.Shared.Attribs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace FA.WPF.Factories
{
    public class DataGridColumnFactory
    { 
        public static DataGridColumn CreateColumn(GridCol colAttrib, PropertyInfo pInfo)
        {
            if(colAttrib.Type == Shared.Enum.DataGridColumnType.DataGridTextColumn)
            {
                DataGridTextColumn col = new DataGridTextColumn();
                col.Header = colAttrib.Label;
                Binding binding = new Binding(pInfo.Name);
                col.Binding = binding;
                return col;
            }
            throw new NotImplementedException("The columntype is not implemented.");
        }
    }
}
