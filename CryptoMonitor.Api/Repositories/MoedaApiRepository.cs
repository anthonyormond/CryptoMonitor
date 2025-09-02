using CryptoMonitor.Api.Models;
using CryptoMonitor.Api.Repositories.Interfaces;
using System.Text.Json;

namespace CryptoMonitor.Api.Repositories
{
    public class MoedaApiRepository
    {
        public class MoedaRepository : IMoedaRepository
        {
            private readonly HttpClient _httpClient;

            public MoedaRepository(HttpClient httpClient)
            {
                _httpClient = httpClient;
            }

            public async Task<decimal?> GetPrecoAsync(string simbolo)
            {
                try
                {
                    var url = $"https://api.binance.com/api/v3/ticker/price?symbol={simbolo}USDT";
                    var response = await _httpClient.GetStringAsync(url);
                    using var doc = JsonDocument.Parse(response);
                    return decimal.Parse(doc.RootElement.GetProperty("price").GetString());
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}