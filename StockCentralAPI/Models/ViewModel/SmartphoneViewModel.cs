namespace StockCentralAPI.Models.ViewModel;

public record SmartphoneViewModel(
    string name,
    int memory,
    string acessories,
    string status,
    double costPrice,
    double? soldPrice
    );
