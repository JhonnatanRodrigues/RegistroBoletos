using RegistroBoletos.Application.Bancos.Dtos;
using RegistroBoletos.Application.Bancos.Views;

namespace RegistroBoletos.Application.Bancos
{
    public interface IAplicBanco
    {
        void InserirNovoBanco(InserirBancoDto dto);
        List<BancoView> ListarTodos();
        BancoView RecuperarBanco(string codigoBanco);
    }
}
