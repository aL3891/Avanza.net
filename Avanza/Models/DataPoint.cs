using System;
using System.Text.Json.Serialization;

namespace Avanza
{
    public class DataPoint
    {
        [JsonConverter(typeof(DateTimeConverterUsingDateTimeParse))]
        public DateTime timestamp { get; set; }
        public float value { get; set; }
    }
}