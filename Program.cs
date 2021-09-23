using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace SupportBank
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Work\TechSwitch\C#\SupportBank\Transactions2014.csv";
            List<Transaction> transactionList = new List<Transaction>();
            var rows = File.ReadAllLines(path).Skip(1);
            List<string> repeatedNames = new List<string>();
            List<Account> accountList = new List<Account>();
            
            //create a complete Transaction List

             foreach (string eachRow in rows)
            {
               string [] eachTransaction = eachRow.Split(',');
               Transaction singleTransaction = new Transaction (eachTransaction);
               transactionList.Add(singleTransaction);

               /*Console.WriteLine("{0} {1} {2} {3} {4:C}" , singleTransaction.Date.ToShortDateString(),
               singleTransaction.From, singleTransaction.To, 
               singleTransaction.Narrative, singleTransaction.Amount);*/
            }

            // create a names list
           foreach (Transaction transaction in transactionList )
           {
                  repeatedNames.Add(transaction.From);
                  repeatedNames.Add(transaction.To);
           }
        
            List<string> uniqueNames = repeatedNames.Distinct().ToList();
            
            //create an accounts list
            foreach (string name in uniqueNames)
            {
                Account eachAccount = new Account (name);
      
                foreach (Transaction transaction in transactionList)
                {
                    if (transaction.To == name) 
                    {
                        eachAccount.IncomingTransactions.Add(transaction);
    
                        eachAccount.amountOwed += transaction.Amount ;
                        //eachAccount.IncomingTransactions.ForEach (transaction => Console.WriteLine ("{0} {1} {2}", transaction.From, transaction.To, transaction.Amount ));
                    }
                    if (transaction.From == name)
                    {
                        eachAccount.OutgoingTransactions.Add(transaction);
                        eachAccount.owe += transaction.Amount;
                        //eachAccount.OutgoingTransactions.ForEach (transaction => Console.WriteLine ("{0} {1} {2}", transaction.From, transaction.To, transaction.Amount ));
                    }
                }
                Console.WriteLine ("Name: {0} Owe: {1} Amount Owed: {2}", eachAccount.Name, eachAccount.owe, eachAccount.amountOwed);
        
            }
        }
    }
}
