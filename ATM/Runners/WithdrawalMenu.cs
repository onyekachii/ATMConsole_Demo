using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ATM
{
   static class WithdrawalMenu
    {
       public static int amount;
       
        public static void Run()
        {
            var withdrawal = new WithdrawalTransaction();
            withdrawal.IRun(Application.selectedLang);
            
        }

        class WithdrawalTransaction : ILanguageTranslator
        {
            public void IRun(LanguageList data)
            {
                if (Convert.ToString(data) == "English")
                {
                    var WithdrawalMenu = new StringBuilder();
                    WithdrawalMenu.AppendLine("\nPlease select your prefered amount:");
                    WithdrawalMenu.AppendLine(" 0: N1,000\n 1: N2,000\n 2: N5,000\n 3: N10,000\n 4:Other");
                    Console.WriteLine(WithdrawalMenu.ToString());
                    var userInput = Console.ReadLine();

                    WithdrawalTransactionStart(userInput);

                    Console.WriteLine($"\nSelect Denomination:\n 1: N500\n 2: N1000");
                    
                }
                else if (Convert.ToString(data) == "Hausa")
                {
                    var WithdrawalMenu = new StringBuilder();
                    WithdrawalMenu.AppendLine("\nPlease select your prefered amount:");
                    WithdrawalMenu.AppendLine(" 0: N1,000\n 1: N2,000\n 2: N5,000\n 3: N10,000\n 4:Other");
                    Console.WriteLine(WithdrawalMenu.ToString());
                    var userInput = Console.ReadLine();

                    WithdrawalTransactionStart(userInput);

                    Console.WriteLine($"\nSelect Denomination:\n 1: N500\n 2: N1000");                   
                }
                else if (Convert.ToString(data) == "Igbo")
                {
                    var WithdrawalMenu = new StringBuilder();
                    WithdrawalMenu.AppendLine("\nPlease select your prefered amount:");
                    WithdrawalMenu.AppendLine(" 0: N1,000\n 1: N2,000\n 2: N5,000\n 3: N10,000\n 4:Other");
                    Console.WriteLine(WithdrawalMenu.ToString());
                    var userInput = Console.ReadLine();

                    WithdrawalTransactionStart(userInput);

                    Console.WriteLine($"\nSelect Denomination:\n 1: N500\n 2: N1000");                    
                }
                else if (Convert.ToString(data) == "Yoruba")
                {
                    var WithdrawalMenu = new StringBuilder();
                    WithdrawalMenu.AppendLine("\nPlease select your prefered amount:");
                    WithdrawalMenu.AppendLine(" 0: N1,000\n 1: N2,000\n 2: N5,000\n 3: N10,000\n 4:Other");
                    Console.WriteLine(WithdrawalMenu.ToString());
                    var userInput = Console.ReadLine();

                    WithdrawalTransactionStart(userInput);

                    Console.WriteLine($"\nSelect Denomination:\n 1: N500\n 2: N1000");                    
                }
                var denomination = Console.ReadLine();
                BalanceChecker(denomination, amount);
            }
        }
        static void WithdrawalTransactionStart(string userInputVar)
        {
            switch (userInputVar)
            {
                case "0":
                    amount = 1000;
                    break;
                case "1":
                    amount = 2000;
                    break;
                case "2":
                    amount = 5000;
                    break;
                case "3":
                    amount = 10000;
                    break;
                default:
                    Regex userInputVarRegex = new Regex(@"\D+");
                    Match userInputVarMatch = userInputVarRegex.Match(userInputVar);
                    if (userInputVarMatch.Success)
                    {
                        Console.WriteLine($"\nPlease enter a valid option");
                        Run();
                    }
                    Console.WriteLine($"Please enter amount");
                    var newUserInput = Console.ReadLine();
                    amount = Convert.ToInt32(newUserInput);
                    break;
            }
        }


        static void BalanceChecker(string denominationVar, int amountVar)
        {
            decimal withdrawableAmount = User.accountBalance;

            if (withdrawableAmount < Convert.ToDecimal(amountVar))
            {
                Console.WriteLine($"Insufficient Balance. Your Balance is {User.accountBalance}");
                TransactionService.Run();
            }
            else
            {
                Print(denominationVar, amountVar);
            }

        }

        static void Print(string denominationVar, int amountVar)
        {

            if (denominationVar == "1")
            {
                var a = (amountVar);

                if (a <= TransactionService.TotalSumOf500NairaDenomination)
                {
                    if (a % 1000 == 0)
                    {
                        Console.WriteLine($"Withdrawing N{a}, collect your cash");
                        var newBalance = User.accountBalance - a;
                        var newFiveHundredNairaDenomintionBalance = TransactionService.TotalSumOf500NairaDenomination - a;

                        User.accountBalance = newBalance;
                        TransactionService.TotalSumOf500NairaDenomination = newFiveHundredNairaDenomintionBalance;

                        //Console.WriteLine($"\nATM has N{TransactionService.TotalATMAmount}, N500 notes: {TransactionService.TotalSumOf500NairaDenomination}, N1000 notes: {TransactionService.TotalSumOf1000NairaDenomination}");

                        Console.WriteLine($"\nYour balance is {User.accountBalance}\n" +
                            " Press 1 to perform another transaction\n Press any other key to end transaction");
                        var userInput = Console.ReadLine();
                        if (userInput == "1")
                        {
                            TransactionService.Run();
                        }
                        else
                        {
                            TransactionService.EndTransaction();
                        }

                    }
                    else
                    {
                        Console.WriteLine("Invalid Input, input should be in multiples of N1000.");
                        Run();
                    }
                }
                else
                {
                    var withdrawable500NairaNotes = a - TransactionService.TotalSumOf500NairaDenomination;
                    var pendingWithdrawalBalance = a - withdrawable500NairaNotes;

                    if (withdrawable500NairaNotes % 1000 == 0)
                    {
                        if (pendingWithdrawalBalance % 1000 != 0)
                        {
                            Console.WriteLine("Amount to be withdrawn must be in multiples of 1000.");
                            Run();
                        }

                        Console.WriteLine($"N500 denominations available: N{withdrawable500NairaNotes}. N{pendingWithdrawalBalance} will be in N1000.\n Press 1 to continue or any other key to go back to main menu");
                        var userInput = Console.ReadLine();

                        if (userInput == "1")
                        {
                            Console.WriteLine($"Withdrawing N{a}, collect your cash");
                            var newBalance = User.accountBalance - a;
                            var newFiveHundredNairaDenomintionBalance = TransactionService.TotalSumOf500NairaDenomination - withdrawable500NairaNotes;
                            var newOneThousandNairaDenomintionBalance = TransactionService.TotalSumOf500NairaDenomination - pendingWithdrawalBalance;

                            User.accountBalance = newBalance;
                            TransactionService.TotalSumOf500NairaDenomination = newFiveHundredNairaDenomintionBalance;
                            TransactionService.TotalSumOf1000NairaDenomination = newOneThousandNairaDenomintionBalance;

                            Console.WriteLine($"\nYour balance is {User.accountBalance}\n" +
                                " Press 1 to perform another transaction\n Press any other key to end transaction");

                            var userInput2 = Console.ReadLine();
                            if (userInput2 == "1")
                            {
                                TransactionService.Run();
                            }
                            else
                            {
                                TransactionService.EndTransaction();
                            }
                        }
                        else
                        {
                            Console.WriteLine(" Press 1 to perform another transaction\n Press any other key to end transaction");
                            var userInput2 = Console.ReadLine();
                            if (userInput2 == "1")
                            {
                                TransactionService.Run();
                            }
                            else
                            {
                                TransactionService.EndTransaction();
                            }
                        }
                    }
                }
            }
            else if (denominationVar == "2")
            {
                var a = (amountVar);

                if (a <= TransactionService.TotalSumOf1000NairaDenomination)
                {
                    if (a % 1000 == 0)
                    {
                        Console.WriteLine($"Withdrawing N{a}, collect your cash");
                        var newBalance = User.accountBalance - a;
                        var new1000NairaDenomintionBalance = TransactionService.TotalSumOf1000NairaDenomination - a;

                        User.accountBalance = newBalance;
                        TransactionService.TotalSumOf1000NairaDenomination = new1000NairaDenomintionBalance;
                        Console.WriteLine($"\nYour balance is {User.accountBalance}\n" +
                            " Press 1 to perform another transaction\n Press any other key to end transaction");
                        //Console.WriteLine($"\nATM has N{TransactionService.TotalATMAmount}, N500 notes: {TransactionService.TotalSumOf500NairaDenomination}, N1000 notes: {TransactionService.TotalSumOf1000NairaDenomination}");

                        var userInput = Console.ReadLine();
                        if (userInput == "1")
                        {
                            TransactionService.Run();
                        }
                        else
                        {

                            TransactionService.EndTransaction();
                        }

                    }
                    else
                    {
                        Console.WriteLine("Invalid Input, input should be in multiples of 500 or 1000.");
                        Run();
                    }
                }
                else
                {
                    var withdrawable1000NairaNotes = a - TransactionService.TotalSumOf500NairaDenomination;
                    var pendingWithdrawalBalance = a - withdrawable1000NairaNotes;

                    if (withdrawable1000NairaNotes % 1000 == 0)
                    {
                        if (pendingWithdrawalBalance % 1000 != 0)
                        {
                            Console.WriteLine("Amount to be withdrawn must be in multiples of 1000.");
                            Run();
                        }

                        Console.WriteLine($"N1000 denominations available: N{withdrawable1000NairaNotes}. N{pendingWithdrawalBalance} will be in N500.\n Press 1 to continue or any other key to go back to main menu");
                        var userInput = Console.ReadLine();

                        if (userInput == "1")
                        {
                            Console.WriteLine($"Withdrawing N{a}, collect your cash");
                            var newBalance = User.accountBalance - a;
                            var newNairaDenomintionBalance = TransactionService.TotalSumOf500NairaDenomination - withdrawable1000NairaNotes;
                            var new500DenomintionBalance = TransactionService.TotalSumOf500NairaDenomination - pendingWithdrawalBalance;

                            User.accountBalance = newBalance;
                            TransactionService.TotalSumOf1000NairaDenomination = newNairaDenomintionBalance;
                            TransactionService.TotalSumOf500NairaDenomination = new500DenomintionBalance;

                            Console.WriteLine($"\nYour balance is {User.accountBalance}\n" +
                                " Press 1 to perform another transaction\n Press any other key to end transaction");

                            var userInput2 = Console.ReadLine();
                            if (userInput2 == "1")
                            {
                                TransactionService.Run();
                            }
                            else
                            {
                                TransactionService.EndTransaction();
                            }
                        }
                        else
                        {
                            Console.WriteLine(" Press 1 to perform another transaction\n Press any other key to end transaction");
                            var userInput2 = Console.ReadLine();
                            if (userInput2 == "1")
                            {
                                TransactionService.Run();
                            }
                            else
                            {
                                TransactionService.EndTransaction();
                            }
                        }
                    }
                }
            }
        }
        
    }

}