using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using FA.Shared.Attribs;
using System.Collections;

namespace FA.BL.Mappers
{
    public class CSVEntityMapper
    {
        /// <summary>
        /// Get an list of an specified type out of the CSV data.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<T> MapTo<T>(List<Dictionary<int, string>> data)
        {
            List<T> result = new List<T>();
            foreach (Dictionary<int, string> record in data)
            {
                //create instance of type argument.
                object resultItem = Activator.CreateInstance<T>();
                int propertyIndex = 0;
                foreach (PropertyInfo info in resultItem.GetType().GetProperties())
                {
                    CSVMap csvMapAttrib = _GetCSVMapAttrib(info);
                    if (csvMapAttrib != null) // else: ignore the property, property can be readonly or something what is not available from CSV.
                    {
                        //set safe value (which means, with correct type and default type value e.g. 0 for int etc).
                        resultItem = SetSafeValue(info, record[csvMapAttrib.ColNum], resultItem);
                    }
                    
                    propertyIndex++;
                }
                result.Add((T)resultItem);
            }
            return result;
        }

        /// <summary>
        /// Get an list of an specified type out of the CSV data.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<T> MapTo<T>(List<Dictionary<string, string>> data)
        {
            List<T> result = new List<T>();
            foreach (Dictionary<string, string> record in data)
            {
                //create instance of type argument.
                object resultItem = Activator.CreateInstance<T>();
                foreach (PropertyInfo info in resultItem.GetType().GetProperties())
                {
                    CSVMap csvMapAttrib = _GetCSVMapAttrib(info);
                    if (csvMapAttrib != null)  // else: ignore the property, property can be readonly or something what is not available from CSV.
                    {
                        //set safe value (which means, with correct type and default type value e.g. 0 for int etc).
                        resultItem = SetSafeValue(info, record[csvMapAttrib.ColName], resultItem);
                    }
                }
                //Add result and cast instance to origin type.
                result.Add((T)resultItem);
            }
            return result;
        }

        private CSVMap _GetCSVMapAttrib(PropertyInfo info)
        {
            CSVMap attr = (CSVMap) info.GetCustomAttribute<CSVMap>(true);
            return attr;
        }



        /// <summary>
        /// Set an property value by reflectedtype.
        /// Reused code from another personal project.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="value"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public object SetSafeValue(PropertyInfo info, object value, object obj)
        {
            if (info.CanWrite && value != null)
            {
                if (info.PropertyType.FullName == typeof(Guid).FullName)
                {
                    Guid result = Guid.Empty;
                    if (Guid.TryParse(value.ToString(), out result))
                    {
                        obj.GetType().GetProperty(info.Name).SetValue(obj, result);
                    }
                    else
                    {
                        obj.GetType().GetProperty(info.Name).SetValue(obj, Guid.Empty);
                    }
                }
                else if (info.PropertyType.FullName == typeof(int).FullName)
                {
                    int result = 0;
                    if (int.TryParse(value.ToString(), out result))
                    {
                        obj.GetType().GetProperty(info.Name).SetValue(obj, result);
                    }
                }
                else if (info.PropertyType.FullName == typeof(decimal).FullName)
                {
                    decimal result = 0;
                    if (decimal.TryParse(value.ToString(), out result))
                    {
                        obj.GetType().GetProperty(info.Name).SetValue(obj, result);
                    }
                }
                else if (info.PropertyType.FullName == typeof(double).FullName)
                {
                    double result = 0;
                    if (double.TryParse(value.ToString(), out result))
                    {
                        obj.GetType().GetProperty(info.Name).SetValue(obj, result);
                    }
                }
                else if (info.PropertyType.FullName == typeof(float).FullName)
                {
                    float result = 0;
                    if (float.TryParse(value.ToString(), out result))
                    {
                        obj.GetType().GetProperty(info.Name).SetValue(obj, result);
                    }
                }
                else if (info.PropertyType.FullName == typeof(bool).FullName)
                {
                    bool result = false;
                    if (bool.TryParse(value.ToString(), out result))
                    {
                        obj.GetType().GetProperty(info.Name).SetValue(obj, result);
                    }
                }
                else if (info.PropertyType.FullName == typeof(Int32).FullName)
                {
                    Int32 result = 0;
                    if (Int32.TryParse(value.ToString(), out result))
                    {
                        obj.GetType().GetProperty(info.Name).SetValue(obj, result);
                    }
                }
                else if (info.PropertyType.FullName == typeof(long).FullName)
                {
                    long result = 0;
                    if (long.TryParse(value.ToString(), out result))
                    {
                        obj.GetType().GetProperty(info.Name).SetValue(obj, result);
                    }
                }
                else if (info.PropertyType.FullName == typeof(Int64).FullName)
                {
                    Int64 result = 0;
                    if (Int64.TryParse(value.ToString(), out result))
                    {
                        obj.GetType().GetProperty(info.Name).SetValue(obj, result);
                    }
                }
                else if (info.PropertyType.FullName == typeof(DateTime).FullName)
                {
                    DateTime result = DateTime.MinValue;
                    if (DateTime.TryParse(value.ToString(), out result))
                    {
                        obj.GetType().GetProperty(info.Name).SetValue(obj, result);
                    }
                }
                else if (info.PropertyType.FullName == typeof(string).FullName)
                {
                    if (value != null)
                    {
                        obj.GetType().GetProperty(info.Name).SetValue(obj, value);
                    }
                    else
                    {
                        obj.GetType().GetProperty(info.Name).SetValue(obj, "");
                    }
                }
                else
                {
                    throw new NotImplementedException(string.Format("The functionality of setting {0} values is not implemented.",info.PropertyType.FullName));
                    
                    //fix navigation property code. It will not work for this project because origin usage was based on XML.
                    //comment code is kept in file for review:)

                    //if (value != null)
                    //{
                    //    if (info.PropertyType.GetInterfaces().Contains(typeof(IEnumerable)))
                    //    {
                    //        List<object> currentValue = (List<object>)value;
                    //        Type containingType = info.PropertyType.GenericTypeArguments[0];

                    //        Type listType = typeof(List<>).MakeGenericType(containingType);
                    //        IList myList = (IList)Activator.CreateInstance(listType);
                    //        foreach (object item in currentValue)
                    //        {
                    //            var r = Activator.CreateInstance(containingType, item);
                    //            myList.GetType().GetMethod("Add").Invoke(myList, new object[] { r });
                    //        }

                    //        obj.GetType().GetProperty(info.Name).SetValue(obj, myList);
                    //    }
                    //    else
                    //    {

                    //        obj.GetType().GetProperty(info.Name).SetValue(obj, value);
                    //    }
                    //}
                }
            }
            return obj;
        }
    }
}
