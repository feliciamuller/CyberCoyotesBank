using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CyberCoyotesBank
{
    static class Menu
    {
        // Creates instance of timer for delayed transactions
        public static Transaction15min transaction15Min = new Transaction15min();
        // Create object of exchange rate 
        public static ExchangeRate exchangeRate = new ExchangeRate(0.0952f, 0.0875f);

        // Check conditions for username and password and manage login
        static public void PrintLogin()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            int loginAttempts = 0;
            while (loginAttempts < 3)
            {
                Console.WriteLine(@" __| |____________________| |__ 
(__| |____________________| |__)
   | |  CyberCoyotesBank  | |   
 __| |____________________| |__ 
(__|_|____________________|_|__)");

                Console.WriteLine("Username:");
                string usernameInput = Console.ReadLine();

                Console.WriteLine("Password:");
                string passwordInput = Console.ReadLine();
                loginAttempts++;
                if (LoginManager.Login(usernameInput, passwordInput))
                {
                    if(LoginManager.GetActiveUser().GetType().Name == "Admin")
                    {
                        Menu.PrintMainMenuAdmin();
                    }
                    else
                    {
                        Menu.PrintMainMenu();
                    }
                }
                else
                {
                    Console.WriteLine("Wrong username or password");
                }

                if (loginAttempts == 3)
                {
                    Console.WriteLine("Too many attempts");
                    Console.WriteLine("Press any key to exit app");
                    Console.ReadKey();
                    Environment.Exit(0);
                } 
            }
        }
        // Print user menu and call methods depending on key
        static public void PrintMainMenu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("-----------BANK-------------------");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine();
                Console.WriteLine("1. View list of all your bankaccounts\n" +
                    "2. Create new bankaccount\n" +
                    "3. Transfer money\n" +
                    "4. Make a loan\n" +
                    "5. View history log on my accounts\n" +
                    "6. Logout");

                int.TryParse(Console.ReadLine(), out int input);
                Console.Clear();
                switch (input)
                {
                    case 1:
                        MenuOption1();
                        Console.WriteLine("Press any key to go back to menu");
                        Console.ReadKey();
                        break;
                    case 2:
                        MenuOption2();
                        Console.WriteLine("Press any key to go back to menu");
                        Console.ReadKey();
                        break;
                    case 3:
                        MenuOption3();
                        Console.WriteLine("Press any key to go back to menu");
                        Console.ReadKey();
                        break;
                    case 4:
                        MenuOption4();
                        Console.WriteLine("Press any key to go back to menu");
                        Console.ReadKey();
                        break;
                    case 5:
                        MenuOption5();
                        Console.WriteLine("Press any key to go back to menu");
                        Console.ReadKey();
                        break;
                    case 6:
                        MenuOption6();
                        Console.WriteLine("Press any key to go back to menu");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Wrong choice, press any key to go back to the menu and try again");
                        Console.ReadKey();
                        break;
                }
            }
        }
        public static void MenuOption1()
        {
            // Print out account list of logged in user
            User user = LoginManager.GetActiveUser();
            
            foreach (Account account in AccountManager.GetAllAccountsUser(user))
            {

                // Check conditions if there is interest on the account
                if(account.Interest == 0)
                {
                    Console.WriteLine("Type of account: Checking account");
                    Console.WriteLine($"Account ID: {account._id}\nAccount name: {account.Name}\nCurrency: {account.Currency}\nBalance: {Math.Round(account.Balance, 2)} ({account.ReservedBalance})");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Type of account: Savings account");
                    Console.WriteLine($"Account ID: {account._id}\nAccount name: {account.Name}\nCurrency: {account.Currency}\nBalance: {Math.Round(account.Balance, 2)} ({account.ReservedBalance})\nInterest: {account.Interest}%");
                    Console.WriteLine();
                }
            }
        }
        // Print menu and call methods for creating bank account
        public static void MenuOption2()
        {
            while(true)
            {
                Console.WriteLine("1: Create checking account\n2: Create savings account");
                int.TryParse(Console.ReadLine(), out int input);
                switch (input)
                {
                    case 1:
                        MenuOptionCreateCheckingAccount();
                        break;
                    case 2:
                        MenuOptionCreateSavingsAccount();
                        break;
                    default:
                        Console.WriteLine("That is not a valid choice, press 1 or 2");
                        continue;
                    }  
                break;
            }
        }
        // Receive input parameter from user and add it to create account method
        public static void MenuOptionCreateCheckingAccount()
        {
            string name;
            string currency;
            while(true)
            {
                Console.WriteLine("Name of the account: ");
                name = Console.ReadLine();
                if (name == "")
                {
                    Console.WriteLine("Name can not be empty");
                }
                else
                {
                    break;
                }
                
            }

            while(true)
            {
                Console.WriteLine("What currency?");
                Console.WriteLine("Enter SEK, Dollar or Euro");
                currency = Console.ReadLine().ToLower();

                switch (currency)
                {
                    case "sek":
                        break;
                    case "dollar":
                        break;
                    case "euro":
                        break;
                    default:
                        Console.WriteLine("You can only enter SEK, Dollar or Euro");
                        continue;
                }
                break;
            }

            while (true)
            {
                Console.WriteLine("Set balance: ");
                bool success = float.TryParse(Console.ReadLine(), out float balance);
                if (success)
                {
                    AccountManager.CreateAccount(name, currency, balance);
                    break;
                }
                else
                {
                    Console.WriteLine("Balance can only be in numbers, please try again");
                } 
            }
            
        }

        // Receive input parameter from user and add it to create savings account method
        public static void MenuOptionCreateSavingsAccount()
        {
            string name;
            string currency;
            while (true)
            {
                Console.WriteLine("Name of the account: ");
                name = Console.ReadLine();
                if (name == "")
                {
                    Console.WriteLine("Name can not be empty");
                }
                else
                {
                    break;
                }

            }

            while (true)
            {
                Console.WriteLine("What currency?");
                Console.WriteLine("Enter SEK, Dollar or Euro");
                currency = Console.ReadLine().ToLower();

                switch (currency)
                {
                    case "sek":
                        break;
                    case "dollar":
                        break;
                    case "euro":
                        break;
                    default:
                        Console.WriteLine("You can only enter SEK, Dollar or Euro");
                        continue;
                }
                break;
            }

            while (true)
            {
                Console.WriteLine("Set balance: ");
                bool success = float.TryParse(Console.ReadLine(), out float balance);
                if (success)
                {
                    //conditions to decide interest rate
                    if (balance > 10000 )
                    {
                        float interest = 3;
                        AccountManager.CreateSavingsAccount(name, currency, balance, interest);
                        break;
                    }
                    else
                    {
                        float interest = 1.5f;
                        AccountManager.CreateSavingsAccount(name, currency, balance, interest);
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Balance can only be in numbers, please try again");
                }
            }
        }
        //print menu and call different methods to transfer money
        public static void MenuOption3()
        {
            while(true)
            {
                
                Console.WriteLine("1: Transfer money between your accounts\n2: Transfer money to another customers account");
                int.TryParse(Console.ReadLine(), out int input);
                switch (input)
                {
                    case 1:
                        Account acc = GetAccountToTransferFrom();

                        acc.TransferMoney();
                        break;
                    case 2:
                        acc = GetAccountToTransferFrom();
                        acc.TransactionToUser();
                        break;
                    default:
                        Console.WriteLine("That is not a valid choice, please try again");
                        continue;
                }
                break;
            }
        }

        private static Account GetAccountToTransferFrom() // writes all your accounts and checks so you pick a valid account that's your own.
        {
            int accountToUse;
            Console.WriteLine("This is your accounts:");
            foreach (var i in AccountManager.GetAllAccountsUser(LoginManager.GetActiveUser()))
            {
                Console.WriteLine($"Account ID: {i._id} {i.Name}. \nBalance: {Math.Round(i.Balance, 2)} {i.Currency}");
            }

            Console.WriteLine("Please enter the ID of the account that you want to transfer funds from.");
            while (!int.TryParse(Console.ReadLine(), out accountToUse))
            {
                Console.WriteLine("Please, enter only digits.");
            }
            while (true) 
            {
                foreach (var item in AccountManager.GetAllAccountsUser(LoginManager.GetActiveUser()))
                {
                    if (accountToUse == item._id)
                    {
                        return AccountManager.GetAccount(accountToUse);
                    }
                }
                Console.WriteLine("Please enter an account you own.");

                while (!int.TryParse(Console.ReadLine(), out accountToUse))
                {
                    Console.WriteLine("Please, enter only digits.");
                }
            }
            return AccountManager.GetAccount(accountToUse);
        }

        // Apply for loan
        public static void MenuOption4()
        {
            Account loan = new Account();
            loan.Loan(LoginManager.GetActiveUser());
        }
        // View account history
        public static void MenuOption5()
        {
            foreach (Account account in AccountManager.GetAllAccountsUser(LoginManager.GetActiveUser()))
            {
                account.AccountHistory();
            }
            
        }
        // Print login menu
        public static void MenuOption6()
        {
            PrintLogin();
        }
        // Print admin view and call methods depending on key
        public static void PrintMainMenuAdmin()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("-----------ADMIN VIEW-------------------");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine();
                Console.WriteLine("1. Create new user or admin\n" +
                    "2. Update exchange rate\n" +
                    "3. View list of users and admins\n" +
                    "4. Logout");

                int.TryParse(Console.ReadLine(), out int input);
                Console.Clear();
                switch (input)
                {
                    case 1:
                        AdminMenuOption1();
                        Console.WriteLine("Press any key to go back to menu");
                        Console.ReadKey();
                        break;
                    case 2:
                        AdminMenuOption2();
                        Console.WriteLine("Press any key to go back to menu");
                        Console.ReadKey();
                        break;
                    case 3:
                        AdminMenuOption3();
                        Console.WriteLine("Press any key to go back to menu");
                        Console.ReadKey();
                        break;
                    case 4:
                        AdminMenuOption4();
                        Console.WriteLine("Press any key to go back to menu");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Wrong choice, press any key to go back to menu and try again");
                        Console.ReadKey();
                        break;
                }

            }
        }
        // Receive input parameters from user and add it to create user method
        public static void AdminMenuOption1()
        {
            bool isAdmin;
            string username;
            string password;
            while(true)
            {
                Console.WriteLine("Type in username");
                username = Console.ReadLine();
                if (username == "")
                {
                    Console.WriteLine("Username can not be empty");
                }
                else
                {
                    break;
                }
            }

            while(true)
            {
                Console.WriteLine("Type in password");
                password = Console.ReadLine();
                if (password == "")
                {
                    Console.WriteLine("Password can not be empty");
                }
                else
                {
                    break;
                }
            }

            while(true)
            {
                Console.WriteLine("Admin or User?");
                string role = Console.ReadLine().ToLower();
                if (role == "admin")
                {
                    isAdmin = true;
                    UserManager.CreateUser(username, password, isAdmin);
                    break;
                }
                else if (role == "user")
                {
                    isAdmin = false;
                    UserManager.CreateUser(username, password, isAdmin);
                    break;
                }
                else
                {
                    Console.WriteLine("You can only type in Admin or User");
                }
            }
        }

        // Update exchange rate
        public static void AdminMenuOption2()
        {
            exchangeRate.UpdateExchangeRate();

        }
        // Print out users or admins through methods
        public static void AdminMenuOption3()
        {
            while(true)
            {
                Console.WriteLine("1. View list of users\n2. View list of admins\n3. View list of all admins and users");
                int.TryParse(Console.ReadLine(), out int input);
                switch (input)
                {
                    case 1:
                        foreach (User user in UserManager.GetUsersList())
                        {
                            Console.WriteLine(user.UserName);
                        }
                        break;
                    case 2:
                        foreach (User user in UserManager.GetAdminsList())
                        {
                            Console.WriteLine(user.UserName);
                        }
                        break;
                    case 3:
                        foreach (User user in UserManager.GetUsersAndAdmins())
                        {
                            Console.WriteLine(user.UserName);
                        }
                        break;
                    default:
                        Console.WriteLine("Not valid choice, try again");
                        continue;
                }
                break;
            }
        }
        // Print login menu
        public static void AdminMenuOption4()
        {
            PrintLogin();
        }
    }
}


