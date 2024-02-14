using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appliances.Appliances
{
    //Thalia
    public class Appliance
    {
        //fields
        private string? _brand;
        private string? _colour;
        private long _itemNumber;
        private double _price;
        private int _quantity;
        private double _wattage;

        //properties
        public string? Brand
        {
            get { return _brand; }
            set { _brand = value; }
        }
        public string? Colour
        {
            get { return _colour; }
            set { _colour = value; }
        }
        public long ItemNumber
        {
            get { return _itemNumber; }
            set { _itemNumber = value; }
        }
        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }
        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
        public double Wattage
        {
            get { return _wattage; }
            set { _wattage = value; }
        }
        public string? Type { get; set; }

        //constructor(for info on how to use, view refridgerator)
        protected Appliance(long itemNumber, string brand, int quantity, double wattage, string colour, double price)
        {
            _itemNumber = itemNumber;
            _brand = brand;
            _quantity = quantity;
            _wattage = wattage;
            _colour = colour;
            _price = price;

            DetermineApplianceType();
        }

        //removes ones from quantity
        public void Checkout()
        {
            if (Quantity > 0)
            {
                Quantity = Quantity - 1;
            }
            else
            {
                Console.WriteLine("The appliance is not available to be checked out.");
            }
        }

        //assigns type based on ID
        public void DetermineApplianceType()
        {
            char type = ItemNumber.ToString().First();
            switch (type)
            {
                case '1':
                    Type = "Refrigerator";
                    break;
                case '2':
                    Type = "Vacuum";
                    break;
                case '3':
                    Type = "Microwave";
                    break;
                case '4':
                    Type = "Dishwasher";
                    break;
                case '5':
                    Type = "Dishwasher";
                    break;
                default:
                    Type = "Unknown";
                    break;
            }
        }

        //formats properties to be added to file
        public virtual string FormatForFile()
        {
            string format = ItemNumber.ToString() + ";" + Brand + ";" + Quantity.ToString() + ";" + Wattage.ToString() + ";" + Colour + ";" + Price.ToString();
            return format;
        }
    }
}
