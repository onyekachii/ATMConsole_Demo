using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Console_Application.Utilities
{
    public class TransactionTools
    {
        private static  User _user;

        public TransactionTools(User user)
        {
            _user = user;
        }
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
                    Withdraw(language);
                    break;
                case "3":
                    EndTransaction();
                    break;
                default:
                    switch (language)
                    {
                        case "English":
                            Console.WriteLine("Input appropriate value please");
                            break;                        
                        case "Pigin":
                            Console.WriteLine("Abeg enter correct number");
                            break;
                    }
                    TransactionOptions(language, user);
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

        public static void Withdraw(string language)
        {
            if (language == "English")
            {
                var WithdrawalMenu = new StringBuilder();
                WithdrawalMenu.AppendLine("\nPlease select your prefered amount:");
                WithdrawalMenu.AppendLine(" 0: N1,000\n 1: N2,000\n 2: N5,000\n 3: N10,000\n 4:Other");
                Console.WriteLine(WithdrawalMenu.ToString());
                var userInput = Console.ReadLine();

                WithdrawalTools.StartWithdrawalTransaction(userInput, language);

                Console.WriteLine($"\nSelect Denomination:\n 1: N500\n 2: N1000");
                var denomination = Console.ReadLine();
                WithdrawalTools.CheckBalance(denomination, _user, language);
            }
            else if (language == "Pigin")
            {
                var WithdrawalMenu = new StringBuilder();
                WithdrawalMenu.AppendLine("\nAbeg choose your amount wey you wan withdraw:");
                WithdrawalMenu.AppendLine(" 0: N1,000\n 1: N2,000\n 2: N5,000\n 3: N10,000\n 4:Other");
                Console.WriteLine(WithdrawalMenu.ToString());
                var userInput = Console.ReadLine();

                WithdrawalTools.StartWithdrawalTransaction(userInput, language);

                Console.WriteLine($"\nSelect Denomination:\n 1: N500\n 2: N1000");
                var denomination = Console.ReadLine();
                WithdrawalTools.CheckBalance(denomination, _user, language);
            }
        }
    }
}
