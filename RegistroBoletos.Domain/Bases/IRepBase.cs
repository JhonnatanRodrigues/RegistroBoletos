namespace RegistroBoletos.Domain.Bases
{
    public interface IRepBase<TEnt>
        where TEnt : Identificador
    {
        IQueryable<TEnt> Consulta { get; }
        void InsertPersist(TEnt entidade);
        void RemovePersist(TEnt entidade);
        void SaveChanges();
    }
}
