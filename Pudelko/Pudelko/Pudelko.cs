using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pudelko
{
    public class Pudelko : IFormattable, IEquatable<Pudelko>
    {
        // in meters by default
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }

        public enum UnitOfMeasure
        {
            milimeter, centimeter, meter
        }

        private UnitOfMeasure _unit;

        private double ConvertToMeters(double number, UnitOfMeasure unit)
        {
            if (unit == UnitOfMeasure.milimeter)
            {
                return number / 1000;
            }
            else if (unit == UnitOfMeasure.centimeter)
            {
                return number / 100;
            }
            else
            {
                return number;
            }
        }

        double Objetosc => Math.Round(A * B * C, 9);
        double Pole => Math.Round(Objetosc * Objetosc, 6); // sprawdzic


        public Pudelko(double a, double b, double c, UnitOfMeasure unit)
        {
            _unit = unit;
            A = ConvertToMeters(a, unit);
            B = ConvertToMeters(b, unit);
            C = ConvertToMeters(c, unit);

            if (A <= 0 || A > 10 || B <= 0 || B > 10 || C <= 0 | C > 10)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
       
        // round to 3 digits after comma, formating pattern
        // in meters by default
        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            switch (format)
            {
                case "cm":
                    _unit = UnitOfMeasure.centimeter;
                    break;
                case "mm":
                    _unit = UnitOfMeasure.milimeter;
                    break;
                default: // meter
                    _unit = UnitOfMeasure.meter;
                    break;
            }
            return $"{A}{_unit} x {B}{_unit} x {C}{_unit}";
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as Pudelko);
        }

        public bool Equals(Pudelko? other)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            return 5;
        }

        public static bool operator ==(Pudelko p1, Pudelko p2) => p1.Equals(p2);
        public static bool operator !=(Pudelko p1, Pudelko p2) => p1.Equals(p2);

        //algorytmy, jak najmniejsze mozliwe rozmiary
        public static Pudelko operator +(Pudelko p1, Pudelko p2)
        {
            Pudelko p3 = p1 + p2;
            return p3;
        }
    }
}
