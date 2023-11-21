using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberCoyotesBank
{
    internal class Transaction
    {
        public string Description { get; set; }
        public Action Execute { get; set; }

        // Description är en beskrivning som identifierar och förklarar syftet med transakttionen i klassen
        // Action execute är en parameter av typen Action som används för att representera en 
        // åtgärd eller funktion som ska utföras.
        // I Action execute skickar vi med den specifika åtgärden som ska utföras som en parameter 
        // till transaktionsmetoden.
        // Det ger mer flexibilitet och möjlighet att anpassa transaktionens beteende.
        public Transaction(string description, Action execute)
        {
            Description = description;
            Execute = execute;
        }
    }
}

// Lägg till detta någonstans (typ i Accountklassen eller?): 
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

