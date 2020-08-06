namespace Avanza
{
    public class OrderResult
    {
        public string status { get; set; }
        public string[] messages { get; set; }
        public string requestId { get; set; }
        public string orderId { get; set; }
    }
}
