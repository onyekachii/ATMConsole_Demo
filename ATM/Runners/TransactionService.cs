using System;
using System.Text;

namespace ATM
{
    static class TransactionService
    {
        public static decimal TotalSumOf1000NairaDenomination = 50000;
        public static decimal TotalSumOf500NairaDenomination = 50000;
        public static decimal TotalATMAmount = TotalSumOf1000NairaDenomination + TotalSumOf500NairaDenomination;

        public static void Run()
        {
            var Transaction = new MainTransaction();
            Transaction.IRun(Application.selectedLang);
        }

        class MainTransaction : ILanguageTranslator
        {
            public void IRun(LanguageList data)
            {
                switch (Convert.ToString(data))
                {
                    case "English":
                        var transactMenu = new StringBuilder();
                        transactMenu.AppendLine("\nPlease choose an option:");
                        transactMenu.AppendLine(" 1: Check Balance\n 2: Withdraw\n 3: End Transaction");
                        Console.WriteLine(transactMenu.ToString());

                        string userInput = Console.ReadLine();
                        TransactionFunction(userInput, Convert.ToString(data));

                        break;
                    case "Hausa":
                        transactMenu = new StringBuilder();
                        transactMenu.AppendLine("\nDon Allah zabi");
                        transactMenu.AppendLine(" 1: duba ma'auni\n 2: cire\n 3: tsaya");
                        Console.WriteLine(transactMenu.ToString());

                        userInput = Console.ReadLine();
                        TransactionFunction(userInput, Convert.ToString(data));

                        break;
                    case "Igbo":
                        transactMenu = new StringBuilder();
                        transactMenu.AppendLine("\nHoro Ofu");
                        transactMenu.AppendLine(" 1: nele ego\n 2: wepu ego\n 3: Imecha");
                        Console.WriteLine(transactMenu.ToString());

                        userInput = Console.ReadLine();
                        TransactionFunction(userInput, Convert.ToString(data));
                        break;
                    case "Yoruba":
                        transactMenu = new StringBuilder();
                        transactMenu.AppendLine("\nTe kan si");
                        transactMenu.AppendLine(" 1: Wo owo\n 2: Yo owo\n 3: Pari Ise");
                        Console.WriteLine(transactMenu.ToString());

                        userInput = Console.ReadLine();
                        TransactionFunction(userInput, Convert.ToString(data));
                        break;
                }
            }            
        }
        static void CheckBalance()
        {
            Console.WriteLine($"{User.accountBalance}\nPress any key and enter to go back");
            Console.ReadLine();
            Run();
        }

        public static void EndTransaction()
        {
            Console.WriteLine("\nTransaction Terminated.\n Thank you for banking with Us.");
            Application.Run();
        }

        public static void TransactionFunction(string a, string b)
        {
            switch (a)
            {
                case "1":
                    CheckBalance();
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
    }           
}
