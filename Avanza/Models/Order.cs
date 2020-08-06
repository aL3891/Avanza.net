using Avanza;
using System;
using System.Text.Json.Serialization;

namespace Avanza
{
    public class Order
    {
        public Transactionfees transactionFees { get; set; }
        public Orderbook orderbook { get; set; }
        public AccountSummary account { get; set; }
        public string status { get; set; }
        public string statusDescription { get; set; }
        public string rawStatus { get; set; }
        public string type { get; set; }
        public string validUntil { get; set; }
        public object openVolume { get; set; }
        public bool marketTransaction { get; set; }
        public bool deletable { get; set; }
        public int volume { get; set; }
        public string orderId { get; set; }
        public float price { get; set; }
        public bool modifyAllowed { get; set; }
        [JsonConverter(typeof(DateTimeConverterUsingDateTimeParse))]
        public DateTime orderDateTime { get; set; }
        public float sum { get; set; }
    }
}