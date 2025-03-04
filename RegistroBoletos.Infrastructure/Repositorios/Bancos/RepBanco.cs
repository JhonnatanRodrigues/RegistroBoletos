using RegistroBoletos.Domain.Entidades.Bancos;
using RegistroBoletos.Infrastructure.Bases;
using RegistroBoletos.Infrastructure.Contexto;

namespace RegistroBoletos.Infrastructure.Repositorios.Bancos
{
    public class RepBanco : RepBase<Banco>, IRepBanco
    {
        public RepBanco(ContextoBanco contextoBanco) : base(contextoBanco)
        {
        }
    }
}
