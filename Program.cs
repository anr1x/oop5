using System;
using System.Collections.Generic;
using System.Linq;

// Клас товару
class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    // Додайте інші атрибути товару за потребою
}

// Клас користувача
class User
{
    public string Username { get; set; }
    public string Password { get; set; }
    public List<Product> PurchaseHistory { get; set; }

    public User(string username, string password)
    {
        Username = username;
        Password = password;
        PurchaseHistory = new List<Product>();
    }
}

// Клас замовлення
class Order
{
    public List<Product> Products { get; set; }
    public int Quantity { get; set; }
    public decimal TotalCost => Products.Sum(p => p.Price * Quantity);
    public string Status { get; set; }
    // Додайте інші атрибути замовлення за потребою
}

// Інтерфейс для пошуку товарів
interface ISearchable
{
    List<Product> Search(string criteria);
}

// Клас магазину
class Store : ISearchable
{
    private List<Product> Products { get; set; }
    private List<User> Users { get; set; }
    private List<Order> Orders { get; set; }

    public Store()
    {
        Products = new List<Product>();
        Users = new List<User>();
        Orders = new List<Order>();
    }

    public void AddProduct(Product product)
    {
        Products.Add(product);
    }

    public void AddUser(User user)
    {
        Users.Add(user);
    }

    public void PlaceOrder(Order order)
    {
        Orders.Add(order);
    }

    public List<Product> Search(string criteria)
    {
        // Логіка пошуку товарів за критеріями
        // Повертає список товарів, які відповідають критеріям пошуку
        return Products.Where(p => p.Name.ToLower().Contains(criteria.ToLower())).ToList();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Приклад використання
        Store store = new Store();

        // Додавання товарів
        store.AddProduct(new Product { Name = "Ноутбук", Price = 1000, Description = "...", Category = "Електроніка" });
        store.AddProduct(new Product { Name = "Книга", Price = 20, Description = "...", Category = "Книги" });

        // Додавання користувача
        store.AddUser(new User("user123", "pass123"));

        // Оформлення замовлення
        store.PlaceOrder(new Order { Products = new List<Product> { /* Товари в замовленні */ }, Quantity = 2, Status = "В обробці" });

        // Пошук товарів
        var searchResult = store.Search("Електроніка");
        foreach (var product in searchResult)
        {
            Console.WriteLine($"Знайдено товар: {product.Name}, Ціна: {product.Price}, Опис: {product.Description}, Категорія: {product.Category}");
        }
    }
}
