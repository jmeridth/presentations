using System;

namespace HelloUserLibrary
{
    public class OnlyNumericInputException : Exception
    {
        public OnlyNumericInputException() : base("Input must be alpha numeric, preferably a name") { }
        public OnlyNumericInputException(string message) : base(message){}
    }
}
