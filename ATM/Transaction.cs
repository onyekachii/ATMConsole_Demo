using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    class Transaction
    {
        public static decimal TotalSumOf1000NairaDenomination = 50000;
        public static decimal TotalSumOf500NairaDenomination = 50000;
        public static decimal TotalATMAmount = TotalSumOf1000NairaDenomination + TotalSumOf500NairaDenomination;

        static Transaction()
        {
            Run();
        }

        public static void Run()
        {
            var transactMenu = new StringBuilder();
            transactMenu.AppendLine("\nPlease choose an option:");
            transactMenu.AppendLine(" 1: Check Balance\n 2: Withdraw\n 3: End Transaction");
            Console.WriteLine(transactMenu.ToString());

            string userInput = Console.ReadLine();
            if (userInput == "1")
            {
                Console.WriteLine($"{User.accountBalance}\nPress key 1 to go back");
                string userInput_ = Console.ReadLine();
                if (userInput_ == "1")
                {
                    Run();
                }//validate entry later       
            }
            else if (userInput == "2")
            {
                Withdrawal.Run();
            }
            else if (userInput == "3")
            {

            }
            else
            {
                Console.WriteLine("Input correct value Bros!");
            }
        }

    }
}
