using CryptoMonitor.Api.Repositories;
using CryptoMonitor.Api.Repositories.Interfaces;
using CryptoMonitor.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddHttpClient<IMoedaRepository, MoedaApiRepository>((sp, client) =>
{
    var config = sp.GetRequiredService<IConfiguration>();
    var baseUrl = config["Binance:BaseUrl"];
    client.BaseAddress = new Uri(baseUrl);
});

builder.Services.AddScoped<IMoedaService, MoedaService>();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
