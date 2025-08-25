using System;

namespace ConverterApp.Units
{
    public class Converter
    {
        public double DoConvert(double fromUnit, double toUnit, double value)
        {
            double BaseUnitValue = value * fromUnit;

            return BaseUnitValue / toUnit;
        }

        public double GetConvertNumber(Unit[] allUnits, string unitName)
        {
            var query = allUnits.Where(unit => unit.Name.Equals(unitName));
            try
            {
                foreach (var unit in query)
                {
                    return unit.Factor;
                }
            }
            catch (Exception)
            {
                return 1;
            }
            return 1;
        }

        public double GetFFromC(double celsius)
        {
            return (celsius * 9/5) + 32;
        }
        public double GetCFromF(double fahrenheit)
        {
            return (fahrenheit - 32) * 5 / 9;
        }
        public double GetKFromC(double celsius)
        {
            return (celsius + 273.15);
        }
        public double GetCFromK(double kelvin)
        {
            return (kelvin - 273.15);
        }

        public double ConvertTemp(double unitValue, string fromUnit, string toUnit)
        {
            double unitConverted = unitValue;

            switch (fromUnit)
            {
                case "f":
                    unitConverted = GetCFromF(unitConverted);
                    break;
                case "k":
                    unitConverted = GetCFromK(unitConverted);
                    break;
                case "c":
                    break;
            }

            switch (toUnit)
            {
                case "f":
                    unitConverted = GetFFromC(unitConverted);
                    break;
                case "k":
                    unitConverted = GetKFromC(unitConverted);
                    break;
                case "c":
                    break;
            }

            return unitConverted;
        }
    }
}