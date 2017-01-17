using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventureVol2.Types.Exceptions
{
    public class UnevenArrayLengthsException : Exception
    {
        public UnevenArrayLengthsException(string message, int length_a, int length_b) 
            : base(message + " [" + length_a + ";" + length_b + "]") { }

        public UnevenArrayLengthsException(string message) 
            : base(message) { }

        public UnevenArrayLengthsException() 
            : base() { }
    }

    public class ValidationException : Exception
    {
        public ValidationException(string message, Type type) 
            : base(message + " (thrown during validation of " + type.Name + ")") { }

        public ValidationException(string message)
            : base(message) { }

        public ValidationException()
            :base() { }
    }

    public class CombiningMismatchException : Exception
    {
        public CombiningMismatchException(string message, string id1, string id2) 
            : base(message + " (ID1:" + id1 + ";ID2:" + id2 + ")") { }

        public CombiningMismatchException(string message)
            : base(message) { }

        public CombiningMismatchException()
            : base() { }
    }
}
