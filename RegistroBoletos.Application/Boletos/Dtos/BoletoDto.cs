namespace RegistroBoletos.Application.Boletos.Dtos
{
    public class BoletoDto
    {
        public string NomePagador { get; set; }
        public string CpfCnpjPagador { get; set; }
        public string NomeBeneficiario { get; set; }
        public string CpfCnpjBeneficiario { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataVencto { get; set; }
        public string? Obs { get; set; }
        public Guid CodigoBanco { get; set; }
    }
}
