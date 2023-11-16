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
        List<string> accountHistory = new List<string>();

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
                Console.WriteLine($"ID : {i.Id} Account Name: \nBalance: {i.Balance} {i.Currency}");
            }

        }
        public void TransferMoney() 
        {
            Console.WriteLine("Your accounts:");
            foreach (var i in accountLists)
            {
                Console.WriteLine($"Account ID: {i.Id} {i.Name} Balance: {i.Balance} {i.Currency}");
            }
            int idRemoveFundsHolder = 0;
            int idAddFundsHolder = 0;
            float balanceHolder = 0;
            string idNameFrom = "";
            string idNameTo = "";
            string idNameFromCurrency = "";
            string idNameToCurrency = "";

            Console.WriteLine("Please typ in the ID of the account that you want to transfer funds from.");
            int.TryParse(Console.ReadLine(), out int idRemoveFunds);

            Console.WriteLine("Please typ in the ID of the account that you want to transfer funds to.");
            int.TryParse(Console.ReadLine(), out int idAddFunds);

            Console.WriteLine("How much do you want to transfer? Use only digits please.");
            float.TryParse(Console.ReadLine(), out float result);

            Console.Clear();

            foreach (var holder in accountLists) 
            {
                if (holder.Id == idRemoveFunds) 
                {
                    idNameFrom = holder.Name;
                    balanceHolder = holder.Balance;
                    idRemoveFundsHolder = holder.Id;
                    idNameFromCurrency = holder.Currency;
                }
                else if (holder.Id == idAddFunds)
                {
                    idNameTo = holder.Name;
                    idAddFundsHolder = holder.Id;
                    idNameToCurrency = holder.Currency;
                }
            }

            if (idRemoveFundsHolder == idRemoveFunds && idAddFundsHolder == idAddFunds && balanceHolder >= result)
            {
                foreach (var funds in accountLists)
                {
                    if (idRemoveFunds == funds.Id)
                    {
                        
                            funds.Balance = funds.Balance - result;
                        
                    }
                    else if (idAddFunds == funds.Id)
                    {
                        
                            funds.Balance = funds.Balance + result;
                        
                    }
                }
                accountHistory.Add($"Transaction succesful! From Account name: {idNameFrom} Funds: -{result} {idNameFromCurrency}. To Account name: {idNameTo} Funds: +{result} {idNameToCurrency} {DateTime.Now}");
            }
            else 
            {
                Console.WriteLine("Could not make your request. Please check if you got valid funds and/or that you typed in the right ID.");

                accountHistory.Add($"Transaction unsuccesful! {DateTime.Now}");
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
            accountHistory.Add($"Account created! {DateTime.Now}");
        }
        public void Loan() 
        { 
            
        }
        public void AccountHistory() 
        {
            foreach (var historyCheck in accountHistory)
            {
                Console.WriteLine(historyCheck);
            }
        }
    }
}
