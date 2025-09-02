using CryptoMonitor.Api.Models;
using CryptoMonitor.Api.Repositories;
using CryptoMonitor.Api.Repositories.Interfaces;

namespace CryptoMonitor.Api.Services
{
    public class MoedaService : IMoedaService
    {
        private readonly IMoedaRepository _repository;

        public MoedaService(IMoedaRepository repository)
        {
            _repository = repository;
        }

        public async Task<decimal?> BuscarPorSimboloAsync(string simbolo)
        {
            return await _repository.GetPrecoAsync(simbolo);
        }
    }
}
