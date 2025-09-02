using CryptoMonitor.Api.Models;

namespace CryptoMonitor.Api.Repositories
{
    public class MoedaRepository
    {
        private readonly List<Moeda> _moedas = new()
        {
            new Moeda { Simbolo = "BTC", Preco = 68000 },
            new Moeda { Simbolo = "ETH", Preco = 3500 },
            new Moeda { Simbolo = "SOL", Preco = 150 }
        };

        public IEnumerable<Moeda> GetAll() => _moedas;

        public Moeda? GetBySymbol(string simbolo) =>
            _moedas.FirstOrDefault(m => m.Simbolo.Equals(simbolo, StringComparison.OrdinalIgnoreCase));
    }
}
