using StockCentral.Domain.Models.InputModel;

namespace StockCentralAPI.Endpoints.Load
{
    public static class ExcelLoadEndpoint
    {
        public static void MapRows(this WebApplication app)
        {
            app.MapPost("/ExcelPayload/Load", (List<ExcelRowInputModel> model) =>
            {
                
            });
        }
    }
}
