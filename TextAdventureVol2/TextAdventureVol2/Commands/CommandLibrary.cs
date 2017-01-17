using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TextAdventureVol2.Types.Classes;
using TextAdventureVol2.Types.Exceptions;
using TextAdventureVol2.EntityManaging;
using TextAdventureVol2.Character;
using TextAdventureVol2.Quests;
using TextAdventureVol2.ExtensionMethods.Array;
using System.Reflection;

namespace TextAdventureVol2.Commands
{
    public delegate List<string> CommandMethod(Arg lastArg);

    static class CommandLibrary
    {
        #region Commands
        private static Command[] allCommands = new Command[]
        {
            new Command
            {
                CommandString = "get",
                Args = new Arg[]
                {
                    new Arg
                    {
                        Content = "inventory",
                        MethodToken = NameOf(GetInventory),
                        MethodArgs = new string[0],
                        Children = new Arg[]
                        {
                            new Arg
                            {
                                Content = "quest-items",
                                MethodToken = NameOf(GetInventory),
                                MethodArgs = new string[] { "quest-items" },
                                Children = new Arg[]
                                {
                                    new Arg
                                    {
                                        Content = "detailed",
                                        MethodToken = NameOf(GetInventory),
                                        MethodArgs = new string[] { "quest-items", "detailed" },
                                        Children = new Arg[0]
                                    },
                                    null
                                }
                            },
                            new Arg
                            {
                                Content = "detailed",
                                MethodToken = NameOf(GetInventory),
                                MethodArgs = new string[] { "detailed" },
                                Children = new Arg[0]
                            },
                            null
                        }
                    },
                    new Arg
                    {
                        Content = "quests",
                        MethodToken = NameOf(GetQuest),
                        MethodArgs = new string[0],
                        Children = new Arg[]
                        {
                            new Arg
                            {
                                Content = "active",
                                MethodToken = NameOf(GetQuest),
                                MethodArgs = new string[] { "active" },
                                Children = new Arg[0]
                            },
                            new Arg
                            {
                                Content = "inactive",
                                MethodToken = NameOf(GetQuest),
                                MethodArgs = new string[] { "inactive" },
                                Children = new Arg[0]
                            }
                        }
                    }
                }
            },
            new Command
            {
                CommandString = "set",
                Args = new Arg[]
                {
                    new Arg
                    {
                        Content = "CSC",
                        Children = new Arg[] 
                        {
                            new Arg
                            {
                                Content = "$new-CSC",
                                MethodToken = NameOf(SetCSC),
                                MethodArgs = new string[] {},
                                Children = new Arg[] {}
                            }
                        },
                    },
                    new Arg
                    {
                        Content = "CASC",
                        Children = new Arg[]
                        {
                            new Arg
                            {
                                Content = "$new-CASC",
                                MethodToken = NameOf(SetCASC),
                                MethodArgs = new string[] {},
                                Children = new Arg[] {}
                            }
                        }
                    }
                }
            },
            new Command
            {
                CommandString = "help",
                Args = new Arg[]
                {
                    new Arg
                    {
                        Content = "all",
                        MethodToken = NameOf(Help),
                        MethodArgs = new string[] { "all" },
                        Children = new Arg[0]
                    },
                    new Arg
                    {
                        Content = "$command-name",
                        MethodToken = NameOf(Help),
                        MethodArgs = new string[] { "$" },
                        Children = new Arg[0]
                    }
                }
            },
            new Command
            {
                CommandString = "look",
                Args = new Arg[]
                {
                    new Arg
                    {
                        Content = "at",
                        Children = new Arg[]
                        {
                            new Arg
                            {
                                Content = "$entity-name",
                                MethodToken = "TODO",
                                MethodArgs = new string[] { "$" },
                                Children = new Arg[0]
                            }
                        }
                    },
                    new Arg
                    {
                        Content = "around",
                        MethodToken = "TODO",
                        MethodArgs = new string[] { "around" },
                        Children = new Arg[0]
                    }
                }
            },
            new Command
            {
                CommandString = "Print",
                Args = new Arg[]
                {
                    new Arg
                    {
                        Content = "RefIDs",
                        MethodToken = NameOf(PrintRefIDs),
                        MethodArgs = new string[0],
                        Children = new Arg[0]
                    }
                }
            },
            new Command
            {
                CommandString = "combine",
                Args = new Arg[]
                {
                    new Arg
                    {
                        Content = "$item-name",
                        Children = new Arg[] 
                        {
                            new Arg
                            {
                                Content = "$item-name",
                                MethodArgs = new string[0],
                                MethodToken = NameOf(Combine),
                                Children = new Arg[0]
                            }
                        }
                    }
                }
            }
        };
        #endregion

        private static CommandMethod[] commandMethods = new CommandMethod[]
        {
            PrintRefIDs,
            GetInventory,
            Help,
            Combine,
            GetQuest,
            SetCSC,
            SetCASC,
        };

        private static MethodInfo[] methodInfos = typeof(CommandLibrary).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.ReturnType == typeof(List<string>)).ToArray(); 

        private static string NameOf(this CommandMethod method)
        {
            return method.Method.Name.ToUpper();
        }

        private static string[] commandMethodsTokens = commandMethods.ToStrings();

