namespace Avanza
{
    public class GetPositionResult
    {
        public Instrumentposition[] instrumentPositions { get; set; }
        public float totalBuyingPower { get; set; }
        public float totalOwnCapital { get; set; }
        public float totalBalance { get; set; }
        public float totalProfitPercent { get; set; }
        public float totalProfit { get; set; }
    }
}