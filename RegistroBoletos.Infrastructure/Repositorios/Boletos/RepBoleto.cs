using RegistroBoletos.Domain.Entidades.Boletos;
using RegistroBoletos.Infrastructure.Bases;
using RegistroBoletos.Infrastructure.Contexto;

namespace RegistroBoletos.Infrastructure.Repositorios.Boletos
{
    public class RepBoleto : RepBase<Boleto>, IRepBoleto
    {
        public RepBoleto(ContextoBanco contextoBanco) : base(contextoBanco)
        {
        }
    }
}
