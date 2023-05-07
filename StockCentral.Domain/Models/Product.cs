using StockCentral.Domain.Enums;

namespace StockCentral.Domain.Models;

public abstract class Product
{
    protected Product(string name, double costPrice, AvailabilityStatus status, double? soldPrice = null, int quantity = 1, string note = "")
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
    public AvailabilityStatus Status { get; set; }
    public double? SoldPrice { get; set; }
    public int Quantity { get; set; }
    public string Note { get; set; }
}
