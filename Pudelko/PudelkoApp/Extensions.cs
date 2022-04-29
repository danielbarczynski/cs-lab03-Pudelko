using PudelkoLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PudelkoLib
{
    public static class Extensions
    {
        public static Pudelko Kompresuj(this Pudelko p)
        {
            double bok = Math.Cbrt(p.Objetosc);
            return new Pudelko(bok, bok, bok, UnitOfMeasure.meter);
        }
    }
}
