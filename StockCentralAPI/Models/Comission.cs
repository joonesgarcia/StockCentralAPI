namespace StockCentralAPI.Models;

public class Comission
{
    public Guid Id { get; set; }
    public bool IsPaid { get; set; }
    public double Value { get; set; }
    public Guid OrderId { get; set; }

}
