using System;
namespace JackpotMachine
{
    class Program
    {
        static void Main()
        {
            string roll = "no";
            while  (roll == "no")
            {
            Console.Clear();
            Console.WriteLine("Hello Player, are you ready to be rich or poor, your luck decides 💎");
            Console.WriteLine("Do you want to roll? (yes/no)");
            roll = Console.ReadLine();
            if (roll != "yes"  && roll != "no")
            {
                roll = "no";
            }
            else if (roll == "yes") {
                rollmachine();
            };
            };
        }
        static void rollmachine()
        {
            Console.WriteLine("Rolling Done! ✨");
        }
    }
}