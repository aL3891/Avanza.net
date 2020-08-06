using System;
using System.Text.Json.Serialization;

namespace Avanza
{
    public class ComparisonPoint
    {
        [JsonConverter(typeof(DateTimeConverterUsingDateTimeParse))]
        public DateTime timestamp { get; set; }
        public float value { get; set; }
    }
}