using System;
using System.Globalization;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace SupportBank
{
    class Transaction
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        public DateTime Date { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Narrative { get; set; }
        public decimal Amount { get; set; }

        public Transaction(string[] eachTransaction)
        {
            CultureInfo enGb = new CultureInfo("en-GB");

            try
            {
                Date = Convert.ToDateTime(eachTransaction[0], enGb);
            }
            catch (FormatException e)
            {
                Logger.Debug("Check input - may not be a valid date" + e);
            }

            From = eachTransaction[1];
            To = eachTransaction[2];
            Narrative = eachTransaction[3];
            try
            {
                Amount = decimal.Parse(eachTransaction[4]);
            }
            catch (FormatException e)
            {
                Logger.Debug("Check input - may not be a valid amount" + e);
            }
        }
    }
}