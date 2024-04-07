using System;

// Address class to store address details
class Address
{
    private string street;
    private string city;
    private string state;
    private string country;

    public Address(string street, string city, string state, string country)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    public bool IsInUSA()
    {
        return country.Equals("USA", StringComparison.OrdinalIgnoreCase);
    }

    public override string ToString()
    {
        return $"{street}\n{city}, {state}\n{country}";
    }
}

// Customer class to store customer details
class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public bool IsInUSA()
    {
        return address.IsInUSA();
    }

    public override string ToString()
    {
        return $"{name}\n{address}";
    }
}

// Product class to store product details
class Product
{
    private string name;
    private int productId;
    private double price;
    private int quantity;

    public Product(string name, int productId, double price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    public double GetTotalCost()
    {
        return price * quantity;
    }

    public override string ToString()
    {
        return $"{name} (ID: {productId})";
    }
}

// Order class to store order details
class Order
{
    private List<Product> products;
    private Customer customer;

    public Order(Customer customer)
    {
        this.customer = customer;
        products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public double CalculateTotalCost()
    {
        double totalCost = 0;
        foreach (var product in products)
        {
            totalCost += product.GetTotalCost();
        }
        // Add shipping cost based on customer's location
        totalCost += customer.IsInUSA() ? 5 : 35;
        return totalCost;
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (var product in products)
        {
            label += $"{product}\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{customer}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create addresses
        Address address1 = new Address("123 Main St", "Anytown", "CA", "USA");
        Address address2 = new Address("456 Elm St", "Sometown", "NY", "Canada");

        // Create customers
        Customer customer1 = new Customer("John Smith", address1);
        Customer customer2 = new Customer("Alice Johnson", address2);

        // Create products
        Product product1 = new Product("Laptop", 1001, 999.99, 1);
        Product product2 = new Product("Smartphone", 2002, 599.99, 2);
        Product product3 = new Product("Tablet", 3003, 299.99, 3);

        // Create orders
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Order order2 = new Order(customer2);
        order2.AddProduct(product2);
        order2.AddProduct(product3);

        // Display order details
        Console.WriteLine("Order 1:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.CalculateTotalCost():F2}\n");

        Console.WriteLine("Order 2:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.CalculateTotalCost():F2}");
    }
}
