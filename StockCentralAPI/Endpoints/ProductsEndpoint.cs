using StockCentralAPI.Models.InputModel;
using StockCentralAPI.Models.ViewModel;
using StockCentralAPI.Models;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace StockCentralAPI.Endpoints
{
    public static class ProductsEndpoint
    {
        public static void MapStock(this WebApplication app)
        {
            app.MapGet("/Products", (AppDbContext context) =>
            {
                return context.Stock;
            });
            app.MapGet("/Products/Smartphones", (AppDbContext context) =>
            {
                return context.Smartphones.Select(s => new SmartphoneViewModel(s.Name, s.Memory, s.Acessories, s.Status.ToString(), s.CostPrice, s.SoldPrice)).ToList();
            });
            app.MapPost("/Products/Add/Smartphone", (AppDbContext context, SmartphoneInputModel model) =>
            {
                context.Stock.Add(new Smartphone(model));
                context.SaveChanges();
                return HttpStatusCode.Created;
            });
            app.MapPut("/Products/Update/Smartphone", (AppDbContext context, Guid id, SmartphoneUpdateModel model) =>
            {
                var smartphone = context.Smartphones.SingleOrDefault(s => s.Id == id);

                if (smartphone == null)
                    return HttpStatusCode.NotFound;
                else
                    smartphone.UpdateSmartphone(model);

                context.SaveChanges();
                return HttpStatusCode.NoContent;

            });
            app.MapDelete("/Products/Delete/Smartphone", (AppDbContext context, Guid id, [FromBody] SmartphoneUpdateModel model) =>
            {
                var smartphone = context.Smartphones.SingleOrDefault(s => s.Id == id);
                if (smartphone == null)
                    return HttpStatusCode.NotFound;
                else
                    context.Smartphones.Remove(smartphone);
                context.SaveChanges();
                return HttpStatusCode.OK;
            });
        }
}}
