using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace CyberCoyotesBank
{
    // Class responsible for scheduling and executing transactions every 15 minutes
    internal class Transaction15min
    {
        private List<Transaction> pendingTransactions; // List to store pending transactions
        private System.Timers.Timer timer; // Timer to schedule transactions

        // Constructor initializes the class with an empty list of pending transactions and sets up the timer for 15 minutes
        public Transaction15min()
        {
            pendingTransactions = new List<Transaction>();
            timer = new System.Timers.Timer(15 * 60 * 1000); // 15 minutes to the millisecund
            timer.Elapsed += OnTimerElapsed;
            timer.Start();
        }

        // Method to schedule a transaction for execution
        public void ScheduleTransaction(Transaction transaction)
        {
            pendingTransactions.Add(transaction);
        }

        // Method called when the timer elapses, executing the scheduled transactions
        public void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            // Transaction logic that runs every 15 minutes
            Console.WriteLine($"Performing transactions at {DateTime.Now}");
            foreach (var transaction in pendingTransactions)
            {
                transaction.Execute();
            }

            // Clear the scheduled transaction list
            pendingTransactions.Clear();
        }
    }
}
