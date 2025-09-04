using CryptoMonitor.Api.Models;
using CryptoMonitor.Api.Repositories.Interfaces;
using System.Text.Json;

namespace CryptoMonitor.Api.Repositories
{
    
    public class MoedaApiRepository : IMoedaRepository
    {
        private readonly HttpClient _httpClient;

        public MoedaApiRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<decimal?> GetPrecoAsync(string simbolo)
        {
            try
            {

                var response = await _httpClient.GetStringAsync($"ticker/price?symbol={simbolo}USDT");
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