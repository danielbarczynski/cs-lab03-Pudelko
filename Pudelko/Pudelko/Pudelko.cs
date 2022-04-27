using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pudelko
{
    public class Pudelko
    {
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


    }
}
