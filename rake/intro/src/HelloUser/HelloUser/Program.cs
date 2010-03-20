using System;
using HelloUserLibrary;

namespace HelloUser
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length == 0)
            {
                ShowUsage();
                return;
            }

            try
            {
                Console.WriteLine(new Input(args[0]).Response);                
            }
            catch(OnlyNumericInputException onie)
            {
                Console.WriteLine(onie.Message);
            }
        }

        private static void ShowUsage()
        {
            Console.WriteLine("Need at least one parameter, preferably a name");
        }
    }
}
