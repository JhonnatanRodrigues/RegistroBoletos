using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RegistroBoletos.Domain.Entidades.Bancos;

namespace RegistroBoletos.Infrastructure.Configs.Bancos
{
    public class BancoConfig : IEntityTypeConfiguration<Banco>
    {
        public void Configure(EntityTypeBuilder<Banco> builder)
        {
            builder.ToTable("tb_banco");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
                .HasColumnName("idbanco")
                .HasDefaultValueSql("uuid_generate_v4()")
                .IsRequired();

            builder.Property(b => b.NomeBanco)
                .HasColumnName("nomebanco")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(b => b.CodigoBanco)
                .HasColumnName("codigobanco")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(b => b.JuroPerc)
                .HasColumnName("jurosperc")
                .HasPrecision(15, 2)
                .IsRequired();
        }
    }
}
