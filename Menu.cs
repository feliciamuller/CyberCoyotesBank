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
                    Menu.PrintMainMenu();
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
                Console.WriteLine("1. View bankaccount\n" +
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
            //TODO felhantering
            Console.WriteLine("1: View checking account\n2: View savings account\n3: All accounts");
            bool success = int.TryParse(Console.ReadLine(), out int input);
            switch (input)
            {
                case 1:
                    Console.WriteLine("List of all your checking accounts");
                    break;
                case 2:
                    Console.WriteLine("List of all your savings account");
                    break;
                case 3:
                    Console.WriteLine("List of all your accounts");
                    break;
                default:
                    Console.WriteLine("Not valid choice");
                    break;
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
                    Console.WriteLine("Create checking account");
                    break;
                case 2:
                    Console.WriteLine("Create savings account");
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
                    Console.WriteLine("Type in the bankaccount ID you want to transfer from");
                    Console.WriteLine("Type in the account ID you want to transfer to");
                    break;
                case 2:
                    Console.WriteLine("Type in the bankaccount ID you want to transfer from");
                    Console.WriteLine("Type in the customer ID and bank account ID you want to transfer to");
                    break;
                default:
                    Console.WriteLine("Not valid choice");
                    break;
            }
        }
        public static void MenuOption4()
        {
            //Lån max 5ggr tillgångar
            Console.WriteLine("Apply for a loan and see interest");
        }
        public static void MenuOption5()
        {
            Console.WriteLine("Show activity");
        }
        public static void MenuOption0()
        {
            Console.WriteLine("Logging out");
        }

        public static void PrintMainMenuAdmin()
        {
            while(true)
            {
                Console.Clear();
                Console.WriteLine("-----------ADMIN VIEW-------------------");
                Console.WriteLine("What do you want to do");
                Console.WriteLine();
                Console.WriteLine("1. Create new users" +
                    "2. Update exchange rate" +
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
            
        }

    }
}


