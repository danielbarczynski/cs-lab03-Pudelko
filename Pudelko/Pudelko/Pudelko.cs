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
        public Pudelko(double a, double b, double c, UnitOfMeasure unit)
        {
            A = a;
            B = b;
            C = c;
            _unit = unit;
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
        double Objetosc => Math.Round(A * B * C, 9);

        public bool Equals(Pudelko? other)
        {
            throw new NotImplementedException();
        }

    }
}
