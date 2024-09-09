namespace Domain.Entities;

public class Order
{
    public Guid Id { get; set; }
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public string Table { get; set; }


    public Order(string productName, decimal price, string table)
    {
        Id = Guid.NewGuid();
        ProductName = productName;
        Price = price;
        Table = table;
    }
}