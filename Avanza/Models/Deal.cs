using System;
using System.Text.Json.Serialization;

namespace Avanza
{
    public class Deal
    {
        public AccountSummary account { get; set; }
        public Orderbook2 orderbook { get; set; }
        public float price { get; set; }
        public string orderId { get; set; }
        public int volume { get; set; }
        [JsonConverter(typeof(DateTimeConverterUsingDateTimeParse))]
        public DateTime dealTime { get; set; }
        public bool marketTransaction { get; set; }
        public string dealId { get; set; }
        public float sum { get; set; }
        public string type { get; set; }
    }
}