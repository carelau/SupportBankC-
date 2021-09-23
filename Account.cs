using System;
using System.Collections.Generic;

namespace SupportBank
{
    class Account
    {
        public string Name { get; set; }

        public decimal Owe { get; set; }
        public decimal AmountOwed { get; set; }
         public decimal Balance { get; set; }
        public List<Transaction> IncomingTransactions { get; set; }
        public List<Transaction> OutgoingTransactions { get; set; }

        public Account (string name)
        {
            Name = name;
            IncomingTransactions = new List<Transaction>();
            OutgoingTransactions = new List<Transaction>();
        }

    }
}
