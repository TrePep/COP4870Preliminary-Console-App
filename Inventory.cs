using System;
using System.Runtime.CompilerServices;

public static class Inventory
{
    private static List<Item> inventory = new List<Item>();
    static int IdTracker = 0;  //Uniqe inventory ID.


    public static bool addItem()
    {
        string Name;
        string Description;
        double Price;
        int amountAvailable;

        Console.WriteLine("Input the name: ");
        Name = Console.ReadLine();
        Console.WriteLine("Input the description: ");
        Description = Console.ReadLine();
        Console.WriteLine("Input the price: ");
        Price = Math.Round(Convert.ToDouble(Console.ReadLine()),2);
        Console.WriteLine("Input the amount available: ");
        amountAvailable = Convert.ToInt32(Console.ReadLine());


        Item inventoryManagement = new Item(Name, Description, Price, IdTracker, amountAvailable);

        Console.WriteLine("You inputed the following information:\nName: " + inventoryManagement.GetName());
        Console.WriteLine("Description: " + inventoryManagement.GetDescription());
        Console.WriteLine("Price: " + inventoryManagement.GetPrice().ToString("C"));
        Console.WriteLine("AmountAvailable: " + inventoryManagement.GetAmountAvailable());
        Console.WriteLine("ID: " + inventoryManagement.GetId());
        Console.WriteLine("Is this correct? Y - Yes     N - No");
        char selection = 'X';
        while (selection != 'Y' && selection != 'N')
        {
            selection = Char.ToUpper(Console.ReadKey(true).KeyChar);
        }
        if (selection == 'N')
        {
            Console.WriteLine("***   Creation terminated   ***");
            return false;
        }

        
        inventory.Add(inventoryManagement);
        Console.WriteLine("***   Item Added to Inventory   ***");
        IdTracker++;
        return true;
    }
    public static void inventoryMenu()
    {
        Console.WriteLine("Welcome to Inventory Management\nC - Create\nR - Read\nI - List Inventory\nU - Update\nD - Delete\nQ - Quit");
    }

    public static void PrintInventory()
    {
        Console.WriteLine("Here are the itmes in the inventory:\n");
        foreach (var item in inventory)
        {
            Console.WriteLine("Name: " + item.GetName());
            Console.WriteLine("Description: " + item.GetDescription());
            Console.WriteLine("Price: " + item.GetPrice().ToString("C"));
            Console.WriteLine("AmountAvailable: " + item.GetAmountAvailable());
            Console.WriteLine("ID: " + item.GetId() + "\n");
        }
    }

    public static bool Read()
    {
        Console.WriteLine("Input the ID of the item you would like to Read(Display): ");
        int choice = Convert.ToInt32(Console.ReadLine());
        bool found = false;
        foreach (var item in inventory)
        {
            if (item.GetId() == choice)
            {
                found = true;
                Console.WriteLine("Name: " + item.GetName());
                Console.WriteLine("Description: " + item.GetDescription());
                Console.WriteLine("Price: " + item.GetPrice().ToString("C"));
                Console.WriteLine("AmountAvailable: " + item.GetAmountAvailable());
                Console.WriteLine("ID: " + item.GetId() + "\n");
            }
        }
        if (!found)
        {
            Console.WriteLine("Item with ID " + choice + " not found.");
        }
        return found;
    }

    public static bool Update()
    {
        Console.WriteLine("Input the ID of the item you would like to Update: ");
        int choice = Convert.ToInt32(Console.ReadLine());
        bool found = false;
        foreach (var item in inventory)
        {
            if (item.GetId() == choice)
            {
                found = true;
                Console.WriteLine("What would you like to update?\nN - Name\nD - Description\nP - Price\nA - Amount Available\nE - Everything");
                char selection = 'X';
                while (selection != 'N' && selection != 'D' && selection != 'P' && selection != 'A' && selection != 'E')
                {
                    selection = Char.ToUpper(Console.ReadKey(true).KeyChar);
                }
                if (selection == 'N')
                {
                    Console.WriteLine("Enter new name: ");
                    item.SetName(Console.ReadLine());
                }
                else if (selection == 'D')
                {
                    Console.WriteLine("Enter new description: ");
                    item.SetDescription(Console.ReadLine());
                }
                else if (selection == 'P')
                {
                    Console.WriteLine("Enter new price: ");
                    item.SetPrice(Math.Round(Convert.ToDouble(Console.ReadLine()),2));
                }
                else if (selection == 'A')
                {
                    Console.WriteLine("Enter new amount available: ");
                    item.SetAmountAvailable(Convert.ToInt32(Console.ReadLine()));
                }
                else if (selection == 'E')
                {
                    Console.WriteLine("Enter new name: ");
                    item.SetName(Console.ReadLine());
                    Console.WriteLine("Enter new description: ");
                    item.SetDescription(Console.ReadLine());
                    Console.WriteLine("Enter new price: ");
                    item.SetPrice(Math.Round(Convert.ToDouble(Console.ReadLine()),2));
                    Console.WriteLine("Enter new amount available: ");
                    item.SetAmountAvailable(Convert.ToInt32(Console.ReadLine()));
                }
            }
        }
        if (!found)
        {
            Console.WriteLine("Item with ID " + choice + " not found.\n");
        }
        return found;
    }

    public static bool Delete()
    {
        Console.WriteLine("Input the ID of the item you would like to Delete: ");
        int choice = Convert.ToInt32(Console.ReadLine());
        bool found = false;
        foreach (var item in inventory)
        {
            if (item.GetId() == choice)
            {
                found = true;
                Console.WriteLine("Name: " + item.GetName());
                Console.WriteLine("Description: " + item.GetDescription());
                Console.WriteLine("Price: " + item.GetPrice().ToString("C"));
                Console.WriteLine("AmountAvailable: " + item.GetAmountAvailable());
                Console.WriteLine("ID: " + item.GetId() + "\n");
                Console.WriteLine("Are you sure you want to delete this item? Y - Yes N - No?");
                char selection = 'X';
                while (selection != 'Y' && selection != 'N')
                {
                    selection = Char.ToUpper(Console.ReadKey(true).KeyChar);
                }
                if (selection == 'N')
                {
                    Console.WriteLine("Removal terminated");
                }
                inventory.Remove(item);
                Console.WriteLine("Item with ID " + choice + " has been removed.\n");
                return found;
            }
        }
        if (!found)
        {
            Console.WriteLine("Item with ID " + choice + " not found.");
        }
        return found;
    }
    public static Item FindItemById(int id)
    {
        foreach (var item in inventory)
        {
            if (item.GetId() == id)
            {
                return item;
            }
        }
        return null;
    }

    public static void SubtractFromInventory(int id, int quantity)
    {
        foreach (var item in inventory)
        {
            if (item.GetId() == id)
            {
                item.SetAmountAvailable(item.GetAmountAvailable() - quantity);
                return;
            }
        }
    }

    public static void AddToInventory(int id, int quantity)
    {
        foreach (var item in inventory)
        {
            if (item.GetId() == id)
            {
                item.SetAmountAvailable(item.GetAmountAvailable() + quantity);
                return;
            }
        }
    }


}