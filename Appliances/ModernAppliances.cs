using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Appliances;

namespace ModernAppliances
{
    public class ModernAppliances
    {
        // Fields
        private List<Appliance> appliances;
        private string APPLIANCES_TEXT_FILE = "appliances.txt";

        // Properties
        public List<Appliance> Appliances
        {
            get { return appliances; }
            set { appliances = value; }
        }

        public ModernAppliances()
        {
            // Initialize the list in the constructor
            appliances = new List<Appliance>();
        }

        // Nested Types
        public abstract class Appliance
        {
            // Common fields and properties for all appliances
            public string ItemNumber { get; set; }
            public string Brand { get; set; }
            public int Quantity { get; set; }
            public int Wattage { get; set; }
            public string Color { get; set; }
            public decimal Price { get; set; }
            public string Type { get; set; }

            // Constructor
            protected Appliance(string itemNumber, string brand, int quantity, int wattage, string color, decimal price)
            {
                ItemNumber = itemNumber;
                Brand = brand;
                Quantity = quantity;
                Wattage = wattage;
                Color = color;
                Price = price;
                DetermineApplianceType();
            }

            // Removes one from quantity
            public void Checkout()
            {
                if (Quantity > 0)
                {
                    Quantity--;
                }
                else
                {
                    Console.WriteLine("The appliance is not available to be checked out.");
                }
            }

            // Assigns type based on ID
            private void DetermineApplianceType()
            {
                char type = ItemNumber[0];
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
                    default:
                        Type = "Unknown";
                        break;
                }
            }

            // Formats for file
            public virtual string FormatForFile()
            {
                return $"{ItemNumber};{Brand};{Quantity};{Wattage};{Color};{Price}";
            }
        }

        public class Microwave : Appliance
        {
            private double _capacity;
            private string _roomType;
            private string roomType;

            public Microwave(string itemNumber, string brand, int quantity, int wattage, string color, decimal price, double capacity, string roomType) : base(itemNumber, brand, quantity, wattage, color, price)
            {
                Capacity = capacity;
                this.roomType = roomType;
            }

            public double Capacity
            {
                get { return _capacity; }
                set { _capacity = value; }
            }

            public IEnumerable<Appliance> Appliances { get; private set; }

            // Methods

            public void CreateAppliance(string type, params object[] parameters)
            {
                switch (type)
                {
                    case "Microwave":
                        CreateMicrowave(parameters);
                        break;
                    case "Refrigerator":
                        CreateRefrigerator(parameters);
                        break;
                    case "Vacuum":
                        CreateVacuum(parameters);
                        break;
                    case "Dishwasher":
                        CreateDishwasher(parameters);
                        break;
                    default:
                        throw new ArgumentException("Invalid appliance type");
                }
            }

            public void CreateMicrowave(params object[] parameters)
            {
                string itemNumber = (string)parameters[0];
                string brand = (string)parameters[1];
                int quantity = (int)parameters[2];
                int wattage = (int)parameters[3];
                string color = (string)parameters[4];
                decimal price = (decimal)parameters[5];
                double capacity = (double)parameters[6];
                string roomType = (string)parameters[7];

                Microwave microwave = new(itemNumber, brand, quantity, wattage, color, price, capacity, roomType);
                Appliances.Add(microwave);
            }

            public void CreateRefrigerator(params object[] parameters)
            {
                string itemNumber = (string)parameters[0];
                string brand = (string)parameters[1];
                int quantity = (int)parameters[2];
                int wattage = (int)parameters[3];
                string color = (string)parameters[4];
                decimal price = (decimal)parameters[5];
                int doors = (int)parameters[6];
                double height = (double)parameters[7];
                double width = (double)parameters[8];
                Refrigerator refrigerator = new Refrigerator(itemNumber, brand, quantity, wattage, color, price, doors, height, width);
                Appliances.Add(refrigerator);
            }

