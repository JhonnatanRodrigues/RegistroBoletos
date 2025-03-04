using AutoMapper;
using RegistroBoletos.Application.Boletos.Dtos;
using RegistroBoletos.Application.Boletos.Views;
using RegistroBoletos.Domain.Entidades.Bancos;
using RegistroBoletos.Domain.Entidades.Boletos;
using RegistroBoletos.Domain.Validators.Boletos;

namespace RegistroBoletos.Application.Boletos
{
    public class AplicBoleto : IAplicBoleto
    {
        private readonly IRepBoleto _repBoleto;
        private readonly IRepBanco _repBanco;
        private readonly IMapper _mapper;

        public AplicBoleto(IRepBoleto repBoleto,
                           IRepBanco repBanco,
                           IMapper mapper)
        {
            _repBoleto = repBoleto;
            _repBanco = repBanco;
            _mapper = mapper;
        }

        public void InserirNovoBoleto(BoletoDto dto)
        {
            var boleto = _mapper.Map<Boleto>(dto)
                            ?? throw new Exception("Boleto não informado!");

            boleto.Banco = _repBanco.Consulta.FirstOrDefault(p => p.Id == dto.CodigoBanco)
                                ?? throw new Exception("Banco informado não foi encontrado.");

            var validarBoleto = new Validator_NovoBoleto(boleto);
            validarBoleto.Validate();

            _repBoleto.InsertPersist(boleto);
        }

        public BoletoView RecuperarBoleto(Guid id)
        {
            var boleto = _repBoleto.Consulta.FirstOrDefault(p => p.Id == id)
                                ?? throw new Exception("Boleto não encontrado!");

            boleto.AplicarJuros();

            return _mapper.Map<BoletoView>(boleto);
        }

        public List<BoletoView> ListarTodosBoletos()
        {
            var boletos = _repBoleto.Consulta.ToList();

            boletos.ForEach(boleto => boleto.AplicarJuros());

            return _mapper.Map<List<BoletoView>>(boletos);
        }
    }
}
