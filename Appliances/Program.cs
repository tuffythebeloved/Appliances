using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.IO;
using Appliances.Appliances;

namespace Appliances
{
    class Program
    { 
        public static void Main(string[] args)
        {
            MyModernAppliances modern = new MyModernAppliances();
            while (true)
            {
                modern.DisplayMenu();
                int selection;

                if (!int.TryParse(Console.ReadLine(), out selection))
                {
                    Console.WriteLine("Invalid Input: Not a real number");
                }
                switch (selection)
                {
                case 1:
                    modern.Checkout();
                    break;
                case 2:
                    modern.Find();
                    break;
                case 3:
                    modern.DisplayType();
                    break;
                case 4:
                    modern.RandomList();
                    break;
                case 5:
                    modern.Save();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Error: Invalid selection");
                        break;
                }
            }
        }
    }
}