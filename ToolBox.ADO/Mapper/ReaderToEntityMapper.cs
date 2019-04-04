using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ToolBox.ADO.Mapper
{
   public static class ReaderToEntityMapper
   {
      public static T ReaderTo<T>(this IDataReader reader)
         where T : class, new()
      {
             
         T result = Activator.CreateInstance<T>();
         PropertyInfo[] properties = typeof(T).GetProperties();
         foreach (PropertyInfo prop in properties)
         {
            if (prop.GetCustomAttribute(typeof(IgnoreAttribute)) == null)
            {
               object value = reader[prop.Name] == DBNull.Value ? null : reader[prop.Name];
               if (prop.PropertyType.IsAssignableFrom(value?.GetType()))
               {
                  prop.SetValue(result, value);
               }
            }
         }
         return result;
      }
   }
}
