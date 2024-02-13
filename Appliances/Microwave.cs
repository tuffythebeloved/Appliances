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

public class Microwave : Appliance
{
    // Defining private fields for the Microwave class
    private double _capacity;
    private string _roomType;

    // Defining constants for the room types
    private const string RoomTypeKitchen = "K";
    private const string RoomTypeWorksite = "W";

    // Defining properties for the Microwave class
    public double Capacity
    {
        get { return _capacity; }
        set { _capacity = value; }
    }

    public string RoomType
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
        return $"{ItemNumber};{Brand};{Quantity};{Wattage};{Color};{Price};{Capacity};{RoomTypeDisplay}";
    }

    // Overriding the ToString method to provide a string representation of the object
    public override string ToString()
    {
        return $"Item Number: {ItemNumber}, Brand: {Brand}, Quantity: {Quantity}, Wattage: {Wattage}, Color: {Color}, Price: {Price}, Capacity: {Capacity}, Room Type: {RoomTypeDisplay}";
    }

    // Constructor for the Microwave class
    public Microwave(string itemNumber, string brand, int quantity, int wattage, string color, decimal price, double capacity, string roomType)
    {
        ItemNumber = itemNumber;
        Brand = brand;
        Quantity = quantity;
        Wattage = wattage;
        Color = color;
        Price = price;
        Capacity = capacity;
        RoomType = roomType;
    }
}