            public void CreateVacuum(params object[] parameters)
            {
                string itemNumber = (string)parameters[0];
                string brand = (string)parameters[1];
                int quantity = (int)parameters[2];
                int wattage = (int)parameters[3];
                string color = (string)parameters[4];
                decimal price = (decimal)parameters[5];
                string grade = (string)parameters[6];
                int batteryVoltage = (int)parameters[7];

                Vacuum vacuum = new Vacuum(itemNumber, brand, quantity, wattage, color, price, grade, batteryVoltage);
                Appliances.Add(vacuum);
            }

            public void CreateDishwasher(params object[] parameters)
            {
                string itemNumber = (string)parameters[0];
                string brand = (string)parameters[1];
                int quantity = (int)parameters[2];
                int wattage = (int)parameters[3];
                string color = (string)parameters[4];
                decimal price = (decimal)parameters[5];
                string feature = (string)parameters[6];
                string soundRating = (string)parameters[7];

                Dishwasher dishwasher = new Dishwasher(itemNumber, brand, quantity, wattage, color, price, feature, soundRating);
                Appliances.Add(dishwasher);
            }

            public void DisplayAppliance(string itemNumber)
            {
                Appliance appliance = Appliances.FirstOrDefault(a => a.ItemNumber == itemNumber);
                if (appliance != null)
                {
                    Console.WriteLine(appliance.ToString());
                }
                else
                {
                    Console.WriteLine("No appliance found with that item number.");
                }
            }

            public void DisplayDishwashers()
            {
                var dishwashers = Appliances.Where(a => a.Type == "Dishwasher");
                foreach (var dishwasher in dishwashers)
                {
                    Console.WriteLine(dishwasher.ToString());
                }
            }

            public List<Appliance> Find(string brand)
            {
                return Appliances.Where(a => a.Brand == brand).ToList();
            }

            public List<Appliance> RandomList(int count)
            {
                return Appliances.OrderBy(a => Guid.NewGuid()).Take(count).ToList();
            }

            public List<Appliance> ReadAppliances(string fileName)
            {
                List<Appliance> result = new List<Appliance>();

                using (StreamReader reader = new StreamReader(fileName))
                {
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(';');

                        string itemNumber = parts[0];
                        string brand = parts[1];
                        int quantity = int.Parse(parts[2]);
                        int wattage = int.Parse(parts[3]);
                        string color = parts[4];
                        decimal price = decimal.Parse(parts[5]);

                        // Determine the type of appliance based on the item number prefix
                        switch (itemNumber[0])
                        {
                            case '1': // Refrigerator
                                int doors = int.Parse(parts[6]);
                                double height = double.Parse(parts[7]);
                                double width = double.Parse(parts[8]);
                                result.Add(new Refrigerator(itemNumber, brand, quantity, wattage, color, price, doors, height, width));
                                break;
                            case '2': // Vacuum
                                string grade = parts[6];
                                int batteryVoltage = int.Parse(parts[7]);
                                result.Add(new Vacuum(itemNumber, brand, quantity, wattage, color, price, grade, batteryVoltage));
                                break;
                            case '3': // Microwave
                                double capacity = double.Parse(parts[6]);
                                string roomType = parts[7];
                                result.Add(new Microwave(itemNumber, brand, quantity, wattage, color, price, capacity, roomType));
                                break;
                            case '4': // Dishwasher
                                string feature = parts[6];
                                string soundRating = parts[7];
                                result.Add(new Dishwasher(itemNumber, brand, quantity, wattage, color, price, feature, soundRating));
                                break;
                            default:
                                Console.WriteLine($"Invalid item number prefix: {itemNumber[0]}");
                                break;
                        }
                    }
                }

                return result;
            }
        }

        private void Save()
        {
            using (StreamWriter writer = new StreamWriter(APPLIANCES_TEXT_FILE))
            {
                foreach (var appliance in Appliances)
                {
                    writer.WriteLine(appliance.FormatForFile());
                }
            }
        }
    }
}
