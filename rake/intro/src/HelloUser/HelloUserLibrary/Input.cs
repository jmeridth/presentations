using System;
using System.Text.RegularExpressions;

namespace HelloUserLibrary
{
    public class Input
    {
        private readonly string input;

        public Input(string input)
        {
            validate(input);
            this.input = input;            
        }

        public string Response
        {
            get { return String.Format("Welcome to the dark side {0}.  Come learn the art of Rake.", input); }
        }

        private void validate(string input)
        {
            if (Regex.Match(input, "^[0-9]+$").Success) throw new OnlyNumericInputException("Input must be alpha numeric, preferably a name");
        }
    }
}
