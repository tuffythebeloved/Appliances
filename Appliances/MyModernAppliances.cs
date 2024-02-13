using Appliances.Appliances;

namespace Appliances
{
    //Thalia
    internal class MyModernAppliances : ModernAppliances
    {
        //checks out appliances
        public override void Checkout()
        {
            Console.WriteLine("Enter the item number of an appliance: ");
            string userNum = Console.ReadLine();

            long itemNumber;

            if (long.TryParse(userNum, out itemNumber))
            {
                Appliance found = FindById(itemNumber);

                if (found == null)
                {
                    Console.WriteLine("No appliances found with that item number.");
                }
                else
                {
                    found.Checkout();
                    Console.WriteLine("Appliance " + '"' + itemNumber + '"' + " has been checked out.");
                }
            }
            else
            {
                Console.WriteLine("Invalid Input: Not a Number");
            }
        }
        //displays Refrigerators based on selections
        public override void DisplayRefrigerators()
        {
            Console.WriteLine("possible Options: ");
            Console.WriteLine("0 - Any");
            Console.WriteLine("2 - Double doors");
            Console.WriteLine("3 - Three doors");
            Console.WriteLine("4 - Four doors");

            Console.WriteLine("Enter number of doors: ");

            int selection;
            Refrigerator refrigerator = null;

            if (int.TryParse(Console.ReadLine(), out selection))
            {
                foreach (Appliance appliance in base.Appliances)
                {
                    if (appliance.Type == "Refrigerator")
                    {
                        refrigerator = (Refrigerator) appliance;
                        switch (selection)
                        {
                            case 0:
                                Console.WriteLine(refrigerator);
                                break;
                            case 2:
                                if(refrigerator.Doors == 2)
                                {
                                    Console.WriteLine(refrigerator);
                                }
                                break;
                            case 3:
                                if (refrigerator.Doors == 3)
                                {
                                    Console.WriteLine(refrigerator);
                                }
                                break;
                            case 4:
                                if (refrigerator.Doors == 4)
                                {
                                    Console.WriteLine(refrigerator);
                                }
                                break;
                            default: 
                                Console.WriteLine("Invalid input: not real selection");
                                break;
                        }
                    }
                }

            }
            else
            {
                Console.WriteLine("Invalid Input: Not a number");
            }
        }
        //displays Vacuums based on selections
        public override void DisplayVacuums()
        {
            Console.WriteLine("possible Options: ");
            Console.WriteLine("0 - Any");
            Console.WriteLine("1 - Residential");
            Console.WriteLine("2 - Commercial");

            Console.WriteLine("Enter Grade: ");

            int selectionVoltage;
            int selectionGrade;
            Vacuum vacuum = null;
            List<Appliance> vacuumList = new List<Appliance> { };

            if (int.TryParse(Console.ReadLine(), out selectionGrade))
            {
                if (selectionGrade != 0 && selectionGrade != 1 && selectionGrade != 2)
                {
                    Console.WriteLine("Invalid Input: not real selection");
                    return;
                }
                Console.WriteLine("possible Options: ");
                Console.WriteLine("0 - Any");
                Console.WriteLine("1 - 18V");
                Console.WriteLine("2 - 24V");

                Console.WriteLine("Enter Grade: ");

                if (int.TryParse(Console.ReadLine(), out selectionVoltage))
                {
                    if (selectionVoltage != 0 && selectionVoltage != 1 && selectionVoltage != 2)
                    {
                        Console.WriteLine("Invalid Input: not real selection");
                        return;
                    }
                    foreach (Appliance appliance in base.Appliances)
                    {
                        if (appliance.Type == "Vacuum")
                        {
                            vacuum = (Vacuum)appliance;
                            switch(selectionGrade)
                            {
                                case 0:
                                    if(selectionVoltage == 0)
                                    {
                                        vacuumList.Add(vacuum);
                                    }
                                    else if(selectionVoltage == 1)
                                    {
                                        if(vacuum.BatteryVoltage == 18)
                                        {
                                            vacuumList.Add(vacuum);
                                        }
                                    }
                                    else if(selectionVoltage == 2)
                                    {
                                        if (vacuum.BatteryVoltage == 24)
                                        {
                                            vacuumList.Add(vacuum);
                                        }
                                    }
                                    break;
                                case 1:
                                    if(vacuum.Grade == "Residential")
                                    {
                                        if (selectionVoltage == 0)
                                        {
                                            vacuumList.Add(vacuum);
                                        }
                                        else if (selectionVoltage == 1)
                                        {
                                            if (vacuum.BatteryVoltage == 18)
                                            {
                                                vacuumList.Add(vacuum);
                                            }
                                        }
                                        else if (selectionVoltage == 2)
                                        {
                                            if (vacuum.BatteryVoltage == 24)
                                            {
                                                vacuumList.Add(vacuum);
                                            }
                                        }
                                    }
                                    break;
                                case 2:
                                    if (vacuum.Grade == "Residential")
                                    {
                                        if (selectionVoltage == 0)
                                        {
                                            vacuumList.Add(vacuum);
                                        }
                                        else if (selectionVoltage == 1)
                                        {
                                            if (vacuum.BatteryVoltage == 18)
                                            {
                                                vacuumList.Add(vacuum);
                                            }
                                        }
                                        else if (selectionVoltage == 2)
                                        {
                                            if (vacuum.BatteryVoltage == 24)
                                            {
                                                vacuumList.Add(vacuum);
                                            }
                                        }
                                    }
                                    break;
                            }
                            
                        }
                    }
                }  
                else
                {
                    Console.WriteLine("Invalid Input: Not a number");
                }
                DisplayAppliancesFromList(vacuumList, 0);
            }
            else
            {
                Console.WriteLine("Invalid Input: Not a number");
            }
        }
        //displays Microwaves based on selections
        public override void DisplayMicrowaves()
        {
            Console.WriteLine("possible Options: ");
            Console.WriteLine("0 - Any");
            Console.WriteLine("1 - Work Site");
            Console.WriteLine("2 - Kitchen");

            Console.WriteLine("Enter room type:");

            int selection;
            Microwave microwave = null;

            if (int.TryParse(Console.ReadLine(), out selection))
            {
                foreach (Appliance appliance in base.Appliances)
                {
                    if (appliance.Type == "Microwave")
                    {
                        microwave = (Microwave)appliance;
                        switch (selection)
                        {
                            case 0:
                                Console.WriteLine(microwave);
                                break;
                            case 1:
                                if (microwave.RoomType == 'W')
                                {
                                    Console.WriteLine(microwave);
                                }
                                break;
                            case 2:
                                if (microwave.RoomType == 'K')
                                {
                                    Console.WriteLine(microwave);
                                }
                                break;
                            default:
                                Console.WriteLine("Invalid input: not real selection");
                                break;
                        }
                    }
                }

            }
            else
            {
                Console.WriteLine("Invalid Input: Not a number");
            }
        }
        //displays Dishwashers based on selections
        public override void DisplayDishwashers()
        {
            Console.WriteLine("possible Options: ");
            Console.WriteLine("0 - Any");
            Console.WriteLine("1 - Quietest");
            Console.WriteLine("2 - Quieter");
            Console.WriteLine("3 - Quiet");
            Console.WriteLine("4 - Moderate");

            Console.WriteLine("Enter sound rating:");

            int selection;
            Dishwasher dishwasher = null;

            if (int.TryParse(Console.ReadLine(), out selection))
            {
                foreach (Appliance appliance in base.Appliances)
                {
                    if (appliance.Type == "Dishwasher")
                    {
                        dishwasher = (Dishwasher)appliance;
                        switch (selection)
                        {
                            case 0:
                                Console.WriteLine(dishwasher);
                                break;
                            case 1:
                                if (dishwasher.SoundRating == "Qt")
                                {
                                    Console.WriteLine(dishwasher);
                                }
                                break;
                            case 2:
                                if (dishwasher.SoundRating == "Qr")
                                {
                                    Console.WriteLine(dishwasher);
                                }
                                break;
                            case 3:
                                if (dishwasher.SoundRating == "Qu")
                                {
                                    Console.WriteLine(dishwasher);
                                }
                                break;
                            case 4:
                                if (dishwasher.SoundRating == "M")
                                {
                                    Console.WriteLine(dishwasher);
                                }
                                break;
                            default:
                                Console.WriteLine("Invalid input: not real selection");
                                break;
                        }
                    }
                }

            }
            else
            {
                Console.WriteLine("Invalid Input: Not a number");
            }
        }

