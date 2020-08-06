using System;
using System.Text.Json.Serialization;

namespace Avanza
{
    public class Position
    {
        public string accountName { get; set; }
        public string accountType { get; set; }
        public bool depositable { get; set; }
        public string accountId { get; set; }
        public float value { get; set; }
        public float volume { get; set; }
        public float averageAcquiredPrice { get; set; }
        public float profitPercent { get; set; }
        public float acquiredValue { get; set; }
        public float profit { get; set; }
        public string name { get; set; }
        public string currency { get; set; }
        public string orderbookId { get; set; }
        public float lastPrice { get; set; }
        [JsonConverter(typeof(DateTimeConverterUsingDateTimeParse))]
        public DateTime lastPriceUpdated { get; set; }
        public float change { get; set; }
        public float changePercent { get; set; }
        public bool tradable { get; set; }
        public string flagCode { get; set; }
        public float changePercentPeriod { get; set; }
        public float changePercentThreeMonths { get; set; }
    }
}





