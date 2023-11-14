using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CyberCoyotesBank
{
    internal class Admin
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int Id { get; set; }

        public Admin(string username, string password, int id)
        {
            Username = username;
            Password = password;
            Id = id;
        }

        public int CreateUser()
        {
            Console.WriteLine("Skriv in användarnamn: ");
            Username = Console.ReadLine();
            Console.WriteLine("Skriv in lösenord: ");
            Password = Console.ReadLine();
            Random random = new Random();
            //här behöver vi kontrollera så Id inte är samma som någon annan
            Id = random.Next(1,50);

            return Id; //vet ej om detta är nödvändigt
        }

        public void UpdateExchangeRate()
        {
            Console.WriteLine("Växelkursen 2023-11-13 är:\n1 USD = 11,88\n1 EUR = 12,55\n1 GBP = 14,34");
        }


    }
}
