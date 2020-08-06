using System;

namespace Avanza
{
    public class Latesttrade
    {
        public bool cancelled { get; set; }
        public float price { get; set; }
        public int volume { get; set; }
        public DateTime dealTime { get; set; }
        public bool matchedOnMarket { get; set; }
        public string buyer { get; set; }
    }
}