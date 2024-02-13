using System;

public class Appliance
{
    // Properties for basic appliance information
    public string ItemNumber { get; set; }
    public string Brand { get; set; }
    public int Quantity { get; set; }
    public int Wattage { get; set; }
    public string Color { get; set; }
    public decimal Price { get; set; }
}

public class Dishwasher : Appliance
{
    // Additional properties specific to dishwashers
    private string _feature;
    private string _soundRating;
    private const string SoundRatingModerate = "M";
    private const string SoundRatingQuietest = "Qt";
    private const string SoundRatingQuieter = "Qr";

    // Property for dishwasher feature
    public string Feature
    {
        get { return _feature; }
        set { _feature = value; }
    }

    // Property for dishwasher sound rating with validation
    public string SoundRating
    {
        get { return _soundRating; }
        set
        {
            if (value == SoundRatingModerate || value == SoundRatingQuietest || value == SoundRatingQuieter)
            {
                _soundRating = value;
            }
            else
            {
                throw new Exception("Invalid sound rating. It can be either Qt (Quietest), Qr (Quieter), Qu (Quiet) or M (Moderate).");
            }
        }
    }

    // Property to get descriptive sound rating
    public string SoundRatingDishwasher
    {
        get
        {
            switch (_soundRating)
            {
                case SoundRatingModerate:
                    return "Moderate";
                case SoundRatingQuietest:
                    return "Quietest";
                case SoundRatingQuieter:
                    return "Quieter";
                default:
                    return "Unknown";
            }
        }
    }

    // Method to format dishwasher information for file output
    public string FormatForFile()
    {
        return $"{ItemNumber};{Brand};{Quantity};{Wattage};{Color};{Price};{Feature};{SoundRatingDishwasher}";
    }

    // Override of ToString() method to display dishwasher information
    public override string ToString()
    {
        return $"Item Number: {ItemNumber}, Brand: {Brand}, Quantity: {Quantity}, Wattage: {Wattage}, Color: {Color}, Price: {Price}, Feature: {Feature}, Sound Rating: {SoundRatingDishwasher}";
    }

    // Constructor for Dishwasher class
    public Dishwasher(string itemNumber, string brand, int quantity, int wattage, string color, decimal price, string feature, string soundRating)
    {
        ItemNumber = itemNumber;
        Brand = brand;
        Quantity = quantity;
        Wattage = wattage;
        Color = color;
        Price = price;
        Feature = feature;
        SoundRating = soundRating;
    }
}
