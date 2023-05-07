namespace StockCentral.Domain.Models.InputModel;

public record SmartphoneInputModel(
    string name,
    double costPrice,
    int memory,
    string acessories
    );
