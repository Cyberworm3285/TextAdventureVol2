using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TextAdventureVol2.Access;
using TextAdventureVol2.ExtensionMethods.Primitive;
using TextAdventureVol2.Types.Exceptions;

namespace TextAdventureVol2
{
    class Program
    {
        static void Main(string[] args)
        {
            Access.Access.Init();
            while (true)
            {
                try { Access.Access.Interpret(Console.ReadLine()).PrintStrings(); }
                catch (ValidationException) { Console.WriteLine("[ERROR:INVALID INPUT TRY 'help>all']"); }
            }
        }
    }
}
