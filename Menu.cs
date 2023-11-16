using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CyberCoyotesBank
{
    static class Menu
    {

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
                    Console.WriteLine("press any key to exit app");
                    Console.ReadKey();

                    Environment.Exit(0);


                }
            }
        }
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
                    "0. Logout");

                bool success = int.TryParse(Console.ReadLine(), out int input);
                if (!success) { continue; }
                Console.Clear();
                switch (input)
                {
                    case 1:
                        MenuOption1();
                        Console.WriteLine("Press any key to continue!");
                        Console.ReadKey();
                        break;
                    case 2:
                        MenuOption2();
                        Console.WriteLine("Press any key to continue!");
                        Console.ReadKey();
                        break;
                    case 3:
                        MenuOption3();
                        Console.WriteLine("Press any key to continue!");
                        Console.ReadKey();
                        break;
                    case 4:
                        MenuOption4();
                        Console.WriteLine("Press any key to continue!");
                        Console.ReadKey();
                        break;
                    case 5:
                        MenuOption5();
                        Console.WriteLine("Press any key to continue!");
                        Console.ReadKey();
                        break;
                    case 0:
                        MenuOption0();
                        Console.WriteLine("Press any key to continue!");
                        Console.ReadKey();
                        break;
                }
            }
        }
        public static void MenuOption1()
        {
            User user = LoginManager.GetActiveUser();
            foreach (Account account in AccountManager.GetAllAccoutsUser(user))
            {
                Console.WriteLine($"Account ID: {account.Id} Account name: {account.Name} Currency: {account.Currency} Balance: {account.Balance}");
            }
        }
        public static void MenuOption2()
        {
            //TODO felhantering
            Console.WriteLine("1: Create checking account\n2: Create savings account");
            bool success = int.TryParse(Console.ReadLine(), out int input);
            switch (input)
            {
                case 1:
                    Console.WriteLine("Name of the account: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Currency: ");
                    string currency = Console.ReadLine();
                    Console.WriteLine("Set balance: ");
                    float balance = float.Parse(Console.ReadLine());//felhantering

                    AccountManager.CreateAccount(name, currency, balance);
                    break;
                case 2:
                    Console.WriteLine("Savings account not impemented yet");
                    break;
                default:
                    Console.WriteLine("Not valid choice");
                    break;
            }
        }
        public static void MenuOption3()
        {
            //TODO felhantering
            Console.WriteLine("1: Transfer money between your accounts\n2: Transfer money to another customers account");
            bool success = int.TryParse(Console.ReadLine(), out int input);
            switch (input)
            {
                case 1:
                    Account transferMoney = new Account();
                    transferMoney.TransferMoney();
                    break;
                case 2:
                    Account transactionToUser = new Account();
                    transactionToUser.TransactionToUser();
                    break;
                default:
                    Console.WriteLine("Not valid choice");
                    break;
            }
        }
        public static void MenuOption4()
        {
            Account loan = new Account();
            loan.Loan();
            
        }
        public static void MenuOption5()
        {
            Account history = new Account();
            history.AccountHistory();
        }
        public static void MenuOption0()
        {
            Environment.Exit(0);
        }

        public static void PrintMainMenuAdmin()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("-----------ADMIN VIEW-------------------");
                Console.WriteLine("What do you want to do");
                Console.WriteLine();
                Console.WriteLine("1. Create new users\n" +
                    "2. Update exchange rate\n" +
                    "3. View list of users\n" +
                    "0. Logout");

                bool success = int.TryParse(Console.ReadLine(), out int input);
                if (!success) { continue; }
                Console.Clear();
                switch (input)
                {
                    case 1:
                        AdminMenuOption1();
                        Console.WriteLine("Press any key to continue!");
                        Console.ReadKey();
                        break;
                    case 2:
                        AdminMenuOption2();
                        Console.WriteLine("Press any key to continue!");
                        Console.ReadKey();
                        break;
                    case 3:
                        AdminMenuOption3();
                        Console.WriteLine("Press any key to continue!");
                        Console.ReadKey();
                        break;
                    case 0:
                        AdminMenuOption0();
                        Console.WriteLine("Press any key to continue!");
                        Console.ReadKey();
                        break;
                }

            }
        }

        public static void AdminMenuOption1()
        {
            bool isAdmin;

            Console.WriteLine("Type in username");
            string username = Console.ReadLine();
            Console.WriteLine("Type in password");
            string password = Console.ReadLine();
            Console.WriteLine("Admin or User?");
            string role = Console.ReadLine(); //TODO felhantering
            if (role == "Admin")
            {
                isAdmin = true;
                UserManager.CreateUser(username, password, isAdmin);
            }
            else if (role == "User")
            {
                isAdmin = false;
                UserManager.CreateUser(username, password, isAdmin);
            }
        }

        public static void AdminMenuOption2()
        {
            Console.WriteLine("Hantera växelkurs");
        }

        public static void AdminMenuOption3()
        {
            Console.WriteLine("1. View list of users\n2. View list of admins\n3. View list of all admins and users");
            bool success = int.TryParse(Console.ReadLine(), out int input);//TODO felhantering

            switch(input)
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
                    Console.WriteLine("Wrong choice");
                    break;
            }

        }

        public static void AdminMenuOption0()
        {
            Environment.Exit(0);
        }

    }
}


