using Microsoft.EntityFrameworkCore;
using RegistroBoletos.Domain.Bases;
using RegistroBoletos.Infrastructure.Contexto;

namespace RegistroBoletos.Infrastructure.Bases
{
    public class RepBase<TEnt>
        where TEnt : Identificador
    {
        private readonly ContextoBanco _Db;
        private readonly DbSet<TEnt> _DbSet;
        public IQueryable<TEnt> Consulta => _DbSet;

        public RepBase(ContextoBanco contextoBanco)
        {
            _Db = contextoBanco;
            _DbSet = _Db.Set<TEnt>();
        }

        public virtual void InsertPersist(TEnt entidade)
        {
            try
            {
                _DbSet.AddAsync(entidade).GetAwaiter();
                _Db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public virtual void RemovePersist(TEnt entidade)
        {
            try
            {
                _DbSet.Remove(entidade);
                _Db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void SaveChanges()
        {
            _Db.SaveChanges();
        }
    }
}
