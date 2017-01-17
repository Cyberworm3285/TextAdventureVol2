using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TextAdventureVol2.Types.Classes;

namespace TextAdventureVol2.Quests
{
    static class QuestLibrary
    {
        private static Quest[] quests = new Quest[]
        {
            new Quest
            {
                ID = "Quest",
                Name = "Quest",
                QuestRewards = new string[0],
                Active = true
            }
        };

        #region

        public static Quest[] Active
        {
            get
            {
                return Array.FindAll(quests, q => q.Active);
            }
        }

        public static Quest[] Inactive
        {
            get
            {
                return Array.FindAll(quests, q => !q.Active);
            }
        }

        #endregion
    }
}
