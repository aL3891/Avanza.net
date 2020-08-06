namespace Avanza
{
    public class DealsAndOrderResult
    {
        public Order[] orders { get; set; }
        public Deal[] deals { get; set; }
        public AccountSummary[] accounts { get; set; }
        public float reservedAmount { get; set; }
    }
}

