using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventureVol2.ExtensionMethods.Generic
{
    public static class GenericExtensionMethods
    {
        public static TValue GetValue<TKey, TValue> (this Dictionary<TKey, TValue> dict, TKey key, TValue error = default(TValue))
        {
            try
            {
                TValue result;
                dict.TryGetValue(key, out result);
                return result;
            }
            catch (Exception)
            {
                return error;
            }
        }
    }
}
