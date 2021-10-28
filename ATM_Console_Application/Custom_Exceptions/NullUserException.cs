using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Console_Application.Custom_Exceptions
{
    public class NullUserException : Exception
    {
        public NullUserException()
        {

        }
        public NullUserException(string name) : base (String.Format("Enter a valid PIN"))
        {

        }
    }
}
