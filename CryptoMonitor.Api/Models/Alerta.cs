namespace CryptoMonitor.Api.Models
{
    public class Alerta
    {
        public string Simbolo { get; set; } = "";
        public decimal PrecoMin { get; set; }
        public decimal PrecoMax { get; set; }
    }
}
