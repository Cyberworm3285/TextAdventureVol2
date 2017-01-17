using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using TextAdventureVol2.Commands;

namespace TextAdventureVol2.ExtensionMethods.Other
{
    public static class OtherTypeConversions
    {
        public static string ToMethodString(this CommandMethod method)
        {
            return method.Method.Name.ToUpper();
        }
    }
}
