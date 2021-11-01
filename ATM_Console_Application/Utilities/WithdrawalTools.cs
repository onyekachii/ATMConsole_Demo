using Data;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ATM_Console_Application.Utilities
{
    public static class WithdrawalTools
    {
        public static double Amount;
        public static void StartWithdrawalTransaction(string userInput, string language)
        {
            switch (userInput)
            {
                case "0":
                    Amount = 1000;
                    break;
                case "1":
                    Amount = 2000;
                    break;
                case "2":
                    Amount = 5000;
                    break;
                case "3":
                    Amount = 10000;
                    break;
                default:
                    Regex userInputRegex = new Regex(@"\D+");
                    Match userInputVarMatch = userInputRegex.Match(userInput);
                    if (userInputVarMatch.Success)
                    {
                        Console.WriteLine($"\nPlease enter a valid option");
                        TransactionTools.Withdraw(language);
                    }
                    Console.WriteLine($"Please enter amount");
                    var newUserInput = Console.ReadLine();
                    Amount = Convert.ToInt32(newUserInput);
                    break;
            }
        }

        public static void CheckBalance(string denomination, User user, string language)
        {
            double withdrawableAmount = user.Balance;

            if (withdrawableAmount < Amount)
            {
                Console.WriteLine($"Insufficient Balance. Your Balance is {user.Balance}");
                TransactionTools.TransactionOptions(language, user);
            }

            if(Amount >= Operations.TotalATMAmount)
                Console.WriteLine($"Insufficient cash to dispense. Total dispensable cash {Operations.TotalATMAmount}");
            else            
                Print(denomination, Amount, language, user);
            
        }

        private static void Print(string denomination, double amount, string language, User user)
        {
            var total500NairaDenomination = Operations.TotalSumOf500NairaDenomination;
            var total1000NairaDenomination = Operations.TotalSumOf1000NairaDenomination;
            if (denomination == "1")
            {
                var selectedDenomination = "5h";

                if (amount <= total500NairaDenomination)
                {
                    if (amount % 1000 == 0)                    
                        GetMoney(amount, user, Operations.TotalSumOf500NairaDenomination, language, selectedDenomination);                                        
                    else                    
                        DenominationMultipleError(language);                    
                }
                else
                {
                    GetMoney(total500NairaDenomination, total1000NairaDenomination, amount, language, selectedDenomination, user);                    
                }
            }
            else if (denomination == "2")
            {
                var selectedDenomination = "1k";

                if (amount <= total1000NairaDenomination)
                {
                    if (amount % 1000 == 0)                    
                        GetMoney(amount, user, Operations.TotalSumOf1000NairaDenomination, language, selectedDenomination);                                                                  
                    else
                        DenominationMultipleError(language);
                }
                else
                {
                    GetMoney(total500NairaDenomination, total1000NairaDenomination, amount, language, selectedDenomination, user);
                }
            }
        }

        private static void DenominationMultipleError(string language)
        {
            Console.WriteLine("Invalid Input, input should be in multiples of N1000.");
            TransactionTools.Withdraw(language);
        }

        private static void UpdateUserBalance(User user, double amount)
        {
            var newBalance = user.Balance - amount;
            user.Balance = newBalance;
        }

        private static void DualPrint(string userInput, double  amount, User user, double total500NairaDenomination,
            double withdrawableNairaNotes, double pendingWithdrawalBalance, double total1000NairaDenomination,
            string language, string selectedDenomination)
        {
            double newFiveHundredNairaDenomintionBalance = 0;
            double newOneThousandNairaDenomintionBalance = 0;
            if (userInput == "1")
            {
                Console.WriteLine($"Withdrawing N{amount}, collect your cash");
                UpdateUserBalance(user, amount);

                if(selectedDenomination == "5h")
                {
                    newFiveHundredNairaDenomintionBalance = total500NairaDenomination - withdrawableNairaNotes;
                    newOneThousandNairaDenomintionBalance = total1000NairaDenomination - pendingWithdrawalBalance;
                }
                else
                {
                    newOneThousandNairaDenomintionBalance = total1000NairaDenomination - withdrawableNairaNotes;
                    newFiveHundredNairaDenomintionBalance = total500NairaDenomination - pendingWithdrawalBalance;
                }
                                
                Operations.TotalSumOf500NairaDenomination = newFiveHundredNairaDenomintionBalance;
                Operations.TotalSumOf1000NairaDenomination = newOneThousandNairaDenomintionBalance;

                Console.WriteLine($"\nYour balance is {user.Balance}\n" +
                    " Press 1 to perform another transaction\n Press any other key to end transaction");
                var userInput2 = Console.ReadLine();

                if (userInput2 == "1")
                    TransactionTools.TransactionOptions(language, user);
                else
                    TransactionTools.EndTransaction();               
            }
            else
                TransactionTools.TransactionOptions(language, user);
        }

        private static void GetMoney(double amount, User user, double nairaDenominationFromOperation, string language, string selectedDenomination)
        {
            Console.WriteLine($"Withdrawing N{amount}, collect your cash");
            UpdateUserBalance(user, amount);

            if (selectedDenomination == "5h")
                Operations.TotalSumOf500NairaDenomination = nairaDenominationFromOperation - amount;
            else
                Operations.TotalSumOf1000NairaDenomination = nairaDenominationFromOperation - amount;

            Console.WriteLine($"\n N500 notes: {Operations.TotalSumOf500NairaDenomination }, N1000 notes: {Operations.TotalSumOf1000NairaDenomination}");
            Console.WriteLine($"\nYour balance is {user.Balance}\n" +
                " Press 1 to perform another transaction\n Press any other key to end transaction");
            var userInput = Console.ReadLine();

            if (userInput == "1")
                TransactionTools.TransactionOptions(language, user);
            else
                TransactionTools.EndTransaction();
        }
        private static void GetMoney(double total500NairaDenomination, double total1000NairaDenomination, double amount, string language, string selectedDenomination, User user)
        {
            double withdrawableNairaNotes;
            if (selectedDenomination == "5h")
                withdrawableNairaNotes = total500NairaDenomination;
            else
                withdrawableNairaNotes = total1000NairaDenomination;

            var pendingWithdrawalBalance = amount - withdrawableNairaNotes;

            if (withdrawableNairaNotes % 1000 == 0)
            {
                if (pendingWithdrawalBalance % 1000 != 0)
                    DenominationMultipleError(language);

                if(selectedDenomination == "5h")
                    Console.WriteLine($"N500 denominations available: N{total500NairaDenomination}." +
                        $" N{pendingWithdrawalBalance} will be in N1000. \n Press 1 to continue or any other key to go back to main menu");
                else
                    Console.WriteLine($"N1000 denominations available: N{total1000NairaDenomination}." +
                        $" N{pendingWithdrawalBalance} will be in N500. \n Press 1 to continue or any other key to go back to main menu");

                var userInput = Console.ReadLine();
                DualPrint(userInput, amount, user, total500NairaDenomination, withdrawableNairaNotes,
                    pendingWithdrawalBalance, total1000NairaDenomination, language, selectedDenomination);
            }
        }
    }
} 
