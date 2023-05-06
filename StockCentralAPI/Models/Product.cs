using StockCentralAPI.Enums;
namespace StockCentralAPI.Models;

public abstract class Product
{
    protected Product(string name, double costPrice, Status status, double? soldPrice = null, int quantity = 1, string note = "")
    {
        Id = Guid.NewGuid();
        Name = name;
        CostPrice = costPrice;
        Status = status;
        SoldPrice = soldPrice;
        Quantity = quantity;
        Note = note;
    }
    public Guid Id { get; set; }
    public string Name { get; set; }
    public double CostPrice { get; set; }
    public Status Status { get; set; }
    public double? SoldPrice { get; set; }
    public int Quantity { get; set; }
    public string Note { get; set; }
}
