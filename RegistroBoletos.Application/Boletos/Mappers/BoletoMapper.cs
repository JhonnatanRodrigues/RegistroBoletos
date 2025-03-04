using AutoMapper;
using RegistroBoletos.Application.Boletos.Dtos;
using RegistroBoletos.Application.Boletos.Views;
using RegistroBoletos.Domain.Entidades.Boletos;

namespace RegistroBoletos.Application.Boletos.Mappers
{
    public class BoletoMapper : Profile
    {
        public BoletoMapper()
        {
            CreateMap<BoletoDto, Boleto>();
            CreateMap<Boleto, BoletoView>();
        }
    }
}