        //finds items based on brand
        public override void Find()
        {
            Console.WriteLine("Enter brand to search for:");
            string brand = Console.ReadLine();

            List<Appliance> appliancesFound = new List<Appliance> { };

            foreach (Appliance appliance in base.Appliances)
            {
                if (appliance.Brand.ToLower() == brand.ToLower())
                {
                    appliancesFound.Add(appliance);
                }
            }

            DisplayAppliancesFromList(appliancesFound, 0);

        }

        //Tool for Checkout(Finds item based on ID number)
        private Appliance FindById(long itemNumber)
        {
            Appliance applianceFound = null;

            foreach (Appliance appliance in base.Appliances)
            {
                if (appliance.ItemNumber == itemNumber)
                {
                    applianceFound = appliance;

                    return applianceFound;
                }
            }
            return applianceFound;
        }

        //Makes a random list of appliances based on user input on type and amount
        public override void RandomList()
        {
            Console.WriteLine("Appliance Types");
            Console.WriteLine("0 - Any");
            Console.WriteLine("1 – Refrigerators");
            Console.WriteLine("2 – Vacuums");
            Console.WriteLine("3 – Microwaves");
            Console.WriteLine("4 – Dishwashers");

            Console.Write("Enter type of appliance:");

            int selection;
            int num;

            List<Appliance> foundAppliances = new List<Appliance> { };

            if (int.TryParse(Console.ReadLine(), out selection))
            {
                Console.WriteLine("Enter number of appliances: ");

                if (int.TryParse(Console.ReadLine(), out num))
                {
                    switch (selection)
                    {
                        case 0:
                            foreach (Appliance appliance in base.Appliances)
                            {
                                foundAppliances.Add(appliance);
                            }
                            break;
                        case 1:
                            foreach (Appliance appliance in base.Appliances)
                            {
                                if (appliance.Type == "Refrigerator")
                                {
                                    foundAppliances.Add(appliance);
                                }
                            }
                            break;
                        case 2:
                            foreach (Appliance appliance in base.Appliances)
                            {
                                if (appliance.Type == "Vacuum")
                                {
                                    foundAppliances.Add(appliance);
                                }
                            }
                            break;
                        case 3:
                            foreach (Appliance appliance in base.Appliances)
                            {
                                if (appliance.Type == "Microwave")
                                {
                                    foundAppliances.Add(appliance);
                                }
                            }
                            break;
                        case 4:
                            foreach (Appliance appliance in base.Appliances)
                            {
                                if (appliance.Type == "Dishwasher")
                                {
                                    foundAppliances.Add(appliance);
                                }
                            }
                            break;
                        default: throw new InvalidOperationException();
                    }

                    if (num <= foundAppliances.Count())
                    {
                        foundAppliances.Sort(new Comparer());

                        base.DisplayAppliancesFromList(foundAppliances, num);
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input: Number cannot be greater than List");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input: not a number");
                }
            }
            else
            {
                Console.WriteLine("Invalid Input: not a number");
            }
        }
    }

    //pretty much copied from A1, looked at it for refrence, but its so small it seemed like the only way to do the comparer
    class Comparer : IComparer<Appliance>
    {
        private readonly Random _random  = new Random();

        public int Compare(Appliance x, Appliance y)
        {
            if (x == y)
            {
                return 0;
            }

            return _random.Next(-1, 1);
        }
    }
}
