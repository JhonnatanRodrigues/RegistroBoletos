using RegistroBoletos.Application.Boletos.Dtos;
using RegistroBoletos.Application.Boletos.Views;

namespace RegistroBoletos.Application.Boletos
{
    public interface IAplicBoleto
    {
        void InserirNovoBoleto(BoletoDto dto);
        BoletoView RecuperarBoleto(Guid id);
        List<BoletoView> ListarTodosBoletos();
    }
}
