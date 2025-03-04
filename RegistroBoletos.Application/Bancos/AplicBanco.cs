using AutoMapper;
using RegistroBoletos.Application.Bancos.Dtos;
using RegistroBoletos.Application.Bancos.Views;
using RegistroBoletos.Domain.Entidades.Bancos;
using RegistroBoletos.Domain.Validators.Bancos;

namespace RegistroBoletos.Application.Bancos
{
    public class AplicBanco : IAplicBanco
    {
        private readonly IRepBanco _repBanco;
        private readonly IMapper _mapper;

        public AplicBanco(IRepBanco repBanco,
                          IMapper mapper)
        {
            _repBanco = repBanco;
            _mapper = mapper;
        }

        public void InserirNovoBanco(InserirBancoDto dto)
        {
            var banco = _mapper.Map<Banco>(dto) ?? new Banco();

            var ValidarBanco = new Validator_NovoBanco(banco, _repBanco);
            ValidarBanco.Validate();

            _repBanco.InsertPersist(banco);
        }
        public List<BancoView> ListarTodos()
        {
            var bancos = _repBanco.Consulta.ToList();
            return _mapper.Map<List<BancoView>>(bancos);
        }
        public BancoView RecuperarBanco(string codigoBanco)
        {
            var banco = _repBanco.Consulta.FirstOrDefault(p => p.CodigoBanco == codigoBanco);

            return _mapper.Map<BancoView>(banco);
        }
    }
}
