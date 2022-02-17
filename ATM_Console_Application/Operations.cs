using ATM_Console_Application.Utilities;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Console_Application
{
    static public class Operations
    {
        private static User _user;
        public static string Language;

        public static double TotalSumOf1000NairaDenomination { get; set; } = 50000;

        public static double TotalSumOf500NairaDenomination { get; set; } = 50000;

        public static User User { get { return _user; } set { _user = value; } }

        public static double TotalATMAmount
        {
            get
            {
                return TotalSumOf500NairaDenomination + TotalSumOf1000NairaDenomination;
            }
        }

        public static void Run()
        {
            var transactionTools = new TransactionTools(_user);
            TransactionTools.TransactionOptions(Language, _user);
        }
    }
}
