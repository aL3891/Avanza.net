namespace Avanza
{
    public class AccountOverviewResult
    {
        public string courtageClass { get; set; }
        public bool depositable { get; set; }
        public string accountType { get; set; }
        public bool withdrawable { get; set; }
        public string accountId { get; set; }
        public string accountTypeName { get; set; }
        public string clearingNumber { get; set; }
        public bool instrumentTransferPossible { get; set; }
        public bool internalTransferPossible { get; set; }
        public bool jointlyOwned { get; set; }
        public float interestRate { get; set; }
        public int numberOfOrders { get; set; }
        public int numberOfDeals { get; set; }
        public float performanceSinceOneWeek { get; set; }
        public float performanceSinceOneMonth { get; set; }
        public float performanceSinceThreeMonths { get; set; }
        public float performanceSinceSixMonths { get; set; }
        public float performanceSinceOneYear { get; set; }
        public float performanceSinceThreeYears { get; set; }
        public float performanceSinceOneWeekPercent { get; set; }
        public float performanceSinceOneMonthPercent { get; set; }
        public float performanceSinceThreeMonthsPercent { get; set; }
        public float performanceSinceSixMonthsPercent { get; set; }
        public float performanceSinceOneYearPercent { get; set; }
        public float performanceSinceThreeYearsPercent { get; set; }
        public Currencyaccount[] currencyAccounts { get; set; }
        public float creditLimit { get; set; }
        public float forwardBalance { get; set; }
        public float reservedAmount { get; set; }
        public float totalCollateralValue { get; set; }
        public float totalPositionsValue { get; set; }
        public float buyingPower { get; set; }
        public float totalProfitPercent { get; set; }
        public float availableSuperLoanAmount { get; set; }
        public float totalProfit { get; set; }
        public bool allowMonthlySaving { get; set; }
        public float totalBalance { get; set; }
        public float ownCapital { get; set; }
        public float performancePercent { get; set; }
        public float creditAfterInterest { get; set; }
        public float accruedInterest { get; set; }
        public float performance { get; set; }
        public bool overMortgaged { get; set; }
        public bool overdrawn { get; set; }
        public int numberOfTransfers { get; set; }
        public int numberOfIntradayTransfers { get; set; }
        public float sharpeRatio { get; set; }
        public float standardDeviation { get; set; }
    }
}