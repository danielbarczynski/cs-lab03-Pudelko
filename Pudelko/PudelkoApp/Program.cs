using PudelkoLib;

namespace PudelkoApp
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Pudelko pudelko = new(5, 10, 4, UnitOfMeasure.centimeter);
            Pudelko pudelko2 = new(10, 5, 4, UnitOfMeasure.centimeter);
            Console.WriteLine(pudelko.A);
            Console.WriteLine(pudelko.Objetosc);
            Console.WriteLine(pudelko.Pole);
            Console.WriteLine(pudelko.ToString("cm"));
            Console.WriteLine(pudelko.A);
            Console.WriteLine(pudelko.GetHashCode());
            Console.WriteLine(pudelko.Equals(pudelko2));
            Console.WriteLine(pudelko[2]);
            Console.WriteLine(pudelko.GetEnumerator());
            //Console.WriteLine(pudelko.Kompresuj()); 


            List<Pudelko> list = new List<Pudelko>
            {
                new Pudelko(10, 10, 10, UnitOfMeasure.centimeter),
                new Pudelko(2333, 1765.4, 995.75, UnitOfMeasure.milimeter),
                new Pudelko(2, 7.5, 0.34, UnitOfMeasure.meter),
            };
            //foreach (var item in list)
            //    Console.WriteLine(item);

            //list.OrderBy(n => n.Objetosc).ThenBy(n => n.Pole).ThenBy(n => n.A + n.B + n.C).ToList();

            //Comparison<Pudelko> comparison = new(Pudelko.Porownaj);
        }
    }
}

