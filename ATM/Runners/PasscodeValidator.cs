using System;

namespace ATM
{
    class PasscodeValidator
    {
        public static void Run(LanguageList selectedLangVar)
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
        class PassCodeValidatorTransaction : ILanguageTranslator
        {
            public void IRun(LanguageList data )
            {
                if (Convert.ToString(data) == "English")
                {
                    Console.WriteLine($"\nInvalid PIN");
                }
                else if (Convert.ToString(data) == "Hausa")
                {
                    Console.WriteLine($"\nPIN mara daidai");
                }
                else if (Convert.ToString(data) == "Igbo")
                {
                    Console.WriteLine($"\nObughi PIN nke gi");
                }
                else if (Convert.ToString(data) == "Yoruba")
                {
                    Console.WriteLine($"\nko to");
                }
            }
        }
                
    }
}
