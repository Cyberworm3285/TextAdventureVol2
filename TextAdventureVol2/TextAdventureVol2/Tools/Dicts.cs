using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TextAdventureVol2.Types.Classes;
using TextAdventureVol2.Types.Exceptions;
using TextAdventureVol2.Commands;

namespace TextAdventureVol2.Tools
{
    static class Dicts
    {
        private static Dictionary<string, Command> commandsByName;
        private static Dictionary<string, CommandMethod> commandMethodsByName;

        public static void InitArgDict(Command[] commands)
        {
            commandsByName = new Dictionary<string, Command>();
            for (int i = 0; i < commands.Length; i++)
            {
                commandsByName.Add(commands[i].CommandString.ToUpper(), commands[i]);
            }
        }

        public static void InitCommandDict(CommandMethod[] commands, string[] commandsTokens)
        {
            if (commands.Length != commandsTokens.Length)
                throw new UnevenArrayLengthsException("CommandMethods and Tokens mismatch", commands.Length, commandsTokens.Length);
            commandMethodsByName = new Dictionary<string, CommandMethod>();
            for (int i = 0; i < commands.Length; i++)
            {
                commandMethodsByName.Add(commandsTokens[i].ToUpper(), commands[i]);
            }
        }

        #region Properties

        public static Dictionary<string, Command> CommandsByName
        {
            get
            {
                return commandsByName;
            }
        }

        public static Dictionary<string, CommandMethod> CommandMethodsByName
        {
            get
            {
                return commandMethodsByName;
            }
        }

        #endregion
    }
}
