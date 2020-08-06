using Microsoft.VisualStudio.TestTools.UnitTesting;
using OtpNet;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Avanza.Tests
{
    [TestClass]
    public class AvanzaTests
    {
        static string username = "";
        static string password = "";
        static string totpSecret = "";
        static Avanza sharedClient = null;

        [ClassInitialize]
        public static async Task Setup(TestContext testContext)
        {
            sharedClient = new Avanza();
            await sharedClient.Authenticate(username, password, totpSecret);
        }

        [TestMethod]
        public async Task AddToWatchlist()
        {
            var w = await sharedClient.GetWatchlists();
            await sharedClient.AddToWatchlist("750331", w.First().id);
        }

        [TestMethod]
        [Ignore]
        public async Task DeleteOrder()
        {
            var d = await sharedClient.GetDealsAndOrders();
            var order = d.orders.First();
            await sharedClient.DeleteOrder(order.account.id, order.orderId);
        }

        [TestMethod]
        public async Task EditOrder()
        {
            var d = await sharedClient.GetDealsAndOrders();
            var order = d.orders.First();
            await sharedClient.EditOrder(order.orderbook.type, order.orderId, order.account.id, order.orderbook.id, order.type, 81, DateTime.UtcNow.AddDays(2), 2);
        }

        [TestMethod]
        public async Task GetAccountOverview()
        {
            var o = await sharedClient.GetOverview();
            await sharedClient.GetAccountOverview(o.accounts.First().accountId);
        }

        [TestMethod]
        public async Task GetChartdata()
        {
            await sharedClient.GetChartdata("750331", Chartdata.TODAY);
        }

        [TestMethod]
        public async Task GetDealsAndOrders()
        {
            await sharedClient.GetDealsAndOrders();
        }

        [TestMethod]
        public async Task GetInspirationList()
        {
            await sharedClient.GetInspirationList(Lists.BEST_DEVELOPMENT_FUNDS_LAST_THREE_MONTHS);
        }

        [TestMethod]
        public async Task GetInspirationLists()
        {
            await sharedClient.GetInspirationLists();
        }

        [TestMethod]
        public async Task GetInstrument()
        {
            await sharedClient.GetInstrument(InstrumentTypes.STOCK, "750331");
        }

        [TestMethod]
        public async Task GetOrder()
        {
            var d = await sharedClient.GetDealsAndOrders();
            var order = d.orders.First();
            await sharedClient.GetOrder(order.orderbook.type, order.orderId);
        }

        [TestMethod]
        public async Task GetOrderbook()
        {
            await sharedClient.GetOrderbook(InstrumentTypes.STOCK, "750331");
        }

        [TestMethod]
        public async Task GetOrderbooks()
        {
            await sharedClient.GetOrderbooks("750331");
        }

        [TestMethod]
        public async Task GetOverview()
        {
            await sharedClient.GetOverview();
        }

        [TestMethod]
        public async Task GetPositions()
        {
            await sharedClient.GetPositions();
        }

        [TestMethod]
        public async Task GetTransactions()
        {
            await sharedClient.GetTransactions(Transactions.BUY_SELL, DateTime.UtcNow.AddDays(3), DateTime.UtcNow, 10, 0);
        }

        [TestMethod]
        public async Task GetWatchlists()
        {
            await sharedClient.GetWatchlists();
        }

        [TestMethod] 
        [Ignore]
        public async Task PlaceOrder()
        {
            var o = await sharedClient.GetOverview();
            var instrument = await sharedClient.Search("veoneer", InstrumentTypes.STOCK);
            await sharedClient.PlaceOrder(o.accounts.First().accountId, instrument.hits.First().topHits.First().id, OrderType.BUY, 80, DateTime.UtcNow.AddDays(1), 1);
        }

        [TestMethod]
        public async Task RemoveFromWatchlist()
        {
            var w = await sharedClient.GetWatchlists();
            await sharedClient.RemoveFromWatchlist("750331", w.First().id);
        }

        [TestMethod]
        public async Task Search()
        {
            await sharedClient.Search("veoneer", InstrumentTypes.STOCK);
        }

        [TestMethod]
        public async Task Subscribe()
        {
            await sharedClient.Subscribe("", "");
        }


        [TestMethod]
        [Ignore]
        public async Task Authenticate()
        {
            var avanza = new Avanza();
            await avanza.Authenticate(username, password, totpSecret);
        }


        [TestMethod]
        public async Task TotpTest()
        {
            var totp = new Totp(Base32Encoding.ToBytes(totpSecret));
            var totpCode = totp.ComputeTotp();
        }
    }
}
