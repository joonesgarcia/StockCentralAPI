using StockCentral.Domain.Models;
using StockCentral.Domain.Enums;
using StockCentral.Domain.Models.InputModel;
using StockCentral.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockCentral.Infrastructure.Util;

namespace StockCentral.Infrastructure.EF.EFCoreRepository
{
    class EFCoreExcelPayloadRepository : IExcelPayloadRepository
    {
        private readonly AppDbContext _context;
        public EFCoreExcelPayloadRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public int Load(List<ExcelRowInputModel> model)
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
                client ??= new Client
                {
                    Id = Guid.NewGuid(),
                    Name = row.clientName.ToUpper().Trim(),
                    ClientOrders = new List<Order>()
                };

                if (row.status.Equals(AvailabilityStatus.Sold))
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
            }
            context.SaveChanges();
            //return context.; // count changes
            return 1;
        }
    }
}
