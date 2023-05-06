using StockCentralAPI.Enums;

namespace StockCentralAPI.Models
{
    public class Perfume : Product
    {
        public Perfume(string volumeInML, string name, double costPrice, Status status, double? soldPrice = null, int quantity = 1, string note = "") : base(name, costPrice, status, soldPrice, quantity, note)
        {
            VolumeInML = volumeInML;
        }

        public string VolumeInML { get; set; }

    }
}
