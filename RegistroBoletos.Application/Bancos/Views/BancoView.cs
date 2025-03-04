namespace RegistroBoletos.Application.Bancos.Views
{
    public class BancoView
    {
        public Guid Id { get; set; }
        public string NomeBanco { get; set; }
        public string CodigoBanco { get; set; }
        public decimal JuroPerc { get; set; }
    }
}
