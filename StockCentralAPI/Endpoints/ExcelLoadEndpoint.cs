using StockCentralAPI.Enums;
using StockCentralAPI.Models;
using StockCentralAPI.Models.InputModel;
using StockCentralAPI.Util;

namespace StockCentralAPI.Endpoints
{
    public static class ExcelLoadEndpoint
    {
        public static void MapRows(this WebApplication app)
        {
            app.MapPost("/Add/ExcelPayload", (AppDbContext context, List<ExcelRowInputModel> model) =>
            {
                foreach (ExcelRowInputModel row in model)
                {
                    Smartphone sm = new(row);

                    Seller? seller = context.Sellers.FirstOrDefault(s =>
                        s.Name.ToUpper().Trim() ==
                            (
                            row.sellerName.ToUpper().Trim() != "" ?
                            row.sellerName.ToUpper().Trim() :
                            "OWNER"
                            )
                    );
                    Client? client = context.Clients.FirstOrDefault(c => 
                        c.Name.ToUpper().Trim() == row.clientName.ToUpper().Trim()
                    );

                    seller ??= new Seller(
                        new List<Order>(), 
                        row.sellerName.ToUpper().Trim()
                    );
                    client ??= new Client { 
                        Id = Guid.NewGuid(), 
                        Name = row.clientName.ToUpper().Trim(), 
                        ClientOrders = new List<Order>() 
                    };

                    if (row.status.Equals(Status.SOLD))
                    {
                        var order = new Order
                        {
                            Id = Guid.NewGuid(),
                            Client = client,
                            Seller = seller,
                            SoldProducts = new List<Product> { sm },
                            Comission = new Comission
                            {
                                Id = Guid.NewGuid(),
                                IsPaid = true
                            }
                        };

                        order.Comission.OrderId = order.Id;
                        order.Comission.Value = SimpleCalculator.GetComission(sm.CostPrice, sm.SoldPrice);

                        seller.SellerOrders.Add(order);
                        client.ClientOrders.Add(order);

                        context.Orders.Add(order);
                    }
                    context.Stock.Add(sm);
                    context.SaveChanges();
                }
                return Results.NoContent();
            });
        }
    }
}
