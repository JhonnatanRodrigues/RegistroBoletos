using Microsoft.EntityFrameworkCore;
using RegistroBoletos.Domain.Entidades.Bancos;
using RegistroBoletos.Domain.Entidades.Boletos;
using RegistroBoletos.Infrastructure.Configs.Bancos;
using RegistroBoletos.Infrastructure.Configs.Boletos;

namespace RegistroBoletos.Infrastructure.Contexto
{
    public class ContextoBanco : DbContext
    {
        public ContextoBanco(DbContextOptions options) : base(options)
        {
        }

        protected ContextoBanco()
        {
        }

        public DbSet<Banco> Banco { get; set; }
        public DbSet<Boleto> Boleto { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BancoConfig())
                        .ApplyConfiguration(new BoletoConfig())
                ;

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();

            base.OnConfiguring(optionsBuilder);
        }
    }
}
