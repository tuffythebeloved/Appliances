using System;

namespace Appliances
{
    class Program
    {
        public static void Main(string[] args)
        {
            Refridgerator refridgerator = new Refridgerator(189360200, "Bosch", 174, 60, "black", 2000, 2, 62, 29);
            Console.WriteLine(refridgerator.ToString());
        }
    }
}