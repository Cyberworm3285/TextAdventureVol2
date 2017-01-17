using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TextAdventureVol2.Types.Classes;
using TextAdventureVol2.Types.Enums;
using TextAdventureVol2.EntityManaging;

namespace TextAdventureVol2.Character
{
    static class CharacterData
    {
        private static List<Item> inventory = new List<Item>()
        {
            (Item)EntityLibrary.GetEntityByID("dummy_001"),
            (Item)EntityLibrary.GetEntityByID("dummy_002"),
        };

        public static void AddToInventory(Item i)
        {
            inventory.Add(i);
        }

        public static void RemoveFromInventory(Item i)
        {
            inventory.Remove(i);
        }

        public static void RemoveFromInventory(string item_ID, CallType type)
        {
            switch (type)
            {
                case CallType.ByID:
                    inventory.RemoveAll(i => i.ID == item_ID);
                    break;
                case CallType.ByRefID:
                    inventory.RemoveAll(i => i.RefID == item_ID);
                    break;
            }
        }

        #region

        public static List<Item> Inventory
        {
            get
            {
                return inventory;
            }
        }

        #endregion
    }
}
