using System;

namespace Avanza
{
    public class Orderbook
    {
        public float highestPrice { get; set; }
        public int totalVolumeTraded { get; set; }
        public float lowestPrice { get; set; }
        public float buyPrice { get; set; }
        public float sellPrice { get; set; }
        public float spread { get; set; }
        public float lastPrice { get; set; }
        public DateTime lastPriceUpdated { get; set; }
        public float change { get; set; }
        public float changePercent { get; set; }
        public float totalValueTraded { get; set; }
        public float exchangeRate { get; set; }
        public float positionVolume { get; set; }
        public string name { get; set; }
        public string id { get; set; }
        public string type { get; set; }
        public string currency { get; set; }
        public bool tradable { get; set; }
        public string tickerSymbol { get; set; }
        public int tradingUnit { get; set; }
        public float volumeFactor { get; set; }
        public string flagCode { get; set; }
        public string marketPlace { get; set; }
    }
}
