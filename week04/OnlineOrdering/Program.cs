using System;
using System.Collections.Generic;

class Product
{
    public string Name { get; set; }
    public float Price { get; set; }
    public int Quantity { get; set; }

    public float GetPrice()
    {
        return Price * Quantity;
    }
}

class Address
{
    public string Street { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }

    public void DisplayAddress()
    {
        Console.WriteLine($"{Street}, {City}, {PostalCode}");
    }
}

class Order
{
    public int OrderId { get; set; }
    public string CustomerName { get; set; }
    public List<Product> Products { get; set; } = new List<Product>();
    public Address ShippingAddress { get; set; }

    public float CalculateTotal()
    {
        float total = 0;
        foreach (var product in Products)
        {
            total += product.GetPrice();
        }
        return total;
    }

    public void DisplayOrder()
    {
        Console.WriteLine($"Order ID: {OrderId}, Customer: {CustomerName}");
        Console.WriteLine("Products:");
        foreach (var product in Products)
        {
            Console.WriteLine($"{product.Name} x {product.Quantity} = ${product.GetPrice()}");
        }
        Console.WriteLine($"Total: ${CalculateTotal()}");
        Console.WriteLine("Shipping Address:");
        ShippingAddress.DisplayAddress();
    }
}

class Program2
{
    static void Main()
    {
        Order order = new Order { OrderId = 101, CustomerName = "Jane Smith" };

        order.Products.Add(new Product { Name = "Laptop", Price = 999.99f, Quantity = 1 });
        order.Products.Add(new Product { Name = "Mouse", Price = 25.50f, Quantity = 2 });

        order.ShippingAddress = new Address
        {
            Street = "123 Main St",
            City = "New York",
            PostalCode = "10001"
        };

        order.DisplayOrder();
    }
}
