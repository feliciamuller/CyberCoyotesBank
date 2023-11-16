using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CyberCoyotesBank
{
    internal class Admin : User 
    {
        public Admin(string username, string password, int id) 
            : base (username, password, id)
        {

        }

        public void UpdateExchangeRate() //EV göra om detta till en egen klass
        {
            Console.WriteLine("Växelkursen 2023-11-13 är:\n1 USD = 11,88\n1 EUR = 12,55\n1 GBP = 14,34");
        }


    }
}
