namespace Avanza
{
    public class OrderSummary
    {
        public float price { get; set; }
        public string validUntil { get; set; }
        public string orderType { get; set; }
        public int volume { get; set; }
        public string orderCondition { get; set; }
    }
}