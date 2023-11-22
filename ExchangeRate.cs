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
            //print current exchange value
            Console.WriteLine($"Current exchange rate is 1 dollar = {Dollar} SEK");
            Console.WriteLine($"Current exchange rate is 1 Euro = {Euro} SEK");

            float dollar;
            float euro;

            while(true)
            {
                //set value to dollar
                Console.WriteLine($"Type in the exchange rate in SEK for 1 dollar: ");
                bool success = float.TryParse(Console.ReadLine(), out dollar);
                if (!success)
                {
                    Console.WriteLine("Type in a number");
                    continue;
                }
                break;
            }
            //changes the current value to new value
            Dollar = dollar;

            while (true)
            {
                //set value to euro
                Console.WriteLine($"Type in the exchange rate in SEK for 1 euro: ");
                bool success = float.TryParse(Console.ReadLine(), out euro);
                if (!success)
                {
                    Console.WriteLine("Type in a number");
                    continue;
                }

                break;
            }
            //changes the current value to new value
            Euro = euro;

            Console.WriteLine($"The current exchange rate is:\n1 dollar = {Dollar} SEK\n1 Euro = {Euro} SEK");
        }
        
 
    }
}
