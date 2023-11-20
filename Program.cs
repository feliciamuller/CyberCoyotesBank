using System.Diagnostics.SymbolStore;
using System.Runtime.InteropServices;

namespace CyberCoyotesBank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user1 = new User("Barn", "123", 0);
            User newUser = new User("Moa", "123", 1);
            AccountManager.CreateAccount("Sparkonto", "SEK", 10000, user1);
            AccountManager.CreateAccount("Lönekonto", "SEK", 5000, user1);
            AccountManager.CreateAccount("Sparkkonto", "SEK", 2000, newUser);
            AccountManager.CreateAccount("Lönekonto", "SEK", 7000, newUser);
            Account account = new Account();

            //account.TransferMoney(user1);
            //account.TransactionToUser(user1);
            //account.AccountHistory(user1);
            //account.CheckBalance(user1);
            //account.CheckBalance(newUser);
            account.Loan(user1);

            //account.TransferMoney(newUser);
            //account.CheckBalance(user);
            //account.AccountHistory(user);
            //account.AccountHistory(newUser);

            //Menu.PrintLogin();
        }

    }
}