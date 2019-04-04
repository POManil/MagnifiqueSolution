using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolBox.ADO.Mapper
{
   [AttributeUsage(AttributeTargets.Property)]
   public class IgnoreAttribute : Attribute
   {
   }
}
