using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using FA.Shared.Attribs;

namespace FA.BL.Mappers
{
    public static class CSVEntityMapper
    {
        public static T MapTo<T>()
        {
            T result = Activator.CreateInstance<T>();

            if (result != null) {
                PropertyInfo[] pInfo = result.GetType().GetProperties();
                foreach(PropertyInfo info in pInfo)
                {
                    if(true)
                    {

                    }
                }
            } else
            {
                throw new Exception("Cannot create an instance of" + typeof(T).DeclaringType);
            }
            return result;
        }
    }
}
