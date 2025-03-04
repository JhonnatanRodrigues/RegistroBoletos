using RegistroBoletos.Application.Bancos.Views;

namespace RegistroBoletos.Application.Boletos.Views
{
    public class BoletoView
    {
        public Guid Id { get; set; }
        public string NomePagador { get; set; }
        public string CpfCnpjPagador { get; set; }
        public string NomeBeneficiario { get; set; }
        public string CpfCnpjBeneficiario { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataVencto { get; set; }
        public string? Obs { get; set; }
        public Guid CodigoBanco { get; set; }

        public virtual BancoView Banco { get; set; }
    }
}
