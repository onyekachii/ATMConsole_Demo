using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Users
    {
        public IEnumerable<User> AllUsers = new List<User>()
        {
            new User
            {
                FirstName = "Kennedy",
                LastName = "Ugwu",
                Passcode = 1234,
                Balance = 100000
            },
            new User
            {
                FirstName = "Ken",
                LastName = "Ugu",
                Passcode  = 1235,
                Balance = 20000
            },
            new User
            {
                FirstName = "Alex",
                LastName = "Ogbuike",
                Passcode = 1236,
                Balance = 1000
            }
        };
    }
}
