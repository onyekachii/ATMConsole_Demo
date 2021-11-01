using ATM_Console_Application.Custom_Exceptions;
using ATM_Console_Application.Utilities.Enumerators;
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

        public static bool PasscodeCheckWithRegex(string passcode, LanguageList selectedLang)
        {
            Regex PasscodeRegex = new Regex(@"\D+");
            Match PasscodeInvalid = PasscodeRegex.Match(passcode);
            if (PasscodeInvalid.Success)
            {
                Application.passwordFailCounter++;
                Console.WriteLine($"Login fails: {Application.passwordFailCounter}. The App will shut down after three failed attempts");
                if (Application.passwordFailCounter < 4)
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

        public static void Login(LanguageList selectedLang, string passcode)
        {
            var language = selectedLang.ToString();
            try
            {
                int PIN = int.Parse(passcode);

                var usersObject = Users.AllUsers;
                var user = usersObject.Where(u => u.Passcode == PIN).FirstOrDefault();

                if (user is null)
                {
                    Application.passwordFailCounter++;
                    Console.WriteLine($"Login fails: {Application.passwordFailCounter}. The App will shut down after three failed attempts");
                    if (Application.passwordFailCounter < 4)                    
                        throw new NullUserException("Enter a valid PIN");                    
                    else
                        Environment.Exit(0);
                }
                Operations.User = user;
                Operations.Language = language;                
                Operations.Run();
            }
            
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Application.Run();
            }
        }
    }
}
