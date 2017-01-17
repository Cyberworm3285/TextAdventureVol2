using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventureVol2.Types.Classes
{
    class Quest
    {
        private string id;
        private string name;
        private string[] questRewards;
        private bool active;

        #region Properties

        public string ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        } 

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string[] QuestRewards
        {
            get
            {
                return questRewards;
            }
            set
            {
                questRewards = value;
            }
        }

        public bool Active
        {
            get
            {
                return active;
            }
            set
            {
                active = value;
            }
        }

        #endregion
    }
}
