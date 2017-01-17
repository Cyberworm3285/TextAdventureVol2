using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventureVol2.ExtensionMethods.Primitive
{
    static class PrimitiveExtensionMethods
    {
        public static void PrintStrings(this List<String> strings)
        {
            foreach (string s in strings) Console.WriteLine(s);
        }
    }
}
