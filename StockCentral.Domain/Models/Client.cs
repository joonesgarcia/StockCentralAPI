namespace StockCentral.Domain.Models;

public class Client : IUser
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; } = string.Empty;
    public ICollection<Order>? ClientOrders { get; set; }

}
