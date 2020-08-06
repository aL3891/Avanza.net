namespace Avanza
{
    public class Account
    {
        public string accountType { get; set; }
        public float interestRate { get; set; }
        public bool depositable { get; set; }
        public bool active { get; set; }
        public string accountId { get; set; }
        public bool tradable { get; set; }
        public float totalBalance { get; set; }
        public bool accountPartlyOwned { get; set; }
        public float totalBalanceDue { get; set; }
        public float ownCapital { get; set; }
        public float buyingPower { get; set; }
        public float totalProfitPercent { get; set; }
        public float performance { get; set; }
        public float performancePercent { get; set; }
        public float totalProfit { get; set; }
        public bool attorney { get; set; }
        public string name { get; set; }
    }
}