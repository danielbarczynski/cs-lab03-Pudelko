namespace Pudelko
{
    class Program
    {
        static void Main(string[] args)
        {
            Pudelko pudelko = new Pudelko(5, 10, 4, UnitOfMeasure.meter);
            pudelko.ToString("cm");
        }       
    }  
}

