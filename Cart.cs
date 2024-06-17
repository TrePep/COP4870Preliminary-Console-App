using System;
using System.Runtime.CompilerServices;
/*Testing update commit to GIT 2*/
public class Cart
{

    private List<Item> items = new List<Item>();

    public List<Item> getItems() { return items; }

    public static void cartMenu()
    {
        Console.WriteLine("Welcome to the shop!\nA - Add Item\nR - Remove Item\nI - View Inventory\nV - View Cart\nC - Checkout");
    }

    public void addItem()
    {
        Console.WriteLine("Input the ID of the Item you would like to add to the cart: ");
        int choice = Convert.ToInt32(Console.ReadLine());
        Item itemToAdd = Inventory.FindItemById(choice);
        if (itemToAdd != null)
        {
            Console.WriteLine("Input the quantity: ");
            int quantity = Convert.ToInt32(Console.ReadLine());
            if (quantity <= itemToAdd.GetAmountAvailable())
            {
                itemToAdd.SetQuantity(quantity);
                items.Add(itemToAdd);
                Inventory.SubtractFromInventory(choice, quantity);
                Console.WriteLine("Item added to cart.\n");
            }
            else
            {
                Console.WriteLine("Insufficient quantity available.\n");
            }

        }
        else
        {
            Console.WriteLine("Item not found.\n");
        }
    }

    public void removeItem()
    {
        Console.WriteLine("Input the ID of the Item you would like tor romove from your cart: ");
        int choice = Convert.ToInt32(Console.ReadLine());
        Item itemToRemove = null;
        foreach (var item in items)
        {
            if (item.GetId() == choice)
            {
                itemToRemove = item;
                break;
            }
        }
        if (itemToRemove != null)
        {
            items.Remove(itemToRemove);
            Inventory.AddToInventory(choice, itemToRemove.GetQuantity());
            Console.WriteLine("Item removed form cart.");
        }
        else
        {
            Console.WriteLine("Item not found in cart.");
        }

    }

    public void viewCart()
    {
        Console.WriteLine("Items in cart:");
        foreach (var item in items)
        {
            Console.WriteLine("Name: " + item.GetName());
            Console.WriteLine("Description: " + item.GetDescription());
            Console.WriteLine("Price: " + item.GetPrice().ToString("C"));
            Console.WriteLine("AmountAvailable: " + item.GetAmountAvailable());
            Console.WriteLine("Number of items: " + item.GetQuantity());
            Console.WriteLine("ID: " + item.GetId() + "\n");
        }
    }


    public void checkOut()
    {
        if (items.Count == 0)
        {
            Console.WriteLine("Cart is empty. Nothing to checkout.");
            return;
        }

        using (StreamWriter writer = new StreamWriter("receipt.txt"))
        {
            double subtotal = 0;
            double taxRate = 0.07;


            writer.WriteLine("Receipt");
            writer.WriteLine("-------------------");

            foreach (var item in items)
            {
                double itemTotal = item.GetPrice() * item.GetQuantity();
                subtotal += itemTotal;

                writer.WriteLine("Item: " + item.GetName());
                writer.WriteLine("Description: " + item.GetDescription());
                writer.WriteLine("Price per unit: " + item.GetPrice().ToString("C"));
                writer.WriteLine("Quantity: " + item.GetQuantity());
                writer.WriteLine("Total: " + itemTotal.ToString("C"));
                writer.WriteLine();
            }

            double tax = Math.Round(subtotal * taxRate,2);
            double total = subtotal + tax;

            writer.WriteLine("Subtotal: " + subtotal.ToString("C"));
            writer.WriteLine("Tax (7%): " + tax.ToString("C"));
            writer.WriteLine("Total: " + total.ToString("C"));

            writer.Close();
        }
        Console.WriteLine("You are checked out!");
        items.Clear();
    }

}
