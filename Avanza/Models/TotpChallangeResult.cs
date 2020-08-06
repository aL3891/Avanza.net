namespace Avanza
{
    public class TotpChallangeResult
    {
        public string authenticationSession { get; set; }
        public string pushSubscriptionId { get; set; }
        public string customerId { get; set; }
        public bool registrationComplete { get; set; }
    }
}