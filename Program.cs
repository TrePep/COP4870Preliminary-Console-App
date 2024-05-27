using System.ComponentModel.Design;
using static System.Collections.Specialized.BitVector32;


namespace ConsoleApp5
{
    internal class Program
    {

        static void Main(string[] args)
        {
            menu();
            char userInput;


            userInput = Char.ToUpper(Console.ReadKey(true).KeyChar);
            while (userInput != 'Q')
            {

                Console.WriteLine();
                if (userInput == 'I')
                {
                    char selection;
                    Inventory.inventoryMenu();
                    selection = Char.ToUpper(Console.ReadKey(true).KeyChar);
                    while (selection != 'Q')
                    {
                        if (selection == 'C')
                        {
                            //Add item to inventory.
                            Inventory.addItem();
                        }
                        else if (selection == 'R')
                        {
                            //Find print intem in inventory.
                            Inventory.Read();
                        }
                        else if (selection == 'I')
                        {
                            //Display inventory.
                            Inventory.PrintInventory();
                        }
                        else if (selection == 'U')
                        {
                            //Update inventory item.
                            Inventory.Update();
                        }
                        else if (selection == 'D')
                        {
                            //Delete inventory
                            Inventory.Delete();
                        }
                        else if (selection != 'Q')
                        {
                            Console.WriteLine("Invalid Selection \n");
                            Inventory.inventoryMenu();
                        }
                        selection = Char.ToUpper(Console.ReadKey(true).KeyChar);
                    }
                }
                else if (userInput == 'S')
                {
                    Cart cart = new Cart();
                    Inventory.PrintInventory();
                    Cart.cartMenu();

                    char selection;
                    selection = Char.ToUpper(Console.ReadKey(true).KeyChar);
                    while (selection != 'Q')
                    {
                        if (selection == 'A')
                        {
                            cart.addItem();
                            Cart.cartMenu();
                        }
                        else if (selection == 'R')
                        {
                            cart.removeItem();
                            Cart.cartMenu();
                        }
                        else if (selection == 'I')
                        {
                            Inventory.PrintInventory();
                            Cart.cartMenu();
                        }
                        else if (selection == 'V')
                        {
                            cart.viewCart();
                            Cart.cartMenu();
                        }
                        else if (selection == 'C')
                        {
                            cart.checkOut();
                        }
                        else if (selection != 'Q')
                        {
                            Console.WriteLine("Invalid Selection \n");
                            Cart.cartMenu();
                        }
                        selection = Char.ToUpper(Console.ReadKey(true).KeyChar);
                    }
                }
                menu();
                userInput = Char.ToUpper(Console.ReadKey(true).KeyChar);
            }

        }
        static void menu()
        {
            Console.WriteLine("Welcome\nI - Inventory Management\nS - Shop\nQ - quit\n");
        }






    }
}

