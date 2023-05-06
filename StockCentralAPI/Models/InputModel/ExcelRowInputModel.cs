using StockCentralAPI.Enums;

namespace StockCentralAPI.Models.InputModel;

public record ExcelRowInputModel(
    string sellerName,
    Status status,
    string name,
    int memory,
    string acessories,
    double costPrice,
    string note,
    string clientName,
    double? soldPrice,
    double? debit
    );
