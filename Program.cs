using System;
using System.Linq;
using System.Linq.Expressions;
using ConverterApp.Units;

namespace ConverterApp
{
    public class Program
    {

        public static void Main(string[] args)
        {
            Converter con = new Converter();

            Unit km = new Unit("km", 1000, EUnitType.space);
            Unit m = new Unit("m", 1, EUnitType.space);
            Unit cm = new Unit("cm", 0.01, EUnitType.space);
            Unit mm = new Unit("mm", 0.001, EUnitType.space);

            Unit kg = new Unit("kg", 1000, EUnitType.mass);
            Unit g = new Unit("g", 1, EUnitType.mass);
            Unit mg = new Unit("mg", 0.001, EUnitType.mass);

            Unit k = new Unit("k", 1, EUnitType.temperature);
            Unit f = new Unit("f", 1, EUnitType.temperature);
            Unit c = new Unit("c", 1, EUnitType.temperature);

            Unit[] AllUnits = { km, m, cm, mm, kg, g, mg, k, f, c };



            double UnitValue = 0;
            int UnitType = 0;
            string InputUnit1 = "";
            string InputUnit2 = "";
            bool IsError = true;



            do
            {
                Console.WriteLine("Enter the value you want to convert");
                try
                {
                    UnitValue = double.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Error on value input.");
                    continue;
                }
                break;
            }
            while (IsError);



            do
            {
                Console.WriteLine("Enter what you want to measure");
                Console.WriteLine("1: Space\n2: Mass\n3: Temperature");
                try
                {
                    UnitType = int.Parse(Console.ReadLine());
                    if (!(Array.Exists(AllUnits, n => n.TypeInt == UnitType)))
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Measurement type not recognized.");
                    continue;
                }
                break;
            }
            while (IsError);



            do
            {
                Console.WriteLine("Enter the unit you want to convert from");
                try
                {
                    InputUnit1 = Console.ReadLine();
                    if (!(Array.Exists(AllUnits, unit => unit.Name.Equals(InputUnit1) && unit.TypeInt == UnitType)))
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Measure unit not recognized.");
                    continue;
                }
                break;
            }
            while (IsError);



            do
            {
                Console.WriteLine("Enter the unit you want to convert to");
                try
                {
                    InputUnit2 = Console.ReadLine();
                    if (!Array.Exists(AllUnits, unit => unit.Name.Equals(InputUnit2)))
                    {
                        throw new Exception();
                    }
                    if (!(Array.Exists(AllUnits, unit => unit.Name.Equals(InputUnit2) && unit.TypeInt == UnitType)))
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Measure unit not recognized.");
                    continue;
                }
                break;
            }
            while (IsError);



            Console.WriteLine("Your value is:");
            if ((int)EUnitType.temperature == UnitType)
            {
                Console.WriteLine(con.ConvertTemp(UnitValue, InputUnit1, InputUnit2));
            }
            else
            {
                Console.WriteLine($"{con.DoConvert(con.GetConvertNumber(AllUnits, InputUnit1), con.GetConvertNumber(AllUnits, InputUnit2), UnitValue)}");
            }
        }
    }
    public struct Unit
    {
        public string Name;
        public double Factor;
        public EUnitType Type;
        public int TypeInt;

        public Unit(string name, double factor, EUnitType type)
        {
            Name = name;
            Factor = factor;
            Type = type;
            TypeInt = (int)type;
        }
    }
    public enum EUnitType
    {
        space = 1,
        mass,
        temperature
    }
}