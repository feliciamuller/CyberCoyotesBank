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
            timer = new System.Timers.Timer(1 * 60 * 1000);
           //timer = new System.Timers.Timer(15 * 60 * 1000); // 15 minutes to the millisecund
            timer.Elapsed += OnTimerElapsed;
            timer.Start();
        }

        public void ScheduleTransaction(Transaction transaction)
        {
            pendingTransactions.Add(transaction);
        }

        public void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            // Transaction logic that runs every 15 minutes
            Console.WriteLine($"Utför transaktioner kl {DateTime.Now}");
            foreach (var transaction in pendingTransactions)
            {
                transaction.Execute();
            }

            // Clear the scheduled transaction list
            pendingTransactions.Clear();
        }
    }
}
