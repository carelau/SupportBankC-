using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace SupportBank
{
    class Reader
    {
        public List<Transaction> CreateTransactionList (string path)
        {
            var rows = File.ReadAllLines(path).Skip(1);
            List<Transaction> transactionList = new List<Transaction>();

            foreach (string eachRow in rows)
            {
               string [] eachTransaction = eachRow.Split(',');
               Transaction singleTransaction = new Transaction (eachTransaction);
               transactionList.Add(singleTransaction);
            }
            return transactionList;
        }  
    }
}
