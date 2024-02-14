using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ExceptionServices;
using Appliances.Appliances;

namespace Appliances
{
    //Aayan
    public abstract class ModernAppliances
    {
        // Fields
        private List<Appliance> appliances;
        private string APPLIANCES_TEXT_FILE = "../../../Resources/appliances.txt";

        // Properties
        public List<Appliance> Appliances
        {
            get { return appliances; }
            set { appliances = value; }
        }

        public ModernAppliances()
        {
            // Initialize the list in the constructor
            appliances = ReadAppliances(APPLIANCES_TEXT_FILE);
        }

        // Methods
        public void DisplayMenu()
        {
            Console.WriteLine("Welcome to Modern Appliances!");
            Console.WriteLine("How May We Assist You ?");
            Console.WriteLine("1 – Check out appliance");
            Console.WriteLine("2 – Find appliances by brand");
            Console.WriteLine("3 – Display appliances by type");
            Console.WriteLine("4 – Produce random appliance list");
            Console.WriteLine("5 – Save & exit");
        }
        public Appliance CreateApplianceFromParts(string[] parameters)
        {

            switch (parameters[0].First())
            {
                case '1':
                    return CreateRefrigerator(parameters);
                case '2':
                    return CreateVacuum(parameters);
                case '3':
                    return CreateMicrowave(parameters);
                case '4':
                    return CreateDishwasher(parameters);
                case '5':
                    return CreateDishwasher(parameters);
                default:
                    throw new ArgumentException("Invalid appliance type");
            }
        }

        public Microwave CreateMicrowave(string[] parameters)
        {
            long itemNumber = long.Parse(parameters[0]);
            string brand = parameters[1];
            int quantity = int.Parse(parameters[2]);
            int wattage = int.Parse(parameters[3]);
            string color = parameters[4];
            double price = double.Parse(parameters[5]);
            double capacity = double.Parse(parameters[6]);
            char roomType = char.Parse(parameters[7]);

            Microwave microwave = new(itemNumber, brand, quantity, wattage, color, price, capacity, roomType);

            return microwave;
        }

        public Refrigerator CreateRefrigerator(string[] parameters)
        {
            long itemNumber = long.Parse(parameters[0]);
            string brand = parameters[1];
            int quantity = int.Parse(parameters[2]);
            int wattage = int.Parse(parameters[3]);
            string color = parameters[4];
            double price = double.Parse(parameters[5]);
            int doors = int.Parse(parameters[6]);
            double height = double.Parse(parameters[7]);
            double width = double.Parse(parameters[8]);
            Refrigerator refrigerator = new Refrigerator(itemNumber, brand, quantity, wattage, color, price, doors, height, width);

            return refrigerator;
        }

        public Vacuum CreateVacuum(string[] parameters)
        {
            long itemNumber = long.Parse(parameters[0]);
            string brand = parameters[1];
            int quantity = int.Parse(parameters[2]);
            int wattage = int.Parse(parameters[3]);
            string color = parameters[4];
            double price = double.Parse(parameters[5]);
            string grade = parameters[6];
            int batteryVoltage = int.Parse(parameters[7]);

            Vacuum vacuum = new Vacuum(itemNumber, brand, quantity, wattage, color, price, grade, batteryVoltage);

            return vacuum;
        }

        public Dishwasher CreateDishwasher(string[] parameters)
        {
            long itemNumber = long.Parse(parameters[0]);
            string brand = parameters[1];
            int quantity = int.Parse(parameters[2]);
            int wattage = int.Parse(parameters[3]);
            string color = parameters[4];
            double price = double.Parse(parameters[5]);
            string feature = parameters[6];
            string soundRating = parameters[7];

            Dishwasher dishwasher = new Dishwasher(itemNumber, brand, quantity, wattage, color, price, feature, soundRating);

            return dishwasher;
        }

        public void DisplayAppliancesFromList(List<Appliance> list, int max)
        {
            if(max == 0)
            {
                max = list.Count;
            }

            if (list.Count > 0)
            {
                for (int i = 0; i < max; i++)
                {
                    Console.WriteLine(list[i].ToString());
                }
            }
            else
            {
                Console.WriteLine("No appliances found");
            }
        }
        public void DisplayType()
        {
            Console.WriteLine("Appliance Types");
            Console.WriteLine("1 – Refrigerators");
            Console.WriteLine("2 – Vacuums");
            Console.WriteLine("3 – Microwaves");
            Console.WriteLine("4 – Dishwashers");

            Console.Write("Enter type of appliance:");

            int selection;

            if (int.TryParse(Console.ReadLine(), out selection))
            { 
                switch (selection)
                {
                    case 1:
                        DisplayRefrigerators();
                        break;
                    case 2:
                        DisplayVacuums();
                        break;
                    case 3:
                        DisplayMicrowaves();
                        break;
                    case 4:
                        DisplayDishwashers();
                        break;
                    default:
                        Console.WriteLine("Invalid appliance type entered.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Error: Not a number");
            }
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

                    // Determine the type of appliance based on the item number prefix
                    result.Add(CreateApplianceFromParts(parts));
                }
            }

            return result;
        }
        public void Save()
        {
            using (StreamWriter writer = new StreamWriter(APPLIANCES_TEXT_FILE))
            {
                foreach (var appliance in Appliances)
                {
                    writer.WriteLine(appliance.FormatForFile());
                }
            }
        }

        //abstract methods
        public abstract void DisplayRefrigerators();
        public abstract void DisplayVacuums();
        public abstract void DisplayDishwashers();
        public abstract void DisplayMicrowaves();
        public abstract void Find();
        public abstract void RandomList();
        public abstract void Checkout();
    }
}
