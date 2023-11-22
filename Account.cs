using System;
using System.Collections.Generic;
using System.Linq;
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
        public float Balance { get; set; }
        public string Currency { get; set; }
        public float Interest { get; set; }

        public float ReservedBalance;

        public List<Account> accountLists = new List<Account>();
        public List<string> accountHistory = new List<string>();
        public List<TransactionInfo> transactionList = new List<TransactionInfo>();

        public List<object> userList { get; set; }

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
            float result = -1;

            Console.WriteLine("Please typ in the ID of the account that you want to transfer funds to.");

            while (!int.TryParse(Console.ReadLine(), out idAddFunds))
            {
                Console.WriteLine("Use only digits.");
            }

            //  checks so the user can't transfer to the same account.
            while (idAddFunds == _id)
            {
                Console.WriteLine("You can't transfer money to the same account");
                while (!int.TryParse(Console.ReadLine(), out idAddFunds))
                {
                    Console.WriteLine("Use only digits.");
                }
            }

            // Checks so the user have put in a valid number.
            Console.WriteLine("How much do you want to transfer? Use only digits please.");
            while (result < 0)
            {
                while (!float.TryParse(Console.ReadLine(), out result))
                {
                    Console.WriteLine("Use only digits.");
                }
                if (result < 0)
                {
                    Console.WriteLine("Please typ in a positiv value.");
                }
            }

            Console.Clear();
            // A loop just to get info and save it into variables.
            foreach (var holder in AccountManager.GetAllAccountsUser(LoginManager.GetActiveUser()))
            {
                if (holder._id == idAddFunds)
                {
                    idNameTo = holder.Name;
                    idAddFundsHolder = holder._id;
                    idNameToCurrency = holder.Currency;
                }
            }

            // Adds and removes balance from each account balance that the user have put in.
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
                        funds.Balance = funds.Balance + result;
                    }
                }
                Console.WriteLine("Transaction succesful.");
                accountHistory.Add($"Transaction succesful! From Account owner: {LoginManager.GetActiveUser().UserName}. Name: {Name}. ID: {_id} Funds: -{result} {Currency}. To Account owner: {LoginManager.GetActiveUser().UserName}. Name: {idNameTo}. ID: {idAddFundsHolder} Funds: +{result} {idNameToCurrency}. {DateTime.Now}");
            }
            else
            {
                Console.WriteLine("Could not make your request. Please check if you got valid funds and/or that you typed in the right ID.");
            }
        }
        public void TransactionToUser()
        {
            int inputUserId;
            float result = -1;

            Console.WriteLine("Please typ in the ID of the account you would like transfer to.");
            while (!int.TryParse(Console.ReadLine(), out inputUserId))
            {
                Console.WriteLine("Use only digits.");

            }
            //  checks so the user can't transfer to the same account.
            while (inputUserId == _id)
            {
                Console.WriteLine("You can't transfer to the same account.");
                while (!int.TryParse(Console.ReadLine(), out inputUserId))
                {
                    Console.WriteLine("Use only digits.");
                }
            }

            //Checks if the accounts exist
            var idBalance = AccountManager.GetAccount(inputUserId);
            if (idBalance == null)
            {
                Console.WriteLine("That account don't exist.");
                return;
            }

            // checks so the input is a number and got a positiv value.
            Console.WriteLine("How much would you like to transfer?");
            while (result < 0)
            {
                while (!float.TryParse(Console.ReadLine(), out result))
                {
                    Console.WriteLine("Use only digits.");
                }
                if (result < 0)
                {
                    Console.WriteLine("Please typ in a positiv value.");
                }
            }
            Console.Clear();

            if ((Balance - ReservedBalance) >= result)
            {
                transactionList.Add(new TransactionInfo(this, idBalance, result));
                Transaction trans = new Transaction("test", StartTimedTransactions);
                Menu.transaction15Min.ScheduleTransaction(trans);
                Console.WriteLine("Transaction queued.");
                ReservedBalance += result;
            }
            else
            {
                Console.WriteLine("Not enough funds.");
            }
        }
    public void Loan(User user)
    {
        // Adds all balance from every account the user have and then multiplie it with 5.
        float maxBalance = 0;
        foreach (var item in AccountManager.GetAllAccountsUser(user))
        {
            maxBalance = maxBalance + item.Balance;
        }
        maxBalance = maxBalance * 5;
        Console.WriteLine($"You are allowed to take a loan for a maxvalue of {maxBalance} SEK. Please contact the bank for futher info.");
    }
    public void AccountHistory()
    {
        // Finds a specifik user in the string list and writes out the item.
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
    private void TimedTransfere(Account toAcc, float amountToMove)
    {
        ReservedBalance -= amountToMove;
        toAcc.Balance = toAcc.Balance + amountToMove;
        Balance = Balance - amountToMove;
        Console.WriteLine("Transaction succesful.");
        accountHistory.Add($"Transaction succesful to other account!  From Account owner: {LoginManager.GetActiveUser().UserName}. Name: {Name}. ID: {_id}. Funds: -{amountToMove} {Currency}. To Account ID: {toAcc._id} Funds: +{amountToMove} {toAcc.Currency}. {DateTime.Now}");
         toAcc.accountHistory.Add($"Transaction succesful from other account!  From Account owner: {LoginManager.GetActiveUser().UserName}. Name: {Name}. ID: {_id}. Funds: -{amountToMove} {Currency}. To Account ID: {toAcc._id} Funds: +{amountToMove} {toAcc.Currency}. {DateTime.Now}");
        }
    }
}
