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

    }
}
