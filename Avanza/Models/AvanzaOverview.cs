namespace Avanza
{
    public class AvanzaOverview
    {
        public Account[] accounts { get; set; }
        public int numberOfOrders { get; set; }
        public int numberOfDeals { get; set; }
        public float totalBalance { get; set; }
        public int numberOfTransfers { get; set; }
        public int numberOfIntradayTransfers { get; set; }
        public float totalPerformance { get; set; }
        public float totalBuyingPower { get; set; }
        public float totalOwnCapital { get; set; }
        public float totalPerformancePercent { get; set; }
    }
}