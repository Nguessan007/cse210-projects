using System;
using System.Collections.Generic;

// Address class
class Address
{
    private string street;
    private string city;
    private string stateOrProvince;
    private string country;

    public Address(string street, string city, string stateOrProvince, string country)
    {
        this.street = street;
        this.city = city;
        this.stateOrProvince = stateOrProvince;
        this.country = country;
    }

    // Check if in USA
    public bool IsInUSA()
    {
        return country.Trim().ToUpper() == "USA";
    }

    // Return full address as string
    public string GetFullAddress()
    {
        return $"{street}\n{city}, {stateOrProvince}\n{country}";
    }
}

// Customer class
class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public string Name => name;
    public Address Address => address;

    public bool LivesInUSA()
    {
        return address.IsInUSA();
    }
}

// Product class
class Product
{
    private string name;
    private string productId;
    private double price;
    private int quantity;

    public Product(string name, string productId, double price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    public string Name => name;
    public string ProductId => productId;
    public double Price => price;
    public int Quantity => quantity;

    // Total cost = price * quantity
    public double GetTotalCost()
    {
        return price * quantity;
    }
}

// Order class
class Order
{
    private List<Product> products = new List<Product>();
    private Customer customer;

    public Order(Customer customer)
    {
        this.customer = customer;
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    // Calculate total cost (products + shipping)
    public double GetTotalCost()
    {
        double total = 0;
        foreach (var product in products)
        {
            total += product.GetTotalCost();
        }

        // Shipping cost
        total += customer.LivesInUSA() ? 5 : 35;
        return total;
    }

    // Packing label: list product name and ID
    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (var product in products)
        {
            label += $"{product.Name} (ID: {product.ProductId})\n";
        }
        return label;
    }

    // Shipping label: customer name + address
    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{customer.Name}\n{customer.Address.GetFullAddress()}";
    }
}

// Program entry point
class Program
{
    static void Main(string[] args)
    {
        // Create addresses
        Address addr1 = new Address("123 Maple St", "New York", "NY", "USA");
        Address addr2 = new Address("456 Elm St", "Toronto", "ON", "Canada");

        // Create customers
        Customer customer1 = new Customer("Alice Johnson", addr1);
        Customer customer2 = new Customer("Bob Smith", addr2);

        // Create products
        Product prod1 = new Product("Laptop", "LAP123", 999.99, 1);
        Product prod2 = new Product("Mouse", "MOU456", 25.50, 2);
        Product prod3 = new Product("Keyboard", "KEY789", 49.99, 1);
        Product prod4 = new Product("Monitor", "MON321", 199.99, 1);
        Product prod5 = new Product("USB Cable", "USB654", 9.99, 3);

        // Create first order
        Order order1 = new Order(customer1);
        order1.AddProduct(prod1);
        order1.AddProduct(prod2);
        order1.AddProduct(prod3);

        // Create second order
        Order order2 = new Order(customer2);
        order2.AddProduct(prod4);
        order2.AddProduct(prod5);

        // Display order 1 details
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalCost():0.00}\n");
        Console.WriteLine(new string('-', 50));

        // Display order 2 details
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalCost():0.00}\n");
        Console.WriteLine(new string('-', 50));
    }
}
