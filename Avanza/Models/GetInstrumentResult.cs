using System;
using System.Text.Json.Serialization;

namespace Avanza
{
    public class GetInstrumentResult
    {
        public float priceThreeMonthsAgo { get; set; }
        public float priceOneWeekAgo { get; set; }
        public float priceOneMonthAgo { get; set; }
        public float priceSixMonthsAgo { get; set; }
        public float priceAtStartOfYear { get; set; }
        public float priceOneYearAgo { get; set; }
        public float priceThreeYearsAgo { get; set; }
        public string marketPlace { get; set; }
        [JsonConverter(typeof(DateTimeConverterUsingDateTimeParse))]
        public DateTime quoteUpdated { get; set; }
        public bool hasInvestmentFees { get; set; }
        public string currency { get; set; }
        public bool tradable { get; set; }
        public float lowestPrice { get; set; }
        public float highestPrice { get; set; }
        public int totalVolumeTraded { get; set; }
        public string isin { get; set; }
        public bool shortSellable { get; set; }
        public float lastPrice { get; set; }
        [JsonConverter(typeof(DateTimeConverterUsingDateTimeParse))]
        public DateTime lastPriceUpdated { get; set; }
        public float change { get; set; }
        public float changePercent { get; set; }
        public float totalValueTraded { get; set; }
        public string tickerSymbol { get; set; }
        public float loanFactor { get; set; }
        public string flagCode { get; set; }
        public string name { get; set; }
        public string id { get; set; }
        public string country { get; set; }
        public Keyratios keyRatios { get; set; }
        public int numberOfOwners { get; set; }
        public bool superLoan { get; set; }
        public int numberOfPriceAlerts { get; set; }
        public bool pushPermitted { get; set; }
        public Dividend[] dividends { get; set; }
        public Relatedstock[] relatedStocks { get; set; }
        public Company company { get; set; }
        public object[] orderDepthLevels { get; set; }
        public bool marketMakerExpected { get; set; }
        [JsonConverter(typeof(DateTimeConverterUsingDateTimeParse))]
        public DateTime orderDepthReceivedTime { get; set; }
        public object[] latestTrades { get; set; }
        public bool marketTrades { get; set; }
        public object[] positions { get; set; }
        public float positionsTotalValue { get; set; }
        public Annualmeeting[] annualMeetings { get; set; }
        public Companyreport[] companyReports { get; set; }
        public Brokertradesummary brokerTradeSummary { get; set; }
        public Companyowners companyOwners { get; set; }
    }
}
