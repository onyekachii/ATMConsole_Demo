using ATM_Console_Application.Utilities.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ATM_Console_Application.Utilities
{
    public static class Tools
    {

        public static void WelcomeMessage()
        {
            var welcomeMenu = new StringBuilder();
            welcomeMenu.AppendLine("Welcome\n Please select your prefered language:");
            welcomeMenu.AppendLine(" 0: English\n 1: Pigin English");
            Console.WriteLine(welcomeMenu.ToString());
        }
        public static void LanguageSelection(string selectedLanguageIndex, LanguageList selectedLang)
        {
            switch (selectedLanguageIndex)   
            {
                case "0":
                    Console.WriteLine("\nPlease enter your PIN");
                    selectedLang = LanguageList.English;
                    break;
                case "1":
                    Console.WriteLine("\nAbeg enter your PIN");
                    selectedLang = LanguageList.Pigin;
                    break;                
                default:
                    selectedLang = LanguageList.English;
                    break;
            }
        }

        public static bool PasscodeCheckWithRegex(string passcode, int passwordFailCounter, LanguageList selectedLang)
        {
            Regex PasscodeRegex = new Regex(@"\D+");
            Match PasscodeInvalid = PasscodeRegex.Match(passcode);
            if (PasscodeInvalid.Success)
            {
                passwordFailCounter++;
                Console.WriteLine($"Login fails: {passwordFailCounter}");
                if (passwordFailCounter < 3)
                {
                    switch (Convert.ToString(selectedLang))
                    {
                        case "English":
                            Console.WriteLine($"\nPlease enter a valid PIN");
                            break;
                        case "Pigin":
                            Console.WriteLine($"\nEnter PIN Abeg");
                            break;
                        default:
                            Console.WriteLine("Please enter a valid PIN");
                            break;
                    }
                    return false;
                }
                else
                    Environment.Exit(0);
            }
            return true;
        }

        public static void PasscodeValidator()
        {
            var passCodeValidatorErrorMessage = new PassCodeValidatorTransaction();
            if (Application.Passcode.Trim() != User.passcode)
            {
                Application.passwordFailCounter++;
                if (Application.passwordFailCounter < 3)
                {
                    passCodeValidatorErrorMessage.IRun(selectedLangVar);
                    Application.Run();
                }
                else
                {
                    TransactionService.EndTransaction();
                }
            }

            TransactionService.Run();
        }
    }
}
