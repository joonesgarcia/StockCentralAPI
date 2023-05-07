namespace StockCentral.Domain.Models;

public class Order
{
    public Guid Id { get; set; }
    public Client Client { get; set; }
    public Seller Seller { get; set; }

    public ICollection<Product> SoldProducts { get; set; }
    public Comission Comission { get; set; }
}
