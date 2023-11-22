using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberCoyotesBank
{
    public class ExchangeRate
    {
        public float Dollar { get; set; }
        public float Euro { get; set; }

        public ExchangeRate(float dollar, float euro)
        {
            Dollar = dollar;
            Euro = euro;
        }

        public void UpdateExchangeRate()
        {
            // Print current exchange value
            Console.WriteLine($"Current exchange rate is 1 dollar = {Dollar} SEK");
            Console.WriteLine($"Current exchange rate is 1 Euro = {Euro} SEK");

            float dollar;
            float euro;

            while(true)
            {
                // Set value to dollar
                Console.WriteLine($"Enter the exchange rate in dollar for 1 SEK: ");
                bool success = float.TryParse(Console.ReadLine(), out dollar);
                if (!success)
                {
                    Console.WriteLine("Enter a number");
                    continue;
                }
                break;
            }
            // Changes the current value to new value
            Dollar = dollar;

            while (true)
            {
                // Set value to euro
                Console.WriteLine($"Enter the exchange in euro for 1 SEK: ");
                bool success = float.TryParse(Console.ReadLine(), out euro);
                if (!success)
                {
                    Console.WriteLine("Enter a number");
                    continue;
                }

                break;
            }
            // Changes the current value to new value
            Euro = euro;

            Console.WriteLine($"The current exchange rate is:\n1 SEK = {Dollar} Dollar\n1 SEK = {Euro} euro");
        }
        
 
    }
}
