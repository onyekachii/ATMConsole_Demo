using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ATM
{
    class Application
    {
        public static string SelectedLanguageIndex;
        static string _passcode;
        public static LanguageList selectedLang;
        public static int passwordFailCounter;
        public static string Passcode
        {
            get
            { return _passcode; }
            set
            { _passcode = value; }
                
        }      
                
        public static void LanguageSelection(string LanguageSelectVar)
        {
           
            switch (LanguageSelectVar)
            {
                case "0":
                    Console.WriteLine("\nPlease enter your PIN");
                    selectedLang = LanguageList.English;
                    break;                    
                case "1":
                    Console.WriteLine("\nDa fatan za a shigar da PIN naka");
                    selectedLang = LanguageList.Hausa;
                    Console.WriteLine(selectedLang);
                    break;
                case "2":
                    Console.WriteLine("\nBiko tinye PIN gi");
                    selectedLang = LanguageList.Igbo;
                    break;
                case "3":
                    Console.WriteLine("\nJo te PIN re si");
                    selectedLang = LanguageList.Yoruba;
                    break;                                    
                default:
                    Run();
                    break;
            }
        }

        class ApplicationTransaction : ILanguageTranslator
        {
            public void IRun(LanguageList data)
            {
                switch (Convert.ToString(data))
                {
                    case "English":
                        Console.WriteLine($"\nPlease enter a valid PIN");
                        break;
                    case "Hausa":
                        Console.WriteLine($"\nDa fatan za a shigar da PIN");
                        break;
                    case "Igbo":
                        Console.WriteLine($"\nBiko tinye PIN ziri ezi");
                        break;
                    case "Yoruba":
                        Console.WriteLine($"\nJowo te PIN to wulo sii");
                        break;
                }                                                            
            }
        }

        public static void Run()
        {
            var passwordErrorTransaction = new ApplicationTransaction();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            var welcomeMenu = new StringBuilder();
            welcomeMenu.AppendLine("Welcome\n Please select your prefered language:");
            welcomeMenu.AppendLine(" 0: English\n 1: Hausa\n 2: Igbo\n 3: Yoruba");
            Console.WriteLine(welcomeMenu.ToString());

            SelectedLanguageIndex = Console.ReadLine();
            
            LanguageSelection(SelectedLanguageIndex);
             
            Passcode = Console.ReadLine();
            Regex PasscodeRegex = new Regex(@"\D+");
            Match PasscodeMatch = PasscodeRegex.Match(Passcode);
            if (PasscodeMatch.Success)
            {
                passwordFailCounter++;
                Console.WriteLine(passwordFailCounter);
                if (passwordFailCounter < 3)
                {
                    Console.WriteLine($"{passwordFailCounter}");
                    passwordErrorTransaction.IRun(selectedLang);
                    Run();
                }
                else
                {
                    TransactionService.EndTransaction();
                }

            }

            PasscodeValidator.Run(selectedLang);

        }
    }
}
