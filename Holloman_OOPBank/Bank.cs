using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Holloman_OOPBank
{
    internal class Bank
    {
        private decimal _balance = 1000m;
        private decimal _withdraw;
        private decimal _deposite;

        public Bank(decimal WD, decimal DP)
        {
            _withdraw = WD;
            _deposite = DP;
        }

        public decimal SetBalance()
        {
            return _balance;
        }


        public decimal BalanceWithdrawal
        {
            get { return _withdraw; }
            set { _withdraw = value; }
        }

        public decimal BalanceDeposite
        {
            get { return _deposite; }
            set { _deposite = value; }
        }

        public decimal WithdrawMoney(decimal WD)
        {
            _withdraw = WD;
            _balance = _balance - WD;
            return _balance;
        }
        public decimal NegativeBalance(decimal WD)
        {
            WD = WD * -1;
            return WD;
        }

        public decimal DepositeMoney(decimal DP)
        {
            _deposite = DP;
            _balance = _balance + DP;
            return _balance;
        }
    }
}
