namespace CryptoMonitor.Api.Repositories.Interfaces
{
    public interface IMoedaRepository
    {
        Task<decimal?> GetPrecoAsync(string simbolo);
    }
}
