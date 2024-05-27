using System;
using System.Runtime.CompilerServices;

public class Item
{
    private string Name;
    private string Description;
    private double Price;
    private int Id;
    private int AmountAvailable; //Inventory count.
    private int quantity;  //cart count.

    public Item(string name, string description, double price, int IdTracker, int amountAvailable)
	{
        Name = name;
        Description = description;
        Price = price;
        Id = IdTracker;
        AmountAvailable = amountAvailable; 
        quantity = 0;   
	}

   	public string GetName()
    {
        return Name;
    }

    public string GetDescription()
    {
        return Description;
    }

    public double GetPrice()
    {
        return Price;
    }

    public int GetId()
    {
        return Id;
    }

    public int GetAmountAvailable()
    {
        return AmountAvailable;
    }

    public int GetQuantity()
    {
        return quantity;
    }

    public void SetName(string name)
    {
        Name = name;
    }

    public void SetDescription(string description)
    {
        Description = description;
    }

    public void SetPrice(double price)
    {
        Price = price;
    }

    public void SetAmountAvailable(int amountAvailable)
    {
        AmountAvailable = amountAvailable;
    }

    public void SetQuantity(int quantity)
    {
        this.quantity = quantity;
    }
}


