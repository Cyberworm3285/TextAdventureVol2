using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventureVol2.Types.Classes
{
    class Item : Entity
    {
        private string[] combinableWithIDs;
        private string combinableToID;
        private string description;
        private bool isQuestItem;

        #region

        public string[] CombinabelWithIDs
        {
            get
            {
                return combinableWithIDs;
            }
            set
            {
                combinableWithIDs = value;
            }
        }

        public string CombinableToID
        {
            get
            {
                return combinableToID;
            }
            set
            {
                combinableToID = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }

        public bool IsQuestItem
        {
            get
            {
                return isQuestItem;
            }
            set
            {
                isQuestItem = value;
            }
        }

        #endregion
    }
}
