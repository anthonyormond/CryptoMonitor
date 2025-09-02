using CryptoMonitor.Api.Models;
using CryptoMonitor.Api.Repositories.Interfaces;
using CryptoMonitor.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace CryptoMonitor.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoedaController : ControllerBase
    {
        private readonly IMoedaService _moedaService;

        public MoedaController(IMoedaService moedaService)
        {
            _moedaService = moedaService;
        }

        [HttpGet("{simbolo}")]
        public async Task<IActionResult> GetPreco(string simbolo)
        {
            try
            {
                var preco = await _moedaService.BuscarPorSimboloAsync(simbolo.ToUpper());

                if (preco == null)
                    return NotFound(ApiResponse<string>.Erro($"Preço para {simbolo} não encontrado."));

                return Ok(ApiResponse<decimal?>.Ok(preco));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<string>.Erro($"Erro interno: {ex.Message}"));
            }
        }
    }
}
