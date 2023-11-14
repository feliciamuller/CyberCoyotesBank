using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberCoyotesBank
{

    public class AccountList
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public float AccountBalance { get; set; }
        public string Currency { get; set; }

        public AccountList()
        {
            
        }
        public AccountList(int id, string name, float accountBalance, string currency)
        {
            ID = id;
            Name = name;
            AccountBalance = accountBalance;
            Currency = currency;
        }
    }
    internal class Account
    {
        int Id = 0;
        string Name { get; set; }
        float Balance { get ; set; }
        string Currency { get; set; }

        List<Account> accountLists = new List<Account>();
        List<Account> accountNames = new List<Account>();
        public List<object> userList { get; set ; }

        public Account()
        {

        }

        public Account(int id, string currency, float balance)
        {
            Id = id;
            Currency = currency;
            Balance = balance;
        }

        public Account(int id, string name, string currency, float balance)
        {
            Name = name;
            Id = id;
            Currency = currency;
            Balance = balance;
        }

        public void CheckBalance() 
        {
            foreach (var i in accountLists)
            {
                Console.WriteLine($"ID : {i.Id} {i.Name} \nBalance: {i.Balance} {i.Currency}");
            }
        }

        public void TransferMoney() 
        {
            foreach (var i in accountLists)
            {
                Console.WriteLine($"Account ID: {i.Id} {i.Name} Balance: {i.Balance} {i.Currency}");
            }

            int.TryParse(Console.ReadLine(), out int idDebit);
            int.TryParse(Console.ReadLine(), out int idKredit);
            float.TryParse(Console.ReadLine(), out float result);

            foreach (var debit in accountLists) 
            {
                if (debit.Id == idDebit) 
                {
                    debit.Balance = debit.Balance - result;
                }
            }

            foreach (var kredit in accountLists)
            {

                if (kredit.Id == idKredit)
                {
                    
                    kredit.Balance = kredit.Balance + result;
                }

            }
        }
        public void TransactionToUser()
        {
            foreach (var i in accountLists)
            {

                Console.WriteLine($"Account Name: {i.Name}");
            }

            string userInputName = Console.ReadLine();
            float.TryParse(Console.ReadLine(), out float result);

            foreach (var i in accountLists)
            {
                 
                if (i.Name == userInputName)
                {
                    
                    i.Balance = i.Balance + result;
                }

            }
        }
        public void CreateAccount(string name, float balance, string currency) 
        {

            accountLists.Add(new Account(Id++, name, currency, balance));
        }
        public void Loan() 
        { 
            
        }
        public void AccountHistory() 
        { 
            
        }
    }
}
