using RegistroBoletos.Domain.Bases;
using RegistroBoletos.Domain.Entidades.Bancos;

namespace RegistroBoletos.Domain.Entidades.Boletos
{
    public class Boleto : Identificador
    {
        public string NomePagador { get; set; }
        public string CpfCnpjPagador { get; set; }
        public string NomeBeneficiario { get; set; }
        public string CpfCnpjBeneficiario { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataVencto { get; set; }
        public string? Obs { get; set; }
        public Guid CodigoBanco { get; set; }

        public virtual Banco Banco { get; set; }

        public void AplicarJuros()
        {
            if (DataVencto.Date >= DateTime.Now.Date)
                return;

            var valorJuro = Math.Round((Banco.JuroPerc * Valor) / 100, 2);

            Valor = Valor + valorJuro;
        }
    }
}
