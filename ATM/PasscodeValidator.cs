using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    class PasscodeValidator
    {
        public static Transaction transact;
        public static void Run(Application.Language selectedLangVar)
        {
            if (Application.Passcode.Trim() != User.passcode)
            {
                Console.WriteLine($"\nIncorrect PIN");
                Application.Run();
            }

            transact = new Transaction();


        }
    }
}
