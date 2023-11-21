using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CyberCoyotesBank
{
    static class Menu
    {
        //creates instance of timer for delayed tranactions
        public static Transaction15min transaction15Min = new Transaction15min();

        //check conditions for username and password and manage login
        static public void PrintLogin()
        {
           
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
                    Console.WriteLine("Wong username or password");
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
        //print user menu and call methods depending on key
        static public void PrintMainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("-----------BANK-------------------");
                Console.WriteLine("What do you want to do");
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
                        Console.WriteLine("Wrong choice, press any key to go back to menu and try again");
                        Console.ReadKey();
                        break;
                }
            }
        }
        public static void MenuOption1()
        {
            //print out account list of logged in user
            User user = LoginManager.GetActiveUser();
            foreach (Account account in AccountManager.GetAllAccountsUser(user))
            {
                Console.WriteLine($"Account ID: {account._id} Account name: {account.Name} Currency: {account.Currency} Balance: {account.Balance}");
            }
        }
        //print menu and call methods for creating bank account
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
                        Console.WriteLine("Savings account not impemented yet");
                        break;
                    default:
                        Console.WriteLine("Not valid choice, press 1 or 2");
                        continue;
                    }  
                break;
            }
        }
        //receive input parameter from user and add it to create account method
        public static void MenuOptionCreateCheckingAccount()
        {
            Console.WriteLine("Name of the account: ");
            string name = Console.ReadLine();
            Console.WriteLine("Currency: ");
            string currency = Console.ReadLine();
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
                    Console.WriteLine("Balance can only be in numbers, try again");
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
                        Console.WriteLine("Not valid choice, try again");
                        continue;
                }
                break;
            }
        }

        private static Account GetAccountToTransferFrom()
        {
            int accountToUse;
            var userInput = AccountManager.GetAllAccountsUser(LoginManager.GetActiveUser());
            Console.WriteLine("Your accounts:");
            foreach (var i in AccountManager.GetAllAccountsUser(LoginManager.GetActiveUser()))
            {
                Console.WriteLine($"Account ID: {i._id} {i.Name}. \nBalance: {i.Balance} {i.Currency}");
            }

            Console.WriteLine("Please typ in the ID of the account that you want to transfer funds from.");
            while (!int.TryParse(Console.ReadLine(), out accountToUse))
            {
                Console.WriteLine("Use only digits.");
            }

           return AccountManager.GetAccount(accountToUse);
        }

        //apply for loan
        public static void MenuOption4()
        {
            Account loan = new Account();
            loan.Loan(LoginManager.GetActiveUser());
        }
        //view account history
        public static void MenuOption5()
        {
            foreach (Account account in AccountManager.GetAllAccountsUser(LoginManager.GetActiveUser()))
            {
                account.AccountHistory();
            }
            
        }
        //exit program
        public static void MenuOption6()
        {
            PrintLogin();
            //Environment.Exit(6);
        }
        //print admin view and call methods depending on key
        public static void PrintMainMenuAdmin()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("-----------ADMIN VIEW-------------------");
                Console.WriteLine("What do you want to do");
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
        //receive input parameters from user and add it to create user method
        public static void AdminMenuOption1()
        {
            bool isAdmin;
            
            Console.WriteLine("Type in username");
            string username = Console.ReadLine();
            Console.WriteLine("Type in password");
            string password = Console.ReadLine();
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

        //update exchange rate
        public static void AdminMenuOption2()
        {
            Console.WriteLine("Hantera växelkurs");
        }
        //print out users or admins through methods
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
        //exit program
        public static void AdminMenuOption4()
        {
            Environment.Exit(4);
        }
    }
}


