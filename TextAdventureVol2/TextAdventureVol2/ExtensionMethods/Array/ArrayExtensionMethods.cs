using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TextAdventureVol2.Commands;
using TextAdventureVol2.ExtensionMethods.Other;

namespace TextAdventureVol2.ExtensionMethods.Array
{
    public static class ArrayExtensionMethods
    {
        public static string[] ToStrings(this CommandMethod[] methods)
        {
            string[] result = new string[methods.Length];
            for (int i = 0; i < methods.Length; i++)
            {
                result[i] = methods[i].ToMethodString();
            }
            return result;
        }
    }
}
