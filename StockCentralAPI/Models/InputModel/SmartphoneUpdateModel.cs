namespace StockCentralAPI.Models.InputModel;

public record SmartphoneUpdateModel(
    string name,
    double costPrice,       
    int memory,
    string acessories,
    string note = "",
    double? soldPrice = null
    );
