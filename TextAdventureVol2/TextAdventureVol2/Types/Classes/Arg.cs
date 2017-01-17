using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TextAdventureVol2.Types.Enums;

namespace TextAdventureVol2.Types.Classes
{
    public class Arg
    {
        private Arg[] children;
        private static Arg nullRepArg = new Arg { Content = "", Children = new Arg[0] };
        private string content;
        private string methodToken;
        private string[] methodArgs;
        private Queue<string> optionalEntityArgs;

        public List<string> PrintPretty(string indent, bool last)
        {
            List<string> result = new List<string>() { indent };
            if (last)
            {
                result[0] += "└─";
                indent += "  ";
            }
            else
            {
                result[0] += "├─";
                indent += "│ ";
            }
            result[0] += (this.Content);

            if (children.Length == 0)
            {
                result[0] += "[END]";
            }
            else
            {
                for (int i = 0; i < children.Length; i++)
                {
                    result.AddRange((children[i] ?? nullRepArg).PrintPretty(indent, i == children.Length - 1));
                }
            }
            return result;
        }

        #region Properties

        public String Content
        {
            get
            {
                return content;
            }
            set
            {
                content = value;
            }
        }

        public Arg[] Children
        {
            get
            {
                return children;
            }
            set
            {
                children = value;
            }
        }

        public static Arg NullRepArg
        {
            get
            {
                return nullRepArg;
            }
        }

        public string MethodToken
        {
            get
            {
                return methodToken;
            }
            set
            {
                methodToken = value;
            }
        }

        public string[] MethodArgs
        {
            get
            {
                return methodArgs;
            }
            set
            {
                methodArgs = value;
            }
        }

        public Queue<string> OptionalEntityArgs
        {
            get
            {
                return optionalEntityArgs;
            }
            set
            {
                optionalEntityArgs = value;
            }
        }

        #endregion
    }
}
