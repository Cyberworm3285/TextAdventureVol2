using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventureVol2.Types.Classes
{
    class Command
    {
        private string command;
        private Arg[] args;

        public List<string> PrintCommand(string indent = "", bool last = true)
        {
            List<string> result = new List<string>() { indent };
            result[0] += (this.CommandString);
            if (args.Length == 0) result[0] += "[END]";
            else
            {
                for (int i = 0; i < args.Length; i++)
                {
                    result.AddRange((args[i] ?? Arg.NullRepArg).PrintPretty(indent, i == args.Length - 1));
                }
            }
            return result;
        }

        #region Properties

        public string CommandString
        {
            get
            {
                return command;
            }
            set
            {
                command = value;
            }
        }

        public Arg[] Args
        {
            get
            {
                return args;
            }
            set
            {
                args = value;
            }
        }

        #endregion
    }
}
