using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public static class User
    {
        public static string firstName = "Jon";
        public static string lastName = "Snow";
        public static string fullName = $"{firstName} {lastName}";
        public static string passcode = "1234";
        public static decimal accountBalance = 20000.83M;
    }
}
