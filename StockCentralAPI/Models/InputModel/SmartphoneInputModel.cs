using StockCentralAPI.Enums;

namespace StockCentralAPI.Models.InputModel;

public record SmartphoneInputModel(
    string name, 
    double costPrice, 
    int memory,
    string acessories
    );
