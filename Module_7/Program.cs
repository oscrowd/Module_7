using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

abstract class Delivery //абстрактный класс
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
    public static int minValue = 0; //Статическая переменная
    public override int Cost    //Переопределение
    {
        get //Использование get set
        {
            return cost;
        }
        set
        {
            if (value < minValue)
            {
                Console.WriteLine("Цена не может быть меньше 0");
            }
            else
            {
                cost = value;
            }
        }
    }

}

public class PaymentMethods //Способы оплаты заказа
{
    protected string pymentmethod;  //использование protected
    private Cash cash;
    private CreditCard creditCard;
    //Агрегация
    public PaymentMethods(string pymentmethod, Cash cash)
    {
        this.pymentmethod = pymentmethod;
        this.cash = cash;
    }
    public PaymentMethods(string pymentmethod, CreditCard creditCard)
    {
        this.pymentmethod = pymentmethod;
        this.creditCard = creditCard;
    }
}

public class Cash
{
    public string currency;
}

public static class CashExtensions  //расширение
{
    public static string CheckCurrency(this string currency)
    {
        if (currency == "рубль")
        {
            return currency;
        }
        else if (currency == "юань")
        {
            return currency;
        }
        else
        {
            return "Рубль";
        }
    }
}

public class CreditCard
{
    public string Name;
    public string Number;
}

public class CreditCardCollection
{
    private CreditCard[] collection;
    public CreditCardCollection(CreditCard[] collection)
    { 
        this.collection = collection;
    }
    public CreditCard this[int index]
    {
        get
        {
            if (index >= 0 && index < collection.Length)
            {
                return collection[index];
            }
            else 
            { 
            return null;
            }
        }
        private set
        {
            // Проверяем, чтобы индекс был в диапазоне для массива
            if (index >= 0 && index < collection.Length)
            {
                collection[index] = value;
            }
        }

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

    //Конструктор и перегрузка
    public Order(int N, string D, double w) 
    {
        Number = N;
        Description = D;
        Weight = w; 
    }
    public Order(int N, string D)
    {
        Number = N;
        Description = D;
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
