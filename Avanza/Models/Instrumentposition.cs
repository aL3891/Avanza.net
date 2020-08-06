namespace Avanza
{
    public class Instrumentposition
    {
        public string instrumentType { get; set; }
        public Position[] positions { get; set; }
        public float totalValue { get; set; }
        public float todaysProfitPercent { get; set; }
        public float totalProfitValue { get; set; }
        public float totalProfitPercent { get; set; }
    }
}