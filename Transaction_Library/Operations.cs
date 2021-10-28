using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transaction_Library.Utilities;

namespace Transaction_Library
{
    sealed public class Operations
    {        
        private decimal _totalSumOf1000NairaDenomination;
        private decimal _totalSumOf500NairaDenomination;
        private decimal _totalATMAmount;
        private string _language;
        private User _user;

        public decimal TotalSumOf1000NairaDenomination
        {
            get { return _totalSumOf1000NairaDenomination; }
            set
            {
                _totalSumOf1000NairaDenomination = 50000;
            }
        }

        public decimal TotalSumOf500NairaDenomination
        {
            get { return _totalSumOf500NairaDenomination; }
            set
            {
                _totalSumOf500NairaDenomination = 50000;
            }
        }

        public decimal TotalATMAmount
        {
            get { return _totalATMAmount; }
            set
            {
                _totalATMAmount = _totalSumOf1000NairaDenomination + _totalSumOf500NairaDenomination;
            }
        }

        public Operations()
        { }
        public Operations(User user, string language)
        {
            _user = user;
            _language = language;
        }

        public void Run()
        {
            TransactionTools.TransactionOptions(_language, _user);
        }
    }
}
