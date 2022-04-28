namespace Pudelko
{
    class Program
    {
        static void Main(string[] args)
        {
            Pudelko pudelko = new Pudelko(5, 10, 4, UnitOfMeasure.centimeter);
            Pudelko pudelko2 = new Pudelko(10, 5, 4, UnitOfMeasure.centimeter);
            Console.WriteLine(pudelko.A);
            Console.WriteLine(pudelko.ToString("cm"));
            Console.WriteLine(pudelko.A);
            Console.WriteLine(pudelko.GetHashCode());
            Console.WriteLine(pudelko.Equals(pudelko2));
            Console.WriteLine(pudelko[2]); 
           
        }       
    }  
}

