using System.Diagnostics.SymbolStore;
using System.Runtime.InteropServices;

namespace CyberCoyotesBank
{
    internal class Program
    {
        static void Main(string[] args)
        {
           // Menu.PrintLogin();

            TESTNEWUSER();
        }

        private static void TESTNEWUSER()
        {
            Console.WriteLine("new username: ");
            string usern = Console.ReadLine();

            Console.WriteLine("new password: ");
            string pass = Console.ReadLine();

            UserManager.CreateUser(usern, pass);

            foreach (User user in UserManager.Users)
            {
                Console.WriteLine($"Username: {user.UserName}");
                Console.WriteLine($"Password: {user.Password}");
                Console.WriteLine($"ID:{user.ID} ");
                Console.WriteLine("****************************");
            }

            Console.WriteLine("new username: ");
             usern = Console.ReadLine();

            Console.WriteLine("new password: ");
             pass = Console.ReadLine();

            UserManager.CreateUser(usern, pass);

            foreach (User user in UserManager.Users)
            {
                Console.WriteLine($"Username: {user.UserName}");
                Console.WriteLine($"Password: {user.Password}");
                Console.WriteLine($"ID:{user.ID} ");
                Console.WriteLine("****************************");
            }
        }
    }
}