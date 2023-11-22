using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CyberCoyotesBank
{
    static internal class AccountManager
    {

        // List of Accounts
        static private List<Account> accounts = new List<Account>() { new Account(99, "testAccount", "sek", 25000, UserManager.GetUser(102)), new Account(100, "testAccount2", "sek", 25000, UserManager.GetUser(102)), new Account(101, "testAccount2", "dollar", 25000, UserManager.GetUser(102)), new Account(102, "user2Account", "sek", 25000, UserManager.GetUser(103)) };
        // Last Id used to create an account
        static private int lastId = 100;

        // Runs account constructor and adds a new account to list
        static public void CreateAccount(string name, string currency, float balance)
        {

            lastId++;
            accounts.Add(new Account(lastId, name, currency, balance,LoginManager.GetActiveUser()));
            Console.WriteLine("Checking account is created!");
        }

        static public void CreateSavingsAccount(string name, string currency, float balance, float interest)
        {
            lastId++;
            accounts.Add(new Account(lastId, name, currency, balance, interest, LoginManager.GetActiveUser()));
            Console.WriteLine($"Savings account is created and you get an interest of {interest}%");
        }

        // Find account from id
        static public Account GetAccount(int id)
        {
            return accounts.Find(x => x._id == id);
        }

        static public List<Account> GetAllAccountsUser(User user)
        {
            return accounts.FindAll(x => x.Owner == user);
        }

        static public List<Account> GetAllAccounts()
        {
            return accounts;
        }
    }
}
