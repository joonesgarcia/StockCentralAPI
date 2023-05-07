using StockCentral.Domain.Enums;

namespace StockCentral.Domain.Models.InputModel;

public record ExcelRowInputModel(
    string sellerName,
    AvailabilityStatus status,
    string name,
    int memory,
    string acessories,
    double costPrice,
    string note,
    string clientName,
    double? soldPrice,
    double? debit
    );
