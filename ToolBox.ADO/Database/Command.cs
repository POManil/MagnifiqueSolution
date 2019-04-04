using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolBox.ADO.Database
{
   public class Command
   {
      public readonly string _Query;
      public Dictionary<string,object> _Parameters;

      public Command(string query)
      {
         if (string.IsNullOrWhiteSpace(query))
            throw new ArgumentException();
         _Query = query;
         _Parameters = new Dictionary<string, object>();
      }

      public void AddParameter(string key, object value)
      {
         _Parameters.Add(key, value ?? DBNull.Value);
      }
   }
}
