using System;

namespace Appliances.Appliances
{
    //Aayan
    public class Vacuum : Appliance
    {
        // Defining private fields for the Vacuum class
        private int _batteryVoltage;
        private string _grade;

        // Defining properties for the Vacuum class
        public int BatteryVoltage
        {
            get { return _batteryVoltage; }
            set
            {
                // Validating the battery voltage value
                if (value == 18 || value == 24)
                {
                    _batteryVoltage = value;
                }
                else
                {
                    throw new Exception("Invalid battery voltage. It can be either 18 V (Low) or 24 V (High).");
                }
            }
        }

        public string Grade
        {
            get { return _grade; }
            set { _grade = value; }
        }

        // Method to format the object's data for file output
        public string FormatForFile()
        {
            return $"{ItemNumber};{Brand};{Quantity};{Wattage};{Colour};{Price};{Grade};{BatteryVoltage}";
        }

        // Overriding the ToString method to provide a string representation of the object
        public override string ToString()
        {
            string voltage = "unknown";

            if (BatteryVoltage == 18)
            {
                voltage = "Low";
            }
            else if(BatteryVoltage == 24)
            {
                voltage = "High";
            }

            return $"Item Number: {ItemNumber}\n Brand: {Brand}\n Quantity: {Quantity}\n Wattage: {Wattage}\n Color: {Colour}\n Price: {Price}\n Grade: {Grade}\n Battery Voltage: {voltage}";
        }

        // Constructor for the Vacuum class
        public Vacuum(long itemNumber, string brand, int quantity, int wattage, string color, double price, string grade, int batteryVoltage)
            :base(itemNumber, brand, quantity, wattage, color, price)
        {
            Grade = grade;
            BatteryVoltage = batteryVoltage;
        }
    }
}
