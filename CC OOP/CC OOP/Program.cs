using System;

public interface IBankService
{
    decimal ConvertRate(CurrencyRate currencyRate);
}

public class CurrencyRate
{
    public decimal Price { get; set; }
}

public class IsBankServiceAdapter : IBankService
{
    private IsBankService _isBankService = new IsBankService();

    public decimal ConvertRate(CurrencyRate currencyRate)
    {
        return _isBankService.ConvertRate(currencyRate);
    }
}

public class IsBankService
{
    public decimal ConvertRate(CurrencyRate currencyRate)
    {
        return currencyRate.Price / 30.55M;
    }
}

public interface IProductService
{
    void Sell(Product product, Customer customer);
}

public class ProductManager : IProductService
{
    private IBankService _bankService;

    public ProductManager(IBankService bankService)
    {
        _bankService = bankService;
    }

    public void Sell(Product product, Customer customer)
    {
        // Ürün satışı işlemleri burada gerçekleştirilir
        decimal convertedPrice = _bankService.ConvertRate(new CurrencyRate { Price = product.Price });
        Console.WriteLine($"Product {product.Name} sold to customer {customer.Name} for {convertedPrice} TL");
    }
}

public class Customer
{
    public int Id { get; set; }

    public string Name { get; set; }

    public bool IsStudent { get; set; }
    
    public bool IsOfficer { get; set; }
}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        Customer customer1 = new Customer()
        {
            Id = 1,
            Name = "Engin",
            IsStudent = true,
            IsOfficer = false
        };

        IProductService productService = new ProductManager(new IsBankServiceAdapter());
        productService.Sell(new Product { Id = 1, Name = "Laptop", Price = 1000 }, new Customer { Id = 1, Name = "Engin", IsStudent = true, IsOfficer = false });
    }
}
