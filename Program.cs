using System;
using System.Formats.Asn1;
namespace JackpotMachine
{
    class Program
    {
        static void Main()
        {
            Console.Clear();
            Console.Write("What is your first wallet: ");
            float wallet = float.Parse(Console.ReadLine());
            Main2(wallet);
        }
        static void Main2(float wallet)
        {
            string roll = rollquestion(wallet);
            switch(roll) {
                case "yes":
                    Console.Clear();
                    Random random = new Random();
                    int n1 = random.Next(1,7);
                    int n2 = random.Next(1,7);
                    int n3 = random.Next(1,7);
                    string result1 = rollmachine(n1);
                    string result2 = rollmachine(n2);
                    string result3 = rollmachine(n3);
                    Console.Write("What is you bet: ");
                    float bet = float.Parse(Console.ReadLine());
                    Console.WriteLine($"Number 1: {result1} \nNumber 2: {result2} \nNumber 3: {result3}");
                    wallet = wallet + award_analysis(result1, result2, result3, bet);
                    Console.WriteLine($"Wallet: {wallet} Coins");
                    Console.ReadLine();
                    Main2(wallet);
                    break;
                case "no":
                    exitcommand(wallet);
                    break;
                case "exit":
                    exitcommand(wallet);
                    break;
                default:
                    Main2(wallet);
                    break;
            };
        }
        static string rollmachine(int valor)
        {
            string result = "";
            switch (valor) {
                case 1:
                    result = "🍒";
                    break;
                case 2:
                    result = "⭐";
                    break;
                case 3:
                    result = "🍋";
                    break;
                case 4:
                    result = "🍉";
                    break;
                case 5:
                    result = "🔔";
                    break;
                case 6:
                    result = "7️⃣";
                    break;
            }
            return result;
        }
        static string rollquestion(float wallet)
        {
            Console.Clear();
            Console.WriteLine("Hello Player, are you ready to be rich or poor, your luck decides 💎");
            Console.WriteLine($"Current Wallet: {wallet} Coins");
            Console.WriteLine("Do you want to roll? (yes/no/exit)");
            return Console.ReadLine();
        }
        static void exitcommand(float wallet)
        {
            Console.Clear();
            Console.WriteLine("Do you want to stop the game? (yes/no)");
            string continuevar = Console.ReadLine();
            switch(continuevar) {
                case "no":
                    Main2(wallet);
                    break;
                case "yes":
                    Console.Clear();
                    Console.WriteLine("See you soon player!!");
                    Console.ReadLine();
                    Environment.Exit(0);
                    break;
                default:
                    Main2(wallet);
                    break;
            }
        }
        static float award_analysis(string r1, string r2, string r3, float bet)
        {
        float award = 0;
        if (r1 == r2 & r2 == r3){
            if (r1 == "7️⃣"){
                award = bet*10;
                Console.WriteLine("JACKPOT GREAT!! +1000 Coins 🤑");
            }else{
                award = bet*5;
            }
        }else if (r1 == r2 || r1 == r3 || r2 == r3) {
            award = bet*2;
        }else {
            award = bet*0;
        }
        return award - bet;
        }
    }
}