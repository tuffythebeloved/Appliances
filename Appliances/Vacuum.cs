using System;

public class Appliance
{
    // Defining properties for the Appliance class
    public string ItemNumber { get; set; }
    public string Brand { get; set; }
    public int Quantity { get; set; }
    public int Wattage { get; set; }
    public string Color { get; set; }
    public decimal Price { get; set; }
}

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
        return $"{ItemNumber};{Brand};{Quantity};{Wattage};{Color};{Price};{Grade};{BatteryVoltage}";
    }

    // Overriding the ToString method to provide a string representation of the object
    public override string ToString()
    {
        return $"Item Number: {ItemNumber}, Brand: {Brand}, Quantity: {Quantity}, Wattage: {Wattage}, Color: {Color}, Price: {Price}, Grade: {Grade}, Battery Voltage: {BatteryVoltage}";
    }

    // Constructor for the Vacuum class
    public Vacuum(string itemNumber, string brand, int quantity, int wattage, string color, decimal price, string grade, int batteryVoltage)
    {
        ItemNumber = itemNumber;
        Brand = brand;
        Quantity = quantity;
        Wattage = wattage;
        Color = color;
        Price = price;
        Grade = grade;
        BatteryVoltage = batteryVoltage;
    }
}
