using ATM_Console_Application.Utilities;
using ATM_Console_Application.Utilities.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Console_Application
{
    public class Application
    {
        public static string SelectedLanguageIndex;
        public static LanguageList selectedLang;
        static string _passcode;
        public static int passwordFailCounter;

        public static string Passcode
        {
            get
            { return _passcode; }
            set
            { _passcode = value; }
        }
        
        public static void Run()
        {
            start:
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Tools.WelcomeMessage();

            SelectedLanguageIndex = Console.ReadLine();
            Tools.LanguageSelection(SelectedLanguageIndex, selectedLang);

            Passcode = Console.ReadLine();
            var passwordCheck = Tools.PasscodeCheckWithRegex(Passcode, selectedLang);
            if (!passwordCheck)
                goto start;

            Tools.Login(selectedLang, _passcode);            
        }

        
    }
}
