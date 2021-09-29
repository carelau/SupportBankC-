using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace SupportBank
{
    class Reader
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
        public List<Transaction> CreateTransactionList(string path)
        {
          
            var rows = File.ReadAllLines(path).Skip(1);

            List<Transaction> transactionList = new List<Transaction>();

            foreach (string eachRow in rows)
            {
                string[] eachTransaction = eachRow.Split(',');
            
                Transaction singleTransaction = new Transaction(eachTransaction);
                 transactionList.Add(singleTransaction);
                }
                
            
            return transactionList;
        }

    }
}
