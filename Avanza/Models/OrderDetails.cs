using System;

namespace Avanza
{
    public class OrderDetails
    {
        public Customer customer { get; set; }
        public Account account { get; set; }
        public Orderbook orderbook { get; set; }
        public string firstTradableDate { get; set; }
        public string lastTradableDate { get; set; }
        public string[] untradableDates { get; set; }
        public Orderdepthlevel[] orderDepthLevels { get; set; }
        public bool marketMakerExpected { get; set; }
        public DateTime orderDepthReceivedTime { get; set; }
        public Latesttrade[] latestTrades { get; set; }
        public bool marketTrades { get; set; }
        public bool hasShortSellKnowledge { get; set; }
        public bool hasInstrumentKnowledge { get; set; }
        public Brokertradesummary brokerTradeSummary { get; set; }
        public Hasinvestmentfees hasInvestmentFees { get; set; }
        public Ticksizerule[] tickSizeRules { get; set; }
        public OrderSummary order { get; set; }
    }
}