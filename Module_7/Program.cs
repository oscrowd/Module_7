using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

abstract class Delivery
{
    public string Address;
}

class HomeDelivery : Delivery
{
    /* ... */
}

class PickPointDelivery : Delivery
{
    /* ... */
}

class ShopDelivery : Delivery
{
    /* ... */
}

public class Price
{ 

}

public class ProductProperties
{ 
}


class Order<TDelivery,
TStruct> where TDelivery : Delivery
{
    public TDelivery Delivery;

    public int Number;

    public string Description;

    public Price price;

    //Композиция с Price
    public Order()
    {
        price = new Price();            
    }


    private string weight;

    public string Weight
    {
        get
        {
            return weight;
        }
        set 
        { 
            weight = value;
        }
    }



    public void DisplayAddress()
    {
        Console.WriteLine(Delivery.Address);
    }

    // ... Другие поля
}

namespace Module_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
