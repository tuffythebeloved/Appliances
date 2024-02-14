using System;

namespace Appliances.Appliances
{
    public class Dishwasher : Appliance
    {
        // Additional properties specific to dishwashers
        private string _feature;
        private string _soundRating;
        private const string SoundRatingModerate = "M";
        private const string SoundRatingQuietest = "Qt";
        private const string SoundRatingQuieter = "Qr";
        private const string SoundRatingQuiet = "Qu";

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
                if (value == SoundRatingModerate || value == SoundRatingQuietest || value == SoundRatingQuieter || value == SoundRatingQuiet)
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
                    case SoundRatingQuiet:
                        return "Quiet";
                    default:
                        return "Unknown";
                }
            }
        }

        // Method to format dishwasher information for file output
        public string FormatForFile()
        {
            return $"{ItemNumber};{Brand};{Quantity};{Wattage};{Colour};{Price};{Feature};{SoundRatingDishwasher}";
        }

        // Override of ToString() method to display dishwasher information
        public override string ToString()
        {
            return $"Item Number: {ItemNumber}\n Brand: {Brand}\n Quantity: {Quantity}\n Wattage: {Wattage}\n Color: {Colour}\n Price: {Price}\n Feature: {Feature}\n Sound Rating: {SoundRatingDishwasher}";
        }

        // Constructor for Dishwasher class
        public Dishwasher(long itemNumber, string brand, int quantity, int wattage, string color, double price, string feature, string soundRating)
            :base(itemNumber, brand, quantity, wattage, color, price)
        {
            Feature = feature;
            SoundRating = soundRating;
        }
    }
}
