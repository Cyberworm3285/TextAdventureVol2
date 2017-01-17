using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TextAdventureVol2.Tools;
using TextAdventureVol2.Types.Classes;
using TextAdventureVol2.Types.Exceptions;
using TextAdventureVol2.ExtensionMethods.Generic;

namespace TextAdventureVol2.Commands
{
    class CommandInterpreter
    {
        private static CommandInterpreter instance;
        private static char commandArgSplitChar = '>';
        private static char commandSplitChar = '-';

        #region Properties

        public static CommandInterpreter Instance
        {
            get
            {
                return instance ?? (instance = new CommandInterpreter());
            }
        }

        #endregion

        #region Methods

        public List<string> Interpret(string rawCommand)
        {
            List<string> result = new List<string>();

            string[] commands = rawCommand.ToUpper().Split(commandSplitChar);
            string[][] fullCommands = new string[commands.Length][];
            for (int i = 0; i < commands.Length; i++)
            {
                fullCommands[i] = commands[i].Split(commandArgSplitChar);
                result.AddRange(RunAndValidate(fullCommands[i].First(), fullCommands[i].Skip(1).ToArray()));
            }
            return result;
        }

        private List<string> RunAndValidate(string commandName, string[] args)
        {
            Command command = Dicts.CommandsByName.GetValue<string, Command>(commandName);
            Arg tempArg = RunAndValidate(command, args);
            return Dicts.CommandMethodsByName.GetValue<string, CommandMethod>(tempArg.MethodToken)(tempArg);
        }

        private Arg RunAndValidate(Command command, string[] args)
        {
            if (args.Length == 0)
                throw new ValidationException("no arguments were transferred");
            bool okay = true;
            Queue<string> entityArgs = new Queue<string>();
            Arg result = null;
            if (command == null) okay = false;
            Arg[] currArgs = command.Args;
            for (int i = 0; i < args.Length; i++)
            {
                Arg temp;
                if (args[i].StartsWith("$") && Array.Exists(currArgs, a => a.Content.StartsWith("$")))
                {
                    temp = result = Array.Find(currArgs, a => a.Content.ToUpper().StartsWith("$"));
                    entityArgs.Enqueue(args[i]);
                    currArgs = temp.Children;
                }
                else
                {
                    temp = result = Array.Find(currArgs, a => a.Content.ToUpper() == args[i]);
                    if (temp == null)
                    {
                        okay = false;
                        break;
                    }
                    currArgs = temp.Children;
                }
            }
            if (entityArgs.Count != 0)
                result.OptionalEntityArgs = entityArgs;
            if (okay && (currArgs.Length == 0 || currArgs.Contains(null))) return result;
            else throw new ValidationException("[Validation Error]", typeof(Command));
        }

        public static List<string> SetCASC(char newChar)
        {
            commandArgSplitChar = newChar;
            return new List<string>() { "CASC set to: " + newChar };
        }

        public static List<string> SetCSC(char newChar)
        {
            commandSplitChar = newChar;
            return new List<string>() { "CSC set to: " + newChar };
        }

        #endregion
    }
}
