using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TextAdventureVol2.Types.Classes;
using TextAdventureVol2.Tools;

namespace TextAdventureVol2.EntityManaging
{
    static class EntityLibrary
    {
        private static Entity[] entities = new Entity[]
        {
            new Item
            {
                CombinabelWithIDs = new string[] { "dummy_002" },
                CombinableToID = "dummy_003",
                Description = "dummy item zum dummy sein",
                ID = "dummy_001",
                IsQuestItem = true,
                Name = "dummy-Item",
                RefID = RefID_Provider.CurrID,
            },
            new Item
            {
                CombinabelWithIDs = new string[] { "dummy_001" },
                CombinableToID = "dummy_003",
                Description = "blaaaa",
                ID = "dummy_002",
                IsQuestItem = false,
                Name = "dummy_002",
                RefID = RefID_Provider.CurrID,
            },
            new Item
            {
                CombinabelWithIDs = new string[0],
                CombinableToID = null,
                Description = "blaaaauashdhas",
                ID = "dummy_003",
                IsQuestItem = false,
                Name = "dummy_003",
                RefID = RefID_Provider.CurrID,
            }
        };

        public static Entity GetEntityByID(string id)
        {
            return Array.Find(entities, e => e.ID == id);
        }

        public static Entity GetEntityByName(string name)
        {
            return Array.Find(entities, e => e.Name == name);
        }

        public static Entity GteEntityByIndex(int index)
        {
            return entities[index];
        }

        #region Properties

        public static int EntityCount
        {
            get
            {
                return entities.Length;
            }
        }

        #endregion
    }
}
