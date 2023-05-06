using StockCentralAPI.Enums;
using StockCentralAPI.Models.InputModel;

namespace StockCentralAPI.Models;

public class Smartphone : Product
{
    public int Memory { get; set; }
    public string Acessories { get; set; }

    public Smartphone(string name, double costPrice) : base(name, costPrice, Status.STOCK)
    {

    }
    public Smartphone(SmartphoneInputModel model) : base(model.name, model.costPrice, Status.STOCK)
    {
        Memory = model.memory;
        Acessories = model.acessories;
    }

    public Smartphone(ExcelRowInputModel model) : base(model.name, model.costPrice, model.status, model.soldPrice, 1, model.note)
    {
        Memory = model.memory;
        Acessories = model.acessories;
    }

    public void UpdateSmartphone(SmartphoneUpdateModel model)
    {
        Name = model.name;
        CostPrice = model.costPrice;
        SoldPrice = model.soldPrice;
        Memory = model.memory;
        Acessories = model.acessories;
        Note = model.note;

    }

}
