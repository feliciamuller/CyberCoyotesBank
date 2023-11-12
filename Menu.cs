using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CyberCoyotesBank
{
    static class Menu
    {

        static public void PrintLogin()
        {
            Console.WriteLine("Username:");
           string usernameInput = Console.ReadLine();

            Console.WriteLine("Password:");
            string passwordInput = Console.ReadLine();

            if (LoginManager.Login(usernameInput,passwordInput))
            {
                Menu.PrintMainMenu();
            }
            else
            {
                Console.WriteLine("Wong username or password");
                //TODO Loop and lock after 3 login attempts
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
                Console.WriteLine("1. open bankaccount\n" +
                    "2. create new bankaccont\n" +
                    "0. Logout");

                int input = Int32.Parse(Console.ReadLine());
                Console.Clear();
                switch (input)
                {
                    case 1:
                        Console.WriteLine("Open bankaccount not implemented");
                        Console.WriteLine("Press any key to continue!");
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.WriteLine("Create bankaccont not implemented");
                        Console.WriteLine("Press any key to continue!");
                        Console.ReadKey();
                        break;

                    case 0:
                        Console.WriteLine("Logout not implemented. you are stuck here");
                        Console.WriteLine("Press any key to continue!");
                        Console.ReadKey();
                        break;
                }
            }

            





        }

    }
}
