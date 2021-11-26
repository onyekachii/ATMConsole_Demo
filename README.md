# ATM_Demo
This is a console app built on the .Net Framework.
It implements multi-lingual functionalities, PIN authentication, withdrawal and balance check.
The code below are the data of arbituary users
```C#
public class Users
    {
        public static IEnumerable<User> AllUsers = new List<User>()
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
```
