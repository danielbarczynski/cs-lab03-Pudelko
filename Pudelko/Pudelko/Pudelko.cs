using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pudelko
{
    public class Pudelko : IFormattable
    {

        // in meters by default
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }

        public enum UnitOfMeasure
        {
            milimeter, centimeter, meter
        }

        private UnitOfMeasure _unit;
        public Pudelko(int a, int b, int c, UnitOfMeasure unit)
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
            return $"{A}{format} x {B}{format} x {C}{format}";
        }
    }
}
