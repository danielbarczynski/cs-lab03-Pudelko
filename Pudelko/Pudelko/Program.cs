namespace Pudelko
{
    class Program
    {
        static void Main(string[] args)
        {
            Pudelko pudelko = new Pudelko(5, 10, 4, UnitOfMeasure.milimeter);
            Console.WriteLine(pudelko.A);
            Console.WriteLine(pudelko.ToString("cm"));
        }       
    }  
}

