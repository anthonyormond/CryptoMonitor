namespace CryptoMonitor.Api.Repositories.Interfaces
{
    public interface IMoedaService
    {
        Task<decimal?> BuscarPorSimboloAsync(string simbolo);
    }
}
