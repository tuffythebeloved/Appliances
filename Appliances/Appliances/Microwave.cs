using System;

namespace Appliances.Appliances
{
    //Aayan
    public class Microwave : Appliance
    {
        // Defining private fields for the Microwave class
        private double _capacity;
        private char _roomType;

        // Defining constants for the room types
        private const char RoomTypeKitchen = 'K';
        private const char RoomTypeWorksite = 'W';

        // Defining properties for the Microwave class
        public double Capacity
        {
            get { return _capacity; }
            set { _capacity = value; }
        }

        public char RoomType
        {
            get { return _roomType; }
            set
            {
                // Validating the room type value
                if (value == RoomTypeKitchen || value == RoomTypeWorksite)
                {
                    _roomType = value;
                }
                else
                {
                    throw new Exception("Invalid room type. It can be either K (kitchen) or W (work site).");
                }
            }
        }

        // Defining a property to display the room type
        public string RoomTypeDisplay
        {
            get
            {
                return _roomType == RoomTypeKitchen ? "Kitchen" : "Work Site";
            }
        }

        // Method to format the object's data for file output
        public string FormatForFile()
        {
            return $"{ItemNumber};{Brand};{Quantity};{Wattage};{Colour};{Price};{Capacity};{RoomTypeDisplay}";
        }

        // Overriding the ToString method to provide a string representation of the object
        public override string ToString()
        {
            return $"Item Number: {ItemNumber}\n Brand: {Brand}\n Quantity: {Quantity}\n Wattage: {Wattage}\n Color: {Colour}\n Price: {Price}\n Capacity: {Capacity}\n Room Type: {RoomTypeDisplay}";
        }

        // Constructor for the Microwave class
        public Microwave(long itemNumber, string brand, int quantity, int wattage, string color, double price, double capacity, char roomType)
            :base(itemNumber, brand, quantity, wattage, color, price)
        {
            Capacity = capacity;
            RoomType = roomType;
        }
    }
}
