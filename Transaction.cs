using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberCoyotesBank
{
    // Class representing a transaction with a description and an executable action
    internal class Transaction
    {
        public string Description { get; set; } // Description identifying the purpose of the transaction
        public Action Execute { get; set; } // Action representing the executable function or action for the transaction

        // Constructor initializes a transaction with a description and an action to be executed
        // Description is a description that identifies and explains the purpose of the transaction in the class.
        // Action execute is a parameter of type Action used to represent an action or function to be executed.
        // In Action execute, we pass the specific action to be performed as a parameter to the transaction method.
        // This provides more flexibility and the ability to customize the behavior of the transaction.
        public Transaction(string description, Action execute)
        {
            Description = description;
            Execute = execute;
        }
    }
}

// Lägg till detta någonstans (typ i Menu-klassen eller?): 
// Transaction15min transaction15min = new Transaction15min();

// Exempel på hur jag TROR man kan schemalägga så transaktioner sker var 15:e minut:
// Transaction transferTransaction = new Transaction("Överföring", () =>
// { 
// Implementera transaktionslogik här
// Console WriteLine("Utför överföring...");
// });
//  transactionScheduler.ScheduleTransaction(transferTransaction);

// Här kan du schemalägga fler transaktioner vid behov

// Console.ReadLine(); // Håller programmet igång så att du kan se utskrifterna

