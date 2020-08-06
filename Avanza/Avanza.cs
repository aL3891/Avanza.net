using OtpNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;


namespace Avanza
{
    public class Avanza
    {
        public static int MIN_INACTIVE_MINUTES = 30;
        public static int MAX_INACTIVE_MINUTES = 60 * 24;
        public static string SOCKET_URL = "wss://www.avanza.se/_push/cometd";
        public static int MAX_BACKOFF_MS = 2 * 60 * 1000;
        HttpClient _client;

        public string PushSubscriptionId { get; private set; }

        public Avanza()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://www.avanza.se");
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));
            _client.DefaultRequestHeaders.UserAgent.ParseAdd("Avanza API client/2.0.0");
            _client.DefaultRequestHeaders.Add("X-AuthenticationSession", "");
            _client.DefaultRequestHeaders.Add("X-SecurityToken", "");
        }

        public async Task Authenticate(string username, string password, string totpSecret)
        {
            _client.DefaultRequestHeaders.Remove("X-AuthenticationSession");
            _client.DefaultRequestHeaders.Remove("X-SecurityToken");

            var res = await _client.PostAsync("/_api/authentication/sessions/usercredentials", JsonContent.Create(new
            {
                maxInactiveMinutes = 60,
                password = password,
                username = username
            }));

            var loginResult = await res.Content.ReadFromJsonAsync<LoginResult>();

            var totp = new Totp(Base32Encoding.ToBytes(totpSecret));
            var code = totp.ComputeTotp();

            var totpRequest = new HttpRequestMessage
            {
                Content = JsonContent.Create(new { method = "TOTP", totpCode = code }),
                Method = HttpMethod.Post
            };

            totpRequest.Headers.Add("Cookie", $"AZAMFATRANSACTION={loginResult.twoFactorLogin.transactionId}");

            res = await _client.PostAsync("/_api/authentication/sessions/totp", JsonContent.Create(new
            {
                method = "TOTP",
                totpCode = code
            }));

            var sec = res.Headers.GetValues("x-securitytoken").First();
            var toptresult = await res.Content.ReadFromJsonAsync<TotpChallangeResult>();
            PushSubscriptionId = toptresult.pushSubscriptionId;

            _client.DefaultRequestHeaders.Add("X-AuthenticationSession", toptresult.authenticationSession);
            _client.DefaultRequestHeaders.Add("X-SecurityToken", sec);
        }

        public async Task Disconnect()
        {


        }

        public async Task<GetPositionResult> GetPositions()
        {
            var res = await _client.GetAsync("/_mobile/account/positions");

            //var json =  await res.Content.ReadAsStringAsync();
            //Console.WriteLine(json);

            return await res.Content.ReadFromJsonAsync<GetPositionResult>();
        }

        public async Task<AvanzaOverview> GetOverview()
        {
            var res = await _client.GetAsync("/_mobile/account/overview");

            //var json =  await res.Content.ReadAsStringAsync();
            //Console.WriteLine(json);

            return await res.Content.ReadFromJsonAsync<AvanzaOverview>();
        }

        public async Task<AccountOverviewResult> GetAccountOverview(string account)
        {
            var res = await _client.GetAsync($"/_mobile/account/{account}/overview");

            //var json =  await res.Content.ReadAsStringAsync();
            //Console.WriteLine(json);

            return await res.Content.ReadFromJsonAsync<AccountOverviewResult>();

        }

        public async Task<DealsAndOrderResult> GetDealsAndOrders()
        {
            var res = await _client.GetAsync("/_mobile/account/dealsandorders");

            var json = await res.Content.ReadAsStringAsync();
            Console.WriteLine(json);

            return await res.Content.ReadFromJsonAsync<DealsAndOrderResult>();
        }

        public async Task<string> GetTransactions(string accountOrTransactionType, DateTime from, DateTime to, int maxAmount, int minAmount, params string[] orderbookIds)
        {
            var res = await _client.GetAsync($"/_mobile/account/transactions/{accountOrTransactionType}?from={from}&to={to}&maxAmount?{maxAmount}&minAmount={minAmount}&orderbookId{orderbookIds}");

            var json = await res.Content.ReadAsStringAsync();
            Console.WriteLine(json);

            return await res.Content.ReadAsStringAsync();
        }

        public async Task<List<Watchlist>> GetWatchlists()
        {
            var res = await _client.GetAsync("/_mobile/usercontent/watchlist");

            var json = await res.Content.ReadAsStringAsync();
            Console.WriteLine(json);

            return await res.Content.ReadFromJsonAsync<List<Watchlist>>();
        }

        public async Task<string> AddToWatchlist(string instrumentId, string watchlistId)
        {
            var res = await _client.PutAsync($"/_api/usercontent/watchlist/{watchlistId.ToLower()}/orderbooks/{instrumentId}", null);

            return await res.Content.ReadAsStringAsync();
        }

        public async Task<string> RemoveFromWatchlist(string instrumentId, string watchlistId)
        {
            var res = await _client.DeleteAsync($"/_api/usercontent/watchlist/{watchlistId.ToLower()}/orderbooks/{instrumentId}");

            return await res.Content.ReadAsStringAsync();
        }

        public async Task<GetInstrumentResult> GetInstrument(string instrumentType, string instrumentId)
        {
            var res = await _client.GetAsync($"/_mobile/market/{instrumentType.ToLower()}/{instrumentId}");

            //var json =  await res.Content.ReadAsStringAsync();
            //Console.WriteLine(json);


            return await res.Content.ReadFromJsonAsync<GetInstrumentResult>();
        }

        public async Task<GetOrderbookResult> GetOrderbook(string instrumentType, string instrumentId)
        {
            var res = await _client.GetAsync($"/_mobile/order/{instrumentType.ToLower()}?orderbookId={instrumentId}");
            var json = await res.Content.ReadAsStringAsync();
            Console.WriteLine(json);

            return await res.Content.ReadFromJsonAsync<GetOrderbookResult>();
        }

        public async Task<string> GetOrderbooks(params string[] orderbookId)
        {
            var res = await _client.GetAsync($"/_mobile/market/orderbooklist/{string.Join(',', orderbookId)}?sort=name");
            var json = await res.Content.ReadAsStringAsync();
            Console.WriteLine(json);

            return await res.Content.ReadAsStringAsync();
        }

        public async Task<ChartDataResult> GetChartdata(string orderbookId, string period)
        {
            var res = await _client.GetAsync($"/_mobile/chart/orderbook/{orderbookId}");
            var json = await res.Content.ReadAsStringAsync();
            Console.WriteLine(json);

            return await res.Content.ReadFromJsonAsync<ChartDataResult>();
        }

        public async Task<InspirationListsResult> GetInspirationLists()
        {
            var res = await _client.GetAsync("/_mobile/marketing/inspirationlist");
            //var json =  await res.Content.ReadAsStringAsync();
            //Console.WriteLine(json);

            return await res.Content.ReadFromJsonAsync<InspirationListsResult>();
        }

        public async Task<string> GetInspirationList(string type)
        {
            var res = await _client.GetAsync($"/_mobile/marketing/inspirationlist/{type}");

            var json = await res.Content.ReadAsStringAsync();
            Console.WriteLine(json);
            return json;

        }

        public async Task<string> Subscribe(string channel, params string[] ids)
        {

            return "";
        }

        public async Task<OrderResult> PlaceOrder(string accountId, string orderbookId, string orderType, decimal price, DateTime validUntil, int number)
        {
            var res = await _client.PostAsync("/_api/order", JsonContent.Create(new
            {
                accountId = accountId,
                orderbookId = orderbookId,
                orderType = orderType,
                price = price,
                validUntil = validUntil.ToString("yyyy-MM-dd"),
                volume = number
            }));

            //var json = await res.Content.ReadAsStringAsync();
            //Console.WriteLine(json);


            return await res.Content.ReadFromJsonAsync<OrderResult>();
        }

        public async Task<OrderDetails> GetOrder(string instrumentType, string orderId)
        {
            var res = await _client.GetAsync($"/_mobile/order/{instrumentType.ToLower()}?orderId={orderId}");
            //var json = await res.Content.ReadAsStringAsync();
            //Console.WriteLine(json);

            return await res.Content.ReadFromJsonAsync<OrderDetails>();
        }

        public async Task<OrderResult> EditOrder(string instrumentType, string orderId, string accountId, string orderbookId, string orderType, decimal price, DateTime validUntil, int number)
        {
            var res = await _client.PutAsync($"/_api/order/{instrumentType.ToLower()}/{orderId}", JsonContent.Create(new
            {
                accountId = accountId,
                orderbookId = orderbookId,
                orderType = orderType,
                price = price,
                validUntil = validUntil.ToString("yyyy-MM-dd"),
                volume = number
            }));

            //var json = await res.Content.ReadAsStringAsync();
            //Console.WriteLine(json);

            return await res.Content.ReadFromJsonAsync<OrderResult>();
        }

        public async Task<OrderResult> DeleteOrder(string accountId, string orderId)
        {
            var res = await _client.DeleteAsync($"/_api/order?accountId={accountId}&orderId={orderId}");
            //var json = await res.Content.ReadAsStringAsync();
            //Console.WriteLine(json);

            return await res.Content.ReadFromJsonAsync<OrderResult>();
        }

        public async Task<SearchResult> Search(string searchQuery, string type)
        {
            var res = await _client.GetAsync($"/_mobile/market/search/{type.ToUpper()}?limit=100&query=" + Uri.EscapeDataString(searchQuery));

            //var json =  await res.Content.ReadAsStringAsync();
            //Console.WriteLine(json);

            return await res.Content.ReadFromJsonAsync<SearchResult>();
        }

        public async Task<SearchResult> Search(string searchQuery)
        {
            var res = await _client.GetAsync($"/_mobile/market/search/?limit=100&query=" + Uri.EscapeDataString(searchQuery));

            //var json =  await res.Content.ReadAsStringAsync();
            //Console.WriteLine(json);

            return await res.Content.ReadFromJsonAsync<SearchResult>();
        }
    }
}
