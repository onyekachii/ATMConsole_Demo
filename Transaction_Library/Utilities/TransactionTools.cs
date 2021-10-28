using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transaction_Library.Utilities
{
    public static class TransactionTools
    {
        internal static void TransactionOptions(string language, User user)
        {
            switch (language)
            {
                case "English":
                    var transactMenu = new StringBuilder();
                    transactMenu.AppendLine("\nPlease choose an option:");
                    transactMenu.AppendLine(" 1: Check Balance\n 2: Withdraw\n 3: End Transaction");
                    Console.WriteLine(transactMenu.ToString());

                    string userInput = Console.ReadLine();
                    TransactionFunction(userInput, language, user);
                    break;
                
                case "Pigin":
                    transactMenu = new StringBuilder();
                    transactMenu.AppendLine("\nMake you choose one option");
                    transactMenu.AppendLine("1: Check Balance\n 2: Withdraw\n 3: End Transaction");
                    Console.WriteLine(transactMenu.ToString());

                    userInput = Console.ReadLine();
                    TransactionFunction(userInput, language, user);
                    break;
            }
        }

        private static void TransactionFunction(string userInput, string language, User user)
        {
            switch (userInput)
            {
                case "1":
                    CheckBalance(user, language);
                    break;
                case "2":
                    WithdrawalMenu.Run();
                    break;
                case "3":
                    EndTransaction();
                    break;
                default:
                    switch (b)
                    {
                        case "English":
                            Console.WriteLine("Input appropriate value please");
                            break;
                        case "Hausa":
                        case "Igbo":
                        case "Yoruba":
                            Console.WriteLine("Shigar da darajar da ta dace don Allah");
                            break;
                    }
                    Run();
                    break;
            }
        }

        private static void CheckBalance(User user, string language)
        {
            Console.WriteLine($"{user.Balance}\nPress any key and enter to go back");
            Console.ReadLine();
            TransactionOptions(language, user);
        }

        public static void EndTransaction()
        {
            Console.WriteLine("\nTransaction Terminated.\n Thank you for banking with Us.");
            Application.Run();
        }
    }
}
