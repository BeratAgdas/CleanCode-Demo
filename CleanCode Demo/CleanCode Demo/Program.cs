// See https://aka.ms/new-console-template for more information
using System;
using System.Reflection.Emit;
Customer customer1 = new Customer()
{
    Id = 1,
    Name = "Engin",
    IsStudent = true,
    IsOfficer = false
};

IProductService productService = new ProductManager(new IsBankServiceAdapter());
productService.Sell(new Product { Id = 1, Name = "Laptop", Price = 1000 }, new Customer { Id = 1, Name = "Engin", IsStudent = true, IsOfficer = false });

public class FakeBankService : IBankService
{
    public decimal ConvertRate(CurrencyRate currencyRate)
    {
        return currencyRate.Price / 30.60M;
    }
}

//Merkez bankasının kodu gibi düşünmeliyiz
class CentralBankService
{
    public decimal ConvertRate(CurrencyRate currencyRate)
    {
        return currencyRate.Price / 30.58M;
    }
}

//İş bankasının kodu gibi düşünmeliyiz
class IsBankService
{
    public decimal ConvertRate(CurrencyRate currencyRate)
    {
        return currencyRate.Price / 30.55M;
    }


}

class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Name { get; set; }    



}
