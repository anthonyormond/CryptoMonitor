using CryptoMonitor.Api.Models;

namespace CryptoMonitor.Api.Services
{
    public class AlertaService
    {
        public bool VerificarAlerta(Moeda moeda, Alerta alerta)
        {
            if (moeda.Preco <= alerta.PrecoMin) return true;
            if (moeda.Preco >= alerta.PrecoMax) return true;
            return false;
        }
    }
}
