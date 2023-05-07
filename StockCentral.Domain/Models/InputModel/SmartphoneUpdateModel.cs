namespace StockCentral.Domain.Models.InputModel;

public record SmartphoneUpdateModel(
    Guid id,
    string name,
    double costPrice,
    int memory,
    string acessories,
    string note = "",
    double? soldPrice = null
    );
