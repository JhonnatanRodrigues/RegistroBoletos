namespace RegistroBoletos.Application.Bancos.Dtos
{
    public class InserirBancoDto
    {
        public string NomeBanco { get; set; }
        public string CodigoBanco { get; set; }
        public decimal JuroPerc { get; set; }
    }
}
