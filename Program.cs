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
            Reader fileReader = new Reader();
            List<Transaction> transactionList = fileReader.CreateTransactionList(path);
            List<string> repeatedNames = new List<string>();

            List<string> uniqueNames = CreateUniqueNameList(repeatedNames, transactionList);
            List<Account> accountList  =CreateAccountList (uniqueNames, transactionList);
      
            Console.WriteLine ("What information would you like? Please select a number \n 1. List All 2. List Account");
            int userInput = int.Parse(Console.ReadLine());

            if (userInput == 1)
           
            {
                ListAll (accountList);
            } 

            /* foreach (string eachRow in rows)
            {
               string [] eachTransaction = eachRow.Split(',');
               Transaction singleTransaction = new Transaction (eachTransaction);
               transactionList.Add(singleTransaction);

               /*Console.WriteLine("{0} {1} {2} {3} {4:C}" , singleTransaction.Date.ToShortDateString(),
               singleTransaction.From, singleTransaction.To, 
               singleTransaction.Narrative, singleTransaction.Amount);
            }*/

        }

        public static List<string> CreateUniqueNameList(List<string> repeatedNames, List<Transaction> transactionList)
        {
            foreach (Transaction transaction in transactionList)
            {
                repeatedNames.Add(transaction.From);
                repeatedNames.Add(transaction.To);
            }
            List<string> uniqueNames = repeatedNames.Distinct().ToList();
            return uniqueNames;
        }


        public static List<Account> CreateAccountList (List<string> uniqueNames, List<Transaction> transactionList)
        {
           List<Account> accountList = new List<Account>();
            foreach (string name in uniqueNames)
            {
                Account eachAccount = new Account(name);

                foreach (Transaction transaction in transactionList)
                {
                    if (transaction.To == name)
                    {
                        eachAccount.IncomingTransactions.Add(transaction);
                        eachAccount.amountOwed += transaction.Amount;
                        //eachAccount.IncomingTransactions.ForEach (transaction => Console.WriteLine ("{0} {1} {2}", transaction.From, transaction.To, transaction.Amount ));
                    }
                    if (transaction.From == name)
                    {
                        eachAccount.OutgoingTransactions.Add(transaction);
                        eachAccount.owe += transaction.Amount;
                        //eachAccount.OutgoingTransactions.ForEach (transaction => Console.WriteLine ("{0} {1} {2}", transaction.From, transaction.To, transaction.Amount ));
                    }
                }
                // Console.WriteLine("Name: {0} Owe: {1} Amount Owed: {2}", eachAccount.Name, eachAccount.owe, eachAccount.amountOwed);
                accountList.Add(eachAccount);
            }
            return accountList;
        }

        public static void ListAll (List<Account> accountList)
        {
            foreach(Account account in accountList)
            {
               Console.WriteLine("Name: {0}, Total he/she Owe: {1:C}, Amount Owed: {2:C}", account.Name, account.owe, account.amountOwed);
            }
        }

    }
}
