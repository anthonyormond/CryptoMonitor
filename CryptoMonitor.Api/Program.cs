using CryptoMonitor.Api.Repositories;
using CryptoMonitor.Api.Repositories.Interfaces;
using CryptoMonitor.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); // necess�rio para Swagger
builder.Services.AddSwaggerGen( c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {

        Title = "Crypto Monitor API",
        Version = "v1",
        Description = "API para monitoramento de pre�os de criptomoedas em tempo real",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Anthony",
            Email = ""
        }

    });
    
}); // registra o Swagger

builder.Services.AddHttpClient<IMoedaRepository, MoedaApiRepository>((sp, client) =>
{
    var config = sp.GetRequiredService<IConfiguration>();
    var baseUrl = config["Binance:BaseUrl"];
    client.BaseAddress = new Uri(baseUrl);
});

builder.Services.AddScoped<IMoedaService, MoedaService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // habilita Swagger
    app.UseSwaggerUI(); // habilita interface gr�fica
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
