using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberCoyotesBank
{
    static internal class LoginManager
    {
        static public void LoginMenu(string username, string password)
        {
            //TODO Replace with users
            List<string> list = new List<string>() { "Admin", "User" };


            //TODO Replace with list.find("username") and check for password in user
            if (list.Contains(username) && password == "123")
            {
                Console.WriteLine("Welcome");
                Menu.PrintMainMenu();
            }
            else
            {
                Console.WriteLine("TryAgain");
            }

        }

    }
}
