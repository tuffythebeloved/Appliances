using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Appliances
{
    internal class Refridgerator : Appliance
    {
        //fields
        private int _doors;
        private double _height;
        private double _width;

        //properties
        public int Doors
        {
            get { return _doors; }
            set { _doors = value; }
        }
        public double Height
        {
            get { return _height; }
            set { _height = value; }
        }
        public double Width
        {
            get { return _width; }
            set { _width = value; }
        }

        //constructor
        public Refridgerator(long itemNumber, string brand, int quantity, double wattage, string colour, double price, int doors, double height, double width)
            : base(itemNumber, brand, quantity, wattage, colour, price)
        {
            _doors = doors;
            _height = height;
            _width = width;
        }

        //formats properties to be added to file
        override public string FormatForFile()
        {
            string format = base.FormatForFile() + ";" + Doors.ToString() + ";" + Height.ToString() + ";" + Width.ToString();
            return format;
        }

        //Formats properties for readability to user
        public override string ToString()
        {
            string itemNum = "Item Number: " + ItemNumber.ToString();
            string brand = "Brand: " + Brand;
            string quantity = "Quantity: " + Quantity.ToString();
            string wattage = "Wattage: " + Wattage.ToString();
            string colour = "Colour: " + Colour;
            string price = "Price: " + Price.ToString();
            string doors = "Doors: " + Doors.ToString();
            string height = "Height: " + Height.ToString();
            string width = "Width: " + Width.ToString();

            string format = itemNum + "\n" + brand + "\n" + quantity + "\n" + wattage + "\n" + colour + "\n" + price + "\n" + doors + "\n" + height + "\n" + width;
            return format;
        }
    }
}
