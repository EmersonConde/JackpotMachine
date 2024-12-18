using System;
using System.Formats.Asn1;
namespace JackpotMachine
{
    using MySql.Data.MySqlClient;

    public class BancoDeDados
    {
        private string connectionString = "Server=127.0.0.1;Database=jackpot_DB;Uid=root;Pwd=;";

        public void InserirResultado(float bet, float award, string playerid)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO results (playerid, bet, award) VALUES (@playerid, @bet, @award)";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@bet", bet);
                        command.Parameters.AddWithValue("@award", award);
                        command.Parameters.AddWithValue("@playerid", playerid);
                        command.ExecuteNonQuery();
                    }
                }
                catch (MySqlException ex)
                {
                    // Trate exceções relacionadas ao MySQL aqui
                    Console.WriteLine("Erro: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Console.Clear();
            Console.Write("What's your name player: ");
            string playerid = Console.ReadLine();
            Console.Write("Insert Your Coins: ");
            float wallet = float.Parse(Console.ReadLine());
            Main2(wallet, playerid);
        }
        static void Main2(float wallet, string playerid)
        {
            string roll = rollquestion(wallet, playerid);
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
                    wallet = wallet + award_analysis(result1, result2, result3, bet, playerid);
                    Console.WriteLine($"Wallet: {wallet} Coins");
                    Console.ReadLine();
                    Main2(wallet, playerid);
                    break;
                case "no":
                    exitcommand(wallet, playerid);
                    break;
                case "exit":
                    exitcommand(wallet, playerid);
                    break;
                default:
                    Main2(wallet, playerid);
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
        static string rollquestion(float wallet, string playerid)
        {
            Console.Clear();
            Console.WriteLine($"Are you ready to be rich or poor {playerid}, your luck decides 💎");
            Console.WriteLine($"Current Wallet: {wallet} Coins");
            Console.WriteLine("Do you want to roll? (yes/no/exit)");
            return Console.ReadLine();
        }
        static void exitcommand(float wallet, string playerid)
        {
            Console.Clear();
            Console.WriteLine("Do you want to stop the game? (yes/no)");
            string continuevar = Console.ReadLine();
            switch(continuevar) {
                case "no":
                    Main2(wallet, playerid);
                    break;
                case "yes":
                    Console.Clear();
                    Console.WriteLine("See you soon player!!");
                    Console.ReadLine();
                    Environment.Exit(0);
                    break;
                default:
                    Main2(wallet, playerid);
                    break;
            }
        }
        static float award_analysis(string r1, string r2, string r3, float bet, string playerid)
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
        BancoDeDados banco = new BancoDeDados();
        banco.InserirResultado(bet, award, playerid);
        return award - bet;
        }
    }
}