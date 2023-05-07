namespace StockCentral.Domain.Models;

public class Seller
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public ICollection<Order>? SellerOrders { get; set; }

    public Seller(List<Order>? sellerOrders, string name)
    {
        Id = Guid.NewGuid();

        if (name == string.Empty)
            Name = "OWNER";
        else Name = name;

        SellerOrders = sellerOrders;
    }
    public Seller()
    {

    }
}
