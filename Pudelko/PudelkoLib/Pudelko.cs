using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PudelkoLib
{
    public sealed class Pudelko : IFormattable, IEquatable<Pudelko>, IEnumerable<double>
    {
        public delegate int Comparison<Pudelko>(Pudelko p1, Pudelko p2);

        private readonly double a, b, c;
        private readonly UnitOfMeasure? _unit;

        public double? A { get => a; }
        public double? B { get => c; }
        public double? C { get => c; }


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
        public double Objetosc { get => Math.Round((a) * (b) * (c ), 9); } // TODO: change to meters to not multiply?
        public double Pole { get => Math.Round(2 * ((a) * (b) + (a) * (c ) + (b ) * (c )), 6); }// Pc = 2(ab + ac + bc)

        //public Pudelko(double _a, double _b, double _c, UnitOfMeasure unit)
        //{
        //    a = ConvertToMeters(_a, unit);
        //    b = ConvertToMeters(_b, unit);
        //    c = ConvertToMeters(_c, unit);
        public Pudelko(double? _a = null, double? _b = null, double? _c = null, UnitOfMeasure? unit = null)
        {
            if (unit == null) // niestety i tak nie bedzie dzialac, bo pola nie sa nullable, zostawiam na wypadek gdybym na cos wpadl
            {
                unit = UnitOfMeasure.meter;
            }
            if (_a == null)
            {
                c = 0.1;
                unit = UnitOfMeasure.meter;
            }
            else if (_b == null)
            {
                b = 0.1;
                unit = UnitOfMeasure.meter;
            }
            else if (_c == null)
            {
                c = 0.1;
                unit = UnitOfMeasure.meter;
            }

            a = ConvertToMeters((double)_a, (UnitOfMeasure)unit);
            b = ConvertToMeters((double)_b, (UnitOfMeasure)unit);
            c = ConvertToMeters((double)_c, (UnitOfMeasure)unit);

            if (a <= 0 || a > 10 || b <= 0 || b > 10 || c <= 0 | c > 10)
            {
                throw new ArgumentOutOfRangeException();
            }

            _unit = unit;

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
            //Pudelko p3 = p1 + p2;
            //return p3;

            // w zasadzie dopasowac i dodac najmniejsze odcinki do siebie czyli dla p1 a = 5 b = 1 p1[0] = b i to samo z p2 (posortowac?)
            // tylko ze niektore warianty moga byc w rzeczywistosci niemozliwe do dopasowania np jak do dlugosci p1 dopasuje szerokosc p2 a do wysokosci p1 dlugosc p2
            // przyjac maksymalna dlugosc szerokosc i wysokosc trzeciego pudelka (?)
            return new Pudelko(
              p1[0] + p2[0],
              p1[1] + p2[1],
              p1[2] + p2[2],
              UnitOfMeasure.meter
          );
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

        // prototype, implementation below doesnt work

        List<double> odcinki = new List<double> { 5.0, 6.0, 7.0 }; // a, b, c (but fields must be static), anyway it doesnt work
        public IEnumerator<double> GetEnumerator()
        {
            foreach (var x in odcinki)
            {
                yield return x;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => odcinki.GetEnumerator();

        //new P(2.5, 9.321, 0.1) == P.Parse("2.500 m × 9.321 m × 0.100 m")
        // max length = 27 a = 0-5 b = 11-15 c = 21-25
        public static Pudelko Parsowanie(string parse)
        {
            UnitOfMeasure unit = UnitOfMeasure.meter;
            string[] parseSplit = parse.Split(' ');
            //var slice = parseSplit[0..5];
            //var slice2 = parseSplit[8..12];
            //var slice3 = parseSplit[16..20];
            double a = double.Parse(parseSplit[0]);
            double b = double.Parse(parseSplit[8]);
            double c = double.Parse(parseSplit[16]);

            if (parse.Contains("mm"))
            {
                unit = UnitOfMeasure.milimeter;
            }
            else if (parse.Contains('m'))
            {
                unit = UnitOfMeasure.meter;
            }
            else if (parse.Contains("cm"))
            {
                unit = UnitOfMeasure.centimeter;
            }

            return new Pudelko(a, b, c, unit);
        }

        public static int Porownaj(Pudelko p1, Pudelko p2) // troche nie rozumiem jak to ma zwracac posortowane pudełka, ale powiedział Pan w nagraniu, że ma zwracać wartość dodatnią ujemną lub zero czyli rozumiem 1, 0, -1
        {
            if (p1.Objetosc == p2.Objetosc || p1.Pole == p2.Pole || p1.a + p1.b + p1.c == p2.a + p2.b + p2.c)
            {
                return 0;
            }
            else if (p1.Objetosc < p2.Objetosc)
            {
                return 1;
            }
            else if (p1.Pole < p2.Pole)
            {
                return 1;
            }
            else if (p1.a + p1.b + p1.c < p2.a + p2.b + p2.c)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
    }
}
