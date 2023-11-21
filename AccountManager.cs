using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CyberCoyotesBank
{
    static internal class AccountManager
    {

        //List of Accounts
        static private List<Account> accounts = new List<Account>() { new Account(99, "testAccount", "SEK", 25000, UserManager.GetUser(102)) };
        //Last Id used to create an account
        static private int lastId = 99;

        //Runs account constructor and adds a new account to list
        static public void CreateAccount(string name, string currency, float balance)
        {

            lastId++;
            accounts.Add(new Account(lastId, name, currency, balance,LoginManager.GetActiveUser()));
        }


        //find account from id
        static public Account GetAccount(int id)
        {
            return accounts.Find(x => x._id == id);
        }

        static public List<Account> GetAllAccountsUser(User user)
        {
            return accounts.FindAll(x => x.Owner == user);
        }


    }
}
