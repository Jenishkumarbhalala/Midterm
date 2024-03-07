using System;
public class InventoryItem
{
    // Properties
    public string ItemName { get; set; }
    public int ItemId { get; set; }
    public double Price { get; set; }
    public int QuantityInStock { get; set; }

    // Constructor
    public InventoryItem(string itemName, int itemId, double price, int quantityInStock)
    {
        ItemName = itemName;
        ItemId = itemId;
        Price = price;
        QuantityInStock = quantityInStock;
    }

    // Methods

    // Update the price of the item
    public void UpdatePrice(double newPrice)
    {
        Price = newPrice;
    }

    // Restock the item
    public void RestockItem(int additionalQuantity)
    {
        QuantityInStock += additionalQuantity;
    }

    // Sell an item
    public bool SellItem(int quantitySold)
    {
        if (QuantityInStock >= quantitySold)
        {
            QuantityInStock -= quantitySold;
            return true; // Indicating the item has been successfully sold
        }
        else
        {
            Console.WriteLine("Error: Items are not enough in stock.");
            return false; // Indicating the sale was unsuccessful due to insufficient stock
        }
    }

    // Check if an item is in stock
    public bool IsInStock()
    {
        return QuantityInStock > 0;
    }

    // Print item details
    public void PrintDetails()
    {
        Console.WriteLine($"Item Name: {ItemName} \nItem ID: {ItemId} \nPrice: ${Price} \nQuantity in Stock: {QuantityInStock}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter item name:");
        string itemName = Console.ReadLine();

        Console.WriteLine("\nEnter item ID:");
        int itemId = int.Parse(Console.ReadLine());

        Console.WriteLine("\nEnter price:");
        double price = double.Parse(Console.ReadLine());

        Console.WriteLine("\nEnter quantity in stock:");
        int quantityInStock = int.Parse(Console.ReadLine());

        InventoryItem item = new InventoryItem(itemName, itemId, price, quantityInStock);

        bool running = true;
        while (running)
        {
            Console.WriteLine("\nChoose an action:");
            Console.WriteLine("1. Print item details");
            Console.WriteLine("2. Sell item");
            Console.WriteLine("3. Restock item");
            Console.WriteLine("4. Check if item is in stock");
            Console.WriteLine("5. Update price");
            Console.WriteLine("6. Exit\n");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Printing item details...");
                    item.PrintDetails();
                    break;
                case "2":
                    Console.WriteLine("Enter quantity to sell:");
                    int quantitySold = int.Parse(Console.ReadLine());
                    bool success = item.SellItem(quantitySold);
                    if (success)
                    {
                        Console.WriteLine($"Successfully sold {quantitySold} unit(s). Remaining stock: {item.QuantityInStock}.");
                    }
                    break;
                case "3":
                    Console.WriteLine("Enter additional quantity to restock:");
                    int additionalQuantity = int.Parse(Console.ReadLine());
                    item.RestockItem(additionalQuantity);
                    Console.WriteLine($"Item restocked. New stock quantity: {item.QuantityInStock}.");
                    break;
                case "4":
                    Console.WriteLine($"{item.ItemName} is {(item.IsInStock() ? "in stock. Quantity in Stock: " + item.QuantityInStock : "not in stock.")}");
                    break;
                case "5":
                    Console.WriteLine("Enter new price:");
                    double newPrice = double.Parse(Console.ReadLine());
                    item.UpdatePrice(newPrice);
                    Console.WriteLine($"Price updated. New price: ${item.Price}");
                    break;
                case "6":
                    Console.WriteLine("Exiting the program. Thank you!");
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }
    }
}
