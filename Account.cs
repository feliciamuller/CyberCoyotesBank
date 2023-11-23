using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CyberCoyotesBank
{
    internal class Account
    {
        public string userName;
        public User Owner { get; set; }
        public int _id = 0;
        public string Name { get; set; }
        public double Balance { get; set; }
        public string Currency { get; set; }
        public float Interest { get; set; }

        public double ReservedBalance;

        public List<Account> accountLists = new List<Account>();
        public List<string> accountHistory = new List<string>();
        public List<TransactionInfo> transactionList = new List<TransactionInfo>();
        public ExchangeRate exchangeRate { get; set; }

        public Account()
        {

        }

        public Account(int id, string currency, double balance)
        {
            _id = id;
            Currency = currency;
            Balance = balance;
        }

        public Account(int id, string name, string currency, double balance, User user)
        {
            Owner = user;
            Name = name;
            _id = id;
            Currency = currency;
            Balance = balance;
        }
        public Account(int id, string name, string currency, float balance, float interest, User user)
        {
            Owner = user;
            Name = name;
            _id = id;
            Currency = currency;
            Balance = balance;
            Interest = interest;
        }
        public void TransferMoney()
        {
            int idAddFundsHolder = 0;
            string idNameTo = "";
            string idNameToCurrency = "";
            int idAddFunds;
            double result = -1;
            double resultToAccount = 0;
            Console.WriteLine("Please enter the ID of the account that you want to transfer funds to.");

            while (!int.TryParse(Console.ReadLine(), out idAddFunds))
            {
                Console.WriteLine("Enter only digits.");
            }

            // Checks so the user can't transfer to the same account
            while (idAddFunds == _id)
            {
                Console.WriteLine("You can't transfer money to the same account");
                while (!int.TryParse(Console.ReadLine(), out idAddFunds))
                {
                    Console.WriteLine("Enter only digits.");
                }
            }

            // Checks so the user have put in a valid number
            Console.WriteLine("How much do you want to transfer? Enter only digits please.");
            while (result < 0)
            {
                while (!double.TryParse(Console.ReadLine(), out result))
                {
                    Console.WriteLine("Please, enter only digits.");
                }
                if (result < 0)
                {
                    Console.WriteLine("Please enter a positiv value.");
                }
            }

            Console.Clear();
            // A loop just to get info and save it into variables
            foreach (var holder in AccountManager.GetAllAccountsUser(LoginManager.GetActiveUser()))
            {
                if (holder._id == idAddFunds)
                {
                    idNameTo = holder.Name;
                    idAddFundsHolder = holder._id;
                    idNameToCurrency = holder.Currency;
                }
            }

            // Adds and removes balance from each account balance that the user have put in
            if (idAddFundsHolder == idAddFunds && (Balance - ReservedBalance) >= result)
            {
                foreach (var funds in AccountManager.GetAllAccountsUser(LoginManager.GetActiveUser()))
                {
                    if (_id == funds._id)
                    {
                        funds.Balance = funds.Balance - result;
                        
                    }
                    else if (idAddFunds == funds._id)
                    {
                        if (Currency == funds.Currency) 
                        {
                            funds.Balance = funds.Balance + result;
                            resultToAccount = result;
                        }
                        else if (funds.Currency == "dollar" && Currency == "sek")
                        {
                            funds.Balance = funds.Balance + result * Menu.exchangeRate.Dollar;
                            resultToAccount = result * Menu.exchangeRate.Dollar;
                        }
                        else if (funds.Currency == "euro" && Currency == "sek")
                        {
                            funds.Balance = funds.Balance + result * Menu.exchangeRate.Euro;
                            resultToAccount = result * Menu.exchangeRate.Euro;
                        }
                        else if (funds.Currency == "sek" && Currency == "euro")
                        {
                            funds.Balance = funds.Balance + result / Menu.exchangeRate.Euro;
                            resultToAccount = result / Menu.exchangeRate.Euro;
                        }
                        else if (funds.Currency == "dollar" && Currency == "euro")
                        { 
                            funds.Balance = funds.Balance + (result / Menu.exchangeRate.Euro) * Menu.exchangeRate.Dollar;
                            resultToAccount = (result / Menu.exchangeRate.Euro) * Menu.exchangeRate.Dollar;
                        }
                        else if (funds.Currency == "sek" && Currency == "dollar")
                        {
                            funds.Balance = funds.Balance + result / Menu.exchangeRate.Dollar;
                            resultToAccount = result / Menu.exchangeRate.Dollar;
                        }
                        else if (funds.Currency == "euro" && Currency == "dollar")
                        {
                            funds.Balance = funds.Balance + (result / Menu.exchangeRate.Dollar) * Menu.exchangeRate.Euro;
                            resultToAccount = (result / Menu.exchangeRate.Dollar) * Menu.exchangeRate.Euro;
                        }
                    }
                }
                Console.WriteLine("The transaction was successful.");
                accountHistory.Add($"The transaction was successful! From Account owner: {LoginManager.GetActiveUser().UserName}. Name: {Name}. ID: {_id} Funds: -{result} {Currency}. To Account owner: {LoginManager.GetActiveUser().UserName}. Name: {idNameTo}. ID: {idAddFundsHolder} Funds: +{resultToAccount} {idNameToCurrency}. {DateTime.Now}");
            }
            else
            {
                Console.WriteLine("We could not make your request. Please check if you got valid funds and/or that you typed in the right ID.");
            }
        }
        public void TransactionToUser()
        {
            int inputUserId;
            float result = -1;

            Console.WriteLine("Please enter the ID of the account you would like transfer to.");
            while (!int.TryParse(Console.ReadLine(), out inputUserId))
            {
                Console.WriteLine("Please, enter only digits.");

            }
            // Checks so the user can't transfer to the same account
            while (inputUserId == _id)
            {
                Console.WriteLine("You can't transfer to the same account.");
                while (!int.TryParse(Console.ReadLine(), out inputUserId))
                {
                    Console.WriteLine("Please, enter only digits.");
                }
            }

            // Checks if the accounts exist
            var idBalance = AccountManager.GetAccount(inputUserId);
            if (idBalance == null)
            {
                Console.WriteLine("The account you entered doesn´t exist.");
                return;
            }

            // Checks so the input is a number and got a positiv value
            Console.WriteLine("How much would you like to transfer?");
            while (result < 0)
            {
                while (!float.TryParse(Console.ReadLine(), out result))
                {
                    Console.WriteLine("Please, enter only digits.");
                }
                if (result < 0)
                {
                    Console.WriteLine("Please enter a positiv value.");
                }
            }
            Console.Clear();

            if ((Balance - ReservedBalance) >= result)
            {
                double resultToUser = 0;
                if (Currency == idBalance.Currency)
                {
                    resultToUser = result;
                }
                else if (idBalance.Currency == "dollar" && Currency == "sek")
                {
                    resultToUser = resultToUser + result * Menu.exchangeRate.Dollar;
                }
                else if (idBalance.Currency == "euro" && Currency == "sek")
                {
                    resultToUser = resultToUser + result * Menu.exchangeRate.Euro;
                }
                else if (idBalance.Currency == "sek" && Currency == "euro")
                {
                    resultToUser = resultToUser + result / Menu.exchangeRate.Euro;
                }
                else if (idBalance.Currency == "dollar" && Currency == "euro")
                {
                    resultToUser = resultToUser + (result / Menu.exchangeRate.Euro) * Menu.exchangeRate.Dollar;
                }
                else if (idBalance.Currency == "sek" && Currency == "dollar")
                {
                    resultToUser = resultToUser + result / Menu.exchangeRate.Dollar;
                }
                else if (idBalance.Currency == "euro" && Currency == "dollar")
                {
                    resultToUser = resultToUser + (result / Menu.exchangeRate.Dollar) * Menu.exchangeRate.Euro;
                }
                transactionList.Add(new TransactionInfo(this, idBalance, resultToUser));
                Transaction trans = new Transaction("test", StartTimedTransactions);
                Menu.transaction15Min.ScheduleTransaction(trans);
                Console.WriteLine("The transaction is queued.");
                ReservedBalance += result;
            }
            else
            {
                Console.WriteLine("You don´t have enough funds.");
            }
        }
    public void Loan(User user)
    {
            // Adds all balance from every account the user have and then multiplie it with 5
            double maxBalance = 0;
        foreach (var item in AccountManager.GetAllAccountsUser(user))
        {
                if (item.Currency == "SEK")
                {
                    maxBalance = maxBalance + item.Balance;
                }
                else if (item.Currency == "USD")
                {
                    maxBalance = maxBalance + (item.Balance * 10.48);
                }
                else
                {
                    maxBalance = maxBalance + (item.Balance * 13.12);
                }
            }
        maxBalance = maxBalance * 5;
        Console.WriteLine($"You are allowed to take a loan for a maxvalue of {maxBalance} SEK. Please contact the bank for futher info.");
    }
    public void AccountHistory()
    {
        // Finds a specifik user in the string list and writes out the item
        foreach (var item in accountHistory)
        {
            Console.WriteLine(item);
        }
    }
    public void StartTimedTransactions()
    {
        foreach (var transaction in transactionList)
        {
            TimedTransfere(transaction.ToAcc, transaction.AmountToMove);
        }
        transactionList.Clear();
    }
    private void TimedTransfere(Account toAcc, double amountToMove)
    {
        ReservedBalance -= amountToMove;
        toAcc.Balance = toAcc.Balance + amountToMove;
        Balance = Balance - amountToMove;
        Console.WriteLine("The transaction was successful.");
        accountHistory.Add($"The transaction was successful to the other account!  From Account owner: {LoginManager.GetActiveUser().UserName}. Name: {Name}. ID: {_id}. Funds: -{amountToMove} {Currency}. To Account ID: {toAcc._id} Funds: +{amountToMove} {toAcc.Currency}. {DateTime.Now}");
         toAcc.accountHistory.Add($"The transaction was successful from the other account!  From Account owner: {LoginManager.GetActiveUser().UserName}. Name: {Name}. ID: {_id}. Funds: -{amountToMove} {Currency}. To Account ID: {toAcc._id} Funds: +{amountToMove} {toAcc.Currency}. {DateTime.Now}");
        }
    }
}
