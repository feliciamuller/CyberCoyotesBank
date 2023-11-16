using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberCoyotesBank
{
    internal class Account
    {
        public User Owner { get; set; }
        public int _id = 0;
        public string Name { get; set; }
        public float Balance { get ; set; }
        public string Currency { get; set; }

        public List<Account> accountLists = new List<Account>();
        public List<string> accountHistory = new List<string>();

        public List<object> userList { get; set ; }

        public Account()
        {

        }

        public Account(int id, string currency, float balance)
        {
            _id = id;
            Currency = currency;
            Balance = balance;
        }

        public Account(int id, string name, string currency, float balance, User user)
        {
            Owner = user;
            Name = name;
            _id = id;
            Currency = currency;
            Balance = balance;
        }

        public void CheckBalance() 
        {
            foreach (var balance in accountLists)
            {
                Console.WriteLine($"ID : {balance._id} Account Name: \nBalance: {balance.Balance} {balance.Currency}");
            }
        }
        public void TransferMoney() 
        {
            Console.WriteLine("Your accounts:");
            foreach (var i in accountLists)
            {
                Console.WriteLine($"Account ID: {i._id} {i.Name} Balance: {i.Balance} {i.Currency}");
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
                if (holder._id == idRemoveFunds) 
                {
                    idNameFrom = holder.Name;
                    balanceHolder = holder.Balance;
                    idRemoveFundsHolder = holder._id;
                    idNameFromCurrency = holder.Currency;
                }
                else if (holder._id == idAddFunds)
                {
                    idNameTo = holder.Name;
                    idAddFundsHolder = holder._id;
                    idNameToCurrency = holder.Currency;
                }
            }

            if (idRemoveFundsHolder == idRemoveFunds && idAddFundsHolder == idAddFunds && balanceHolder >= result)
            {
                foreach (var funds in accountLists)
                {
                    if (idRemoveFunds == funds._id)
                    {
                        
                            funds.Balance = funds.Balance - result;
                        
                    }
                    else if (idAddFunds == funds._id)
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
