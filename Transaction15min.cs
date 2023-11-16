using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace CyberCoyotesBank
{
    internal class Transaction15min
    {
        private List<Transaction> pendingTransactions;
        private System.Timers.Timer timer;

        public Transaction15min()
        {
            pendingTransactions = new List<Transaction>();
            timer = new System.Timers.Timer(15 * 60 * 1000); // 15 minuter i millisekunden
            timer.Elapsed += OnTimerElapsed;
            timer.Start();
        }

        public void ScheduleTransaction(Transaction transaction)
        {
            pendingTransactions.Add(transaction);
        }

        public void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            // Transaktionslogik som körs varje 15:e minut
            Console.WriteLine($"Utför transaktioner kl {DateTime.Now}");
            foreach (var transaction in pendingTransactions)
            {
                transaction.Execute();
            }

            // Rensa den planerade transaktionslistan
            pendingTransactions.Clear();
        }
    }
}
