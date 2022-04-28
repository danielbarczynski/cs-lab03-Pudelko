using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pudelko
{
    public class Pudelko : IFormattable, IEquatable<Pudelko>
    {
        private readonly double a, b, c;
        private readonly UnitOfMeasure _unit;

        public double A { get => a; }
        public double B { get => c; }
        public double C { get => c; }


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
        // both in milimeters
        public double Objetosc { get => Math.Round((a * 1000) * (b * 1000) * (c * 1000), 9); } // TODO: change to meters to not multiply?
        public double Pole { get => Math.Round(2 * ((a * 1000) * (b * 1000) + (a * 1000) * (c * 1000) + (b * 1000) * (c * 1000)), 6); }// Pc = 2(ab + ac + bc)


        public Pudelko(double _a, double _b, double _c, UnitOfMeasure unit)
        {
            _unit = unit;
            a = ConvertToMeters(_a, unit);
            b = ConvertToMeters(_b, unit);
            c = ConvertToMeters(_c, unit);

            if (A <= 0 || A > 10 || B <= 0 || B > 10 || C <= 0 | C > 10)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        public override string ToString()
        {
            return ToString("m");
        }

        public string ToString(string format)
        {
            return ToString(format, null);
        }

        // round to 3 digits after comma, formating pattern
        // in meters by default
        public string ToString(string format, IFormatProvider formatProvider)
        {
            switch (format)
            {
                case "cm": // round 1 digit after comma
                    return $"{a * 100} cm x {b * 100} cm x {c * 100} cm"; // no rounding
                case "mm":
                    return $"{a * 1000} mm x {b * 1000} mm x {c * 1000} mm";
                case "m": // round 3 digits after comma
                    return $"{a} m x {b} m x {c} m";
                default:
                    throw new FormatException();
            }
        }
        public override bool Equals(object obj)
        {
            if (obj is Pudelko)
            {
                return Equals(obj as Pudelko);
            }
            else
            {
                return Equals(obj);
            }
        }

        public bool Equals(Pudelko other)
        {
            if (Pole == other.Pole && Objetosc == other.Objetosc)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return a.GetHashCode() + b.GetHashCode() + c.GetHashCode();
        }

        public static bool operator ==(Pudelko p1, Pudelko p2) => p1.Equals(p2);
        public static bool operator !=(Pudelko p1, Pudelko p2) => p1.Equals(p2);

        public static explicit operator double[](Pudelko p) => new double[] { p.a, p.b, p.c }; // jawne
        public static implicit operator Pudelko(ValueTuple<int, int, int, UnitOfMeasure> p) => new Pudelko(p.Item1, p.Item2, p.Item3, UnitOfMeasure.milimeter); //niejawne (krotka)

        //algorithms, make the smallest possible parameters ( A x B x C)
        public static Pudelko operator +(Pudelko p1, Pudelko p2)
        {
            //TODO: code here
            Pudelko p3 = p1 + p2;
            return p3;
        }

        public double this[int i]
        {
            get
            {
                switch (i)
                {
                    case 0:
                        return a;
                    case 1:
                        return b;
                    case 2:
                        return c;
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
        }
    }
}