        public static void Validate()
        {
            foreach (Command c in allCommands)
            {
                ValidateCommand(c);
            }
        }

        private static void ValidateCommand(Command c)
        {
            foreach (Arg a in c.Args) ValidateArg(a);
        }

        private static void ValidateArg(Arg a)
        {
            if (a == null) return;
            if (a.Content == "" ||
                (a.Children.Length == 0 && a.MethodToken == null) ||
                a.Children.Contains(null) && a.MethodToken == null)
                throw new ValidationException("", typeof(CommandLibrary));
            foreach (Arg aa in a.Children) ValidateArg(aa);
        }

        #region Command Implementations

        public static List<string> PrintRefIDs(Arg lastArg)
        {
            List<string> result = new List<string>();

            for (int i = 0; i < EntityLibrary.EntityCount; i++)
            {
                Entity e = EntityLibrary.GteEntityByIndex(i);
                result.Add(e.Name + " " + e.RefID);
            }

            return result;
        }
        public static List<string> GetInventory(Arg lastArg)
        {
            List<string> result = new List<string>();

            switch (lastArg.MethodArgs.Length)
            {
                case 0:
                    foreach (Item i in CharacterData.Inventory) result.Add(i.Name);
                    break;
                case 1:
                    switch (lastArg.MethodArgs[0])
                    {
                        case "detailed":
                            foreach (Item i in CharacterData.Inventory) result.Add(i.Name + " Ref:" + i.RefID + " ID:" + i.ID);
                            break;
                        case "quest-items":
                            foreach (Item i in CharacterData.Inventory)
                                if (i.IsQuestItem) result.Add(i.Name); 
                            break;
                    }
                    break;
                case 2:
                    switch (lastArg.MethodArgs[0] + ";" + lastArg.MethodArgs[1])
                    {
                        case "quest-items;detailed":
                            foreach (Item i in CharacterData.Inventory)
                                if (i.IsQuestItem) result.Add(i.Name + " Ref:" + i.RefID + " ID:" + i.ID);
                            break;
                    }
                    break;
            }

            return result;
        }
        public static List<string> GetQuest(Arg lastArg)
        {
            List<string> result = new List<string>();

            switch (lastArg.MethodArgs[0])
            {
                case "active":
                    foreach (Quest q in QuestLibrary.Active) result.Add(q.Name);
                    break;
                case "inactive":
                    foreach (Quest q in QuestLibrary.Inactive) result.Add(q.Name);
                    break;
            }

            return result;
        }
        public static List<string> Help(Arg lastArg)
        {
            List<string> result = new List<string>();

            switch (lastArg.MethodArgs[0])
            {
                case "all":
                    foreach (Command c in allCommands) result.AddRange(c.PrintCommand());
                    break;
                case "$":
                    string arg = lastArg.OptionalEntityArgs.Dequeue().Remove(0,1);
                    result.AddRange(Array.Find(allCommands, c => c.CommandString == arg).PrintCommand());
                    break;
            }

            return result;
        }
        public static List<string> Combine(Arg lastArg)
        {
            List<string> result = new List<string>();

            string item1ID = lastArg.OptionalEntityArgs.Dequeue().Remove(0,1);
            string item2ID = lastArg.OptionalEntityArgs.Dequeue().Remove(0,1);

            Item item1 = EntityLibrary.GetEntityByID(item1ID) as Item;
            Item item2 = EntityLibrary.GetEntityByID(item2ID) as Item;

            if (item1 == null) item1 = EntityLibrary.GetEntityByName(item1ID) as Item;
            if (item2 == null) item2 = EntityLibrary.GetEntityByName(item2ID) as Item;

            if (item1 == null || item2 == null)
            {
                result.Add("one or both items not found");
                return result;
            }

            if (item1.CombinabelWithIDs.Contains(item2.ID) &&
                item2.CombinabelWithIDs.Contains(item1.ID) &&
                item1.CombinableToID == item2.CombinableToID)
            {
                Item newItem = EntityLibrary.GetEntityByID(item1.CombinableToID) as Item;
                CharacterData.RemoveFromInventory(item1);
                CharacterData.RemoveFromInventory(item2);
                CharacterData.AddToInventory(newItem);
                result.AddRange(new string[] { "removed: " + item1.Name, "removed: " + item2.Name, "added: " + newItem.Name });
            }
            else
            {
                throw new CombiningMismatchException("[Combination failed]", item1ID, item2ID);
            }
            return result;
        }
        public static List<string> SetCSC(Arg lastArg)
        {
            string arg = lastArg.OptionalEntityArgs.Dequeue().Remove(0, 1);
            return CommandInterpreter.SetCSC(arg[0]);
        }
        public static List<string> SetCASC(Arg lastArg)
        {
            string arg = lastArg.OptionalEntityArgs.Dequeue().Remove(0, 1);
            return CommandInterpreter.SetCASC(arg[0]);
        }

        #endregion

        #region Properties

        public static Command[] Commands
        {
            get
            {
                return allCommands;
            }
        }

        public static CommandMethod[] CommandMethods
        {
            get
            {
                return commandMethods;
            }
        }

        public static string[] CommandMethodsTokens
        {
            get
            {
                return commandMethodsTokens;
            }
        }

        #endregion
    }
}
