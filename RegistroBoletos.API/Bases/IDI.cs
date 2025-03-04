using RegistroBoletos.Application.Bancos;
using RegistroBoletos.Application.Bancos.Mappers;
using RegistroBoletos.Application.Boletos;
using RegistroBoletos.Application.Boletos.Mappers;
using RegistroBoletos.Domain.Entidades.Bancos;
using RegistroBoletos.Domain.Entidades.Boletos;
using RegistroBoletos.Infrastructure.Repositorios.Bancos;
using RegistroBoletos.Infrastructure.Repositorios.Boletos;

namespace RegistroBoletos.API.Bases
{
    public static class IDI
    {
        public static WebApplicationBuilder IDIAplicacoes(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IAplicBanco, AplicBanco>();
            builder.Services.AddScoped<IAplicBoleto, AplicBoleto>();

            return builder;
        }
        public static WebApplicationBuilder IDIServicos(this WebApplicationBuilder builder)
        {

            return builder;
        }
        public static WebApplicationBuilder IDIRepositorio(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IRepBanco, RepBanco>();
            builder.Services.AddScoped<IRepBoleto, RepBoleto>();

            return builder;
        }
        public static WebApplicationBuilder IDIMappers(this WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(typeof(BancoMapper).Assembly);
            builder.Services.AddAutoMapper(typeof(BoletoMapper).Assembly);

            return builder;
        }
    }
}
