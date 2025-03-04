using AutoMapper;
using RegistroBoletos.Application.Bancos.Dtos;
using RegistroBoletos.Application.Bancos.Views;
using RegistroBoletos.Domain.Entidades.Bancos;

namespace RegistroBoletos.Application.Bancos.Mappers
{
    public class BancoMapper : Profile
    {
        public BancoMapper()
        {
            CreateMap<InserirBancoDto, Banco>();
            CreateMap<Banco, BancoView>();
        }
    }
}
