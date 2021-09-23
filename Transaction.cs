using System;
using System.Globalization;

namespace SupportBank
{
    class Transaction
    {
        public DateTime Date { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Narrative { get; set; }
        public decimal Amount { get; set; }
      
      public Transaction (string [] eachTransaction)
      {
          CultureInfo enGb = new CultureInfo("en-GB");
          Date = Convert.ToDateTime(eachTransaction[0], enGb);
          From = eachTransaction[1];
          To = eachTransaction[2];
          Narrative = eachTransaction[3];
          Amount = decimal.Parse(eachTransaction[4]);
      }
    }
}