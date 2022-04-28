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
        private UnitOfMeasure _unit;

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

        double Objetosc => Math.Round(A * B * C, 9);
        double Pole => Math.Round(Objetosc * Objetosc, 6); // check


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
                case "cm":
                    return $"{a * 100} cm x {b * 100} cm x {c * 100} cm";
                case "mm":
                    return $"{a * 1000} mm x {b * 1000} mm x {c * 1000} mm";
                case "m":
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
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(Pudelko p1, Pudelko p2) => p1.Equals(p2);
        public static bool operator !=(Pudelko p1, Pudelko p2) => p1.Equals(p2);

        //algorithms, make the smallest possible parameters ( A x B x C)
        public static Pudelko operator +(Pudelko p1, Pudelko p2)
        {
            //todo: code here
            Pudelko p3 = p1 + p2;
            return p3;
        }
    }
}
