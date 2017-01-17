using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventureVol2.Tools
{
    static class RefID_Provider
    {
        private static int currID = 1;
        private const int ID_LENGTH = 6;

        #region Properties

        public static string CurrID
        {
            get
            {
                string s = currID.ToString();
                currID++;
                return new string('0', ID_LENGTH - s.Length) + s;
            }
        }

        #endregion
    }
}
