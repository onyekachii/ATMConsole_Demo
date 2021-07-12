using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ATM
{
    class Withdrawal
    {
        const decimal minimumBalance = 500;
        public enum AmountToWithdraw
        {
            N1000,
            N2000,
            N5000,
            N10000,
            Other
        }
        private static string WithdrawalTransactionStart(string userInputVar)
        {
            switch (userInputVar)
            {
                case "0":

                    return "1000";
                case "1":
                    return "2000";
                case "2":
                    return "5000";
                case "3":
                    return "10000";
                default:
                    Regex userInputVarRegex = new Regex(@"\D+");
                    Match userInputVarMatch = userInputVarRegex.Match(userInputVar);
                    if (userInputVarMatch.Success)
                    {
                        Console.WriteLine($"\nPlease enter a valid Amount");
                        Run();
                    }
                    Console.WriteLine($"Please enter amount");
                    var newUserInput = Console.ReadLine();
                    return newUserInput;
            }
        }

        private static void CheckBalance(string denominationVar, string amountVar)
        {
            decimal withdrawableAmount = User.accountBalance - minimumBalance;

            if (withdrawableAmount < Convert.ToDecimal(amountVar))
            {
                Console.WriteLine($"Insufficient Balance. Your Balance is {User.accountBalance}");
                Transaction.Run();
            }
            else
            {
                Print(denominationVar, amountVar);
            }

        }

        private static void Print(string denominationVar, string amountVar)
        {
            if (denominationVar == "1")
            {
                decimal a = Convert.ToDecimal(amountVar);

                if (a <= Transaction.TotalSumOf500NairaDenomination)
                {
                    if (a % 1000 == 0)
                    {
                        Console.WriteLine($"Withdrawing N{a}, collect your cash");
                        var newBalance = User.accountBalance - a;
                        User.accountBalance = newBalance;
                        Console.WriteLine($"\nYour balance is {User.accountBalance}");
                    }
                }

            }
            else if (denominationVar == "2")
            {
                decimal a = Convert.ToDecimal(amountVar);

                if (a <= Transaction.TotalSumOf500NairaDenomination)
                {
                    if (a % 1000 == 0)
                    {
                        Console.WriteLine($"Withdrawing N{a}, collect your cash");
                        var newBalance = User.accountBalance - a;
                        User.accountBalance = newBalance;
                        Console.WriteLine($"\nYour balance is {User.accountBalance}");
                    }
                }

            }
            else
            {
                Console.WriteLine("Invalid Input");

            }
            Transaction.Run();
        }
        public static void Run()
        {
            var WithdrawalMenu = new StringBuilder();
            WithdrawalMenu.AppendLine("\nPlease select your prefered amount:");
            WithdrawalMenu.AppendLine(" 0: N1,000\n 1: N2,000\n 2: N5,000\n 3: N10,000\n 4:Other");
            Console.WriteLine(WithdrawalMenu.ToString());
            var userInput = Console.ReadLine();

            var amount = WithdrawalTransactionStart(userInput);

            Console.WriteLine($"\nSelect Denomination:\n 1: N500\n 2: N1000");
            var denomination = Console.ReadLine();
            CheckBalance(denomination, amount);
        }
    }
}