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
    public virtual int Cost
    {
        get;
        set;
    }

    public void PrintPrice()
    {
        Console.WriteLine("Цена: {0}", Cost);
    }
}

public class Costing : Price
{
    public int cost;
    public override int Cost 
    { 
        get => base.Cost; set => base.Cost = value; 
        }

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
    public Price price; //Композиция с Price
    private double weight;

    //Композиция с Price, Конструктор
    public Order()
    {
        price = new Price();            
    }

    

    //Конструктор
    public Order(int N, string D, double w) 
    {
        Number = N;
        Description = D;
        Weight = w; 
    }    
            
    public double Weight
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
