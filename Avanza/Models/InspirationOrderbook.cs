using System;
using System.Text.Json.Serialization;

namespace Avanza
{
    public class InspirationOrderbook
    {
        public float priceThreeMonthsAgo { get; set; }
        public string currency { get; set; }
        public float priceOneYearAgo { get; set; }
        public float lastPrice { get; set; }
        public float change { get; set; }
        public float changePercent { get; set; }
        [JsonConverter(typeof(DateTimeConverterUsingDateTimeParse))]
        public DateTime updated { get; set; }
        public float highlightValue { get; set; }
        public string flagCode { get; set; }
        public string name { get; set; }
        public string id { get; set; }
        public string lastUpdated { get; set; }
        public float changeSinceOneDay { get; set; }
        public float changeSinceThreeMonths { get; set; }
        public float changeSinceOneYear { get; set; }
    }
}