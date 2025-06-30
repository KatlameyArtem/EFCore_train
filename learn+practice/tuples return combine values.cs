using System;
public class Practice
{

    //public (string name, int age) GetPerson()
    //{
    //    return ("Alice", 30);
    //}
    //public (string city, int population) GetCity()
    //{
    //    return ("Kiev", 123456);
    //}
    decimal Price;
    decimal Discount;

    public (decimal price,decimal discount) GetPrice(string massagType, int minutes)
    {
        massagType.Trim().ToLower();
        if (massagType == "антицеллюлитный") { Discount = 10; Price = 5 * minutes; }
        else if(massagType =="расслабляющий") { Discount = 15; Price = 4 * minutes; }
        else if (massagType == "лимфодренажный") { Discount = 20; Price = 6 * minutes; }
        else { Discount = 0; Price = 3 * minutes; }

        Price -= (Price/100)*Discount;


        return (Price, Discount);
    }
    public static void Main(string[] args) 
    {
        var p = new Practice(); //or do the method static
        var (totalPrice,appliedDiscount) = p.GetPrice("антицеллюлитный", 50);
        Console.WriteLine($"totalPrice - {totalPrice}\nappliedDiscount - {appliedDiscount}");
        //Deconstruction
        //var (myCity, myPopulation) = p.GetCity();
        //Console.WriteLine($"myCity - {myCity}\nmyPopulation - {myPopulation}");
    }
}