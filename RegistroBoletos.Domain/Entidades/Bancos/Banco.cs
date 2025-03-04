using RegistroBoletos.Domain.Bases;

namespace RegistroBoletos.Domain.Entidades.Bancos
{
    public class Banco : Identificador
    {
        public string NomeBanco { get; set; }
        public string CodigoBanco { get; set; }
        public decimal JuroPerc { get; set; }
    }
}
