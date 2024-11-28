using System;
using System.Formats.Asn1;
namespace JackpotMachine
{
    class Program
    {
        static void Main()
        {
            string roll = rollquestion();
            switch(roll) {
                case "yes":
                    rollmachine();
                    break;
                case "no":
                    exitcommand();
                    break;
                case "exit":
                    exitcommand();
                    break;
                default:
                    Main();
                    break;
            };
        }
        static void rollmachine()
        {
            Console.Clear();
            Console.WriteLine("Rolling Done! ✨");
            Console.ReadLine();
            Main();
        }
        static string rollquestion()
        {
            Console.Clear();
            Console.WriteLine("Hello Player, are you ready to be rich or poor, your luck decides 💎");
            Console.WriteLine("Do you want to roll? (yes/no/exit)");
            return Console.ReadLine();
        }
        static void exitcommand()
        {
            Console.Clear();
            Console.WriteLine("Do you want to stop the game? (yes/no)");
            string continuevar = Console.ReadLine();
            switch(continuevar) {
                case "no":
                    Main();
                    break;
                case "yes":
                    Console.Clear();
                    Console.WriteLine("See you soon player!!");
                    Console.ReadLine();
                    Environment.Exit(0);
                    break;
                default:
                    Main();
                    break;
            }
        }
    }
}