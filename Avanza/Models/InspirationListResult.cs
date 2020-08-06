namespace Avanza
{
    public class InspirationListResult
    {
        public InspirationOrderbook[] orderbooks { get; set; }
        public float averageChange { get; set; }
        public string imageUrl { get; set; }
        public Highlightfield highlightField { get; set; }
        public float averageChangeSinceThreeMonths { get; set; }
        public string information { get; set; }
        public Statistics statistics { get; set; }
        public string instrumentType { get; set; }
        public string name { get; set; }
        public string id { get; set; }
    }
}