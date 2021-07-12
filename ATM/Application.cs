using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ATM
{
    static class Application
    {
        public static string LanguageSelect;
        private static string _passcode;
        public static string Passcode
        {
            get { return _passcode; }
            private set { _passcode = value; }
        }
        public enum Language
        {
            English,
            Yoruba,
            Igbo,
            Hausa
        }

        private static Language LanguageSelection(string LanguageSelectVar)
        {
            switch (LanguageSelectVar)
            {
                case "0":
                    Console.WriteLine($"Enter your 4-Digits PIN");
                    return Language.English;
                case "1":
                    return Language.Hausa;
                case "2":
                    return Language.Igbo;
                case "3":
                    return Language.Yoruba;
                default:
                    Console.WriteLine($"Enter your 4-Digits PIN");
                    return Language.English;
            }
        }
        public static void Run()
        {
            var LanguageMenu = new StringBuilder();
            LanguageMenu.AppendLine("Welcome\n Please select your prefered language:");
            LanguageMenu.AppendLine(" 0: English\n 1: Hausa\n 2: Igbo\n 3: Yoruba");
            Console.WriteLine(LanguageMenu.ToString());

            LanguageSelect = Console.ReadLine();
            Language selectedLang = LanguageSelection(LanguageSelect);

            Passcode = Console.ReadLine();
            Regex PasscodeRegex = new Regex(@"\D+");
            Match PasscodeMatch = PasscodeRegex.Match(Passcode);
            if (PasscodeMatch.Success)
            {
                Console.WriteLine($"\nPlease enter a valid PIN");
                Run();
            }

            PasscodeValidator.Run(selectedLang);

        }
    }
}
