using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TextAdventureVol2.Tools;
using TextAdventureVol2.Commands;

namespace TextAdventureVol2.Access
{
    static class Access
    {
        public static void Init()
        {
            Dicts.InitArgDict(CommandLibrary.Commands);
            Dicts.InitCommandDict(CommandLibrary.CommandMethods, CommandLibrary.CommandMethodsTokens);
            CommandLibrary.Validate();
        }

        public static List<string> Interpret(string command)
        {
            return CommandInterpreter.Instance.Interpret(command);
        }
    }
}
