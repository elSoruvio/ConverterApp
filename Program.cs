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

            Unit KM = new Unit("km", 1000, EUnitType.space);
            Unit HM = new Unit("hm", 100, EUnitType.space);
            Unit DaM = new Unit("dam", 10, EUnitType.space);
            Unit M = new Unit("m", 1, EUnitType.space);
            Unit DM = new Unit("dm", 0.1, EUnitType.space);
            Unit CM = new Unit("cm", 0.01, EUnitType.space);
            Unit MM = new Unit("mm", 0.001, EUnitType.space);
            Unit Mi = new Unit("mi", 1609.34, EUnitType.space);
            Unit Y = new Unit("y", 0.9144, EUnitType.space);
            Unit Ft = new Unit("ft", 0.3048, EUnitType.space);
            Unit In = new Unit("in", 0.0254, EUnitType.space);

            Unit KG = new Unit("kg", 1000, EUnitType.mass);
            Unit HG = new Unit("hg", 100, EUnitType.mass);
            Unit DaG = new Unit("dag", 10, EUnitType.mass);
            Unit G = new Unit("g", 1, EUnitType.mass);
            Unit DG = new Unit("dg", 0.1, EUnitType.mass);
            Unit CG = new Unit("cg", 0.01, EUnitType.mass);
            Unit MG = new Unit("mg", 0.001, EUnitType.mass);
            Unit St = new Unit("st", 6350.29, EUnitType.mass);
            Unit Lb = new Unit("lb", 453.592, EUnitType.mass);
            Unit Oz = new Unit("oz", 28.3495, EUnitType.mass);

            Unit K = new Unit("k", 1, EUnitType.temperature);
            Unit F = new Unit("f", 1, EUnitType.temperature);
            Unit C = new Unit("c", 1, EUnitType.temperature);

            Unit[] AllUnits = {
                KM,
                M,
                CM,
                MM,
                Mi,
                Y,
                Ft,
                In,
                KG,
                G,
                MG,
                St,
                Lb,
                Oz,
                K,
                F,
                C
            };



            double UnitValue = 0;
            int UnitType = 0;
            string InputUnit1 = "";
            string InputUnit2 = "";



            do
            {

                Console.WriteLine("Enter the value you want to convert");
                try
                {

                    UnitValue = double.Parse(Console.ReadLine());

                }
                catch (Exception)
                {

                    Console.WriteLine("Input error. Try again.");
                    continue;

                }

                break;

            }
            while (true);



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

            } while (true);



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

            } while (true);



            do
            {
                Console.WriteLine("Enter the unit you want to convert to");

                try
                {

                    InputUnit2 = Console.ReadLine();

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

            } while (true);



            Console.WriteLine("Your value is:");
            if ((int)EUnitType.temperature == UnitType)
            {

                Console.WriteLine(con.ConvertTemp(UnitValue, InputUnit1, InputUnit2));

            }
            else
            {

                Console.WriteLine(con.DoConvert(con.GetConvertNumber(AllUnits, InputUnit1), con.GetConvertNumber(AllUnits, InputUnit2), UnitValue));

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
