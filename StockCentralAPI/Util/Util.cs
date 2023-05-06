namespace StockCentralAPI.Util
{
    public static class SimpleCalculator
    {
        public static double GetComission(double paidPrice, double? soldPrice)
        {
            if (soldPrice == null || (double)(soldPrice - paidPrice * 0.2) < 0)
                return 0;

            else
                return (double)((soldPrice - paidPrice) * 0.2 );
        }
    }
}
