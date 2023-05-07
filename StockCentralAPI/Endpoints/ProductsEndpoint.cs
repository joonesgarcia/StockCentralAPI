using StockCentral.Domain.Models;
using StockCentral.Domain.Models.InputModel;
using System.Net;

namespace StockCentralAPI.Endpoints
{
    public static class ProductsEndpoint
    {
        public static void MapStock(this WebApplication app)
        {
            app.MapGet("/Products", () =>
            {
                return context.Stock;
            });
            app.MapGet("/Products/Smartphones/GetAll", () =>
            {
            });
            app.MapGet("/Product/Smartphones/GetById", () =>
            {

                if (smartphone == null)
                    return HttpStatusCode.NotFound;
            });
            app.MapPost("/Products/Smartphones/Add", (SmartphoneInputModel model) =>
            {

            });
            app.MapPut("/Products/Smartphones/Update", (SmartphoneUpdateModel model) =>
            {


            });
            app.MapDelete("/Products/Smartphones/Delete", (Guid id) =>
            {

            });


        }
    }
}
