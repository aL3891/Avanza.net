using System;
using System.Text.Json.Serialization;

namespace Avanza
{
    public class ChartDataResult
    {
        public DataPoint[] dataSeries { get; set; }
        public ComparisonPoint[] comparisonSeries { get; set; }
        public float min { get; set; }
        public float max { get; set; }
        public float floor { get; set; }
        public float ceiling { get; set; }
        public float change { get; set; }
        public float changePercent { get; set; }
        [JsonConverter(typeof(DateTimeConverterUsingDateTimeParse))]
        public DateTime openingTime { get; set; }
        [JsonConverter(typeof(DateTimeConverterUsingDateTimeParse))]
        public DateTime closingTime { get; set; }
        public string comparisonName { get; set; }
    }
}