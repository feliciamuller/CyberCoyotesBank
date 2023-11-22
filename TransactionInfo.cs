using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberCoyotesBank
{
    internal class TransactionInfo
    {
        public Account FromAcc;
       public  Account ToAcc;
       public double AmountToMove;

        public TransactionInfo(Account _fromAcc, Account _toAcc, double amount )
        {
            FromAcc = _fromAcc;
            ToAcc = _toAcc;
            AmountToMove = amount;
        }
    }
}
