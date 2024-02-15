using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appliances.Appliances
{

    //Brien

    public class Vacuum : Appliance
    {

        //Vacuum fields
        private string _grade;
        private int _batteryVoltage;

        //Vacuum properties
        public string Grade
        {
            get {  return _grade; }
            set { _grade = value; }
        }

        public int BatteryVoltage
        {
            get { return _batteryVoltage; }
            set
            {
                if (value == 18 || value == 24)
                {
                    _batteryVoltage = value;
                }
                else
                {
                    throw new Exception("Invalid voltage. The voltage can either be 18V for Low or 24V for High.");
                }
            }
        }

        //Vacuum methods
        public override string FormatForFile()
        {
            string format = base.FormatForFile() + ";" + Grade.ToString() + ";" + BatteryVoltage.ToString();
            return format;
        }

        public override string ToString()
        {

            string voltage = "na";

            if (BatteryVoltage == 18)
            {
                voltage = "Low";
            }
            else if (BatteryVoltage == 24)
            {
                voltage = "High";
            }

            string toString = $"Item Number: {ItemNumber}\nBrand: {Brand}\nQuantity: {Quantity}\nWattage: {Wattage}\nColour: {Colour}\nPrice: {Price}\nGrade: {Grade}\nBattery Voltage: {voltage}";
            return toString;
        }

        public Vacuum(long itemNumber, string brand, int quantity, double wattage, string colour, double price, string grade, int batteryVoltage)
            : base(itemNumber, brand, quantity, wattage, colour, price)
        {
            _grade = grade;
            _batteryVoltage = batteryVoltage;
        }

    }
}
