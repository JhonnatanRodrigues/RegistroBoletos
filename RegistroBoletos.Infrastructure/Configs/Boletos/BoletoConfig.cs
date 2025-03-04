using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RegistroBoletos.Domain.Entidades.Boletos;

namespace RegistroBoletos.Infrastructure.Configs.Boletos
{
    public class BoletoConfig : IEntityTypeConfiguration<Boleto>
    {
        public void Configure(EntityTypeBuilder<Boleto> builder)
        {
            builder.ToTable("tb_boleto");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
                .HasColumnName("idboleto")
                .HasDefaultValueSql("uuid_generate_v4()")
                .IsRequired();

            builder.Property(b => b.NomePagador)
                .HasColumnName("nomepagador")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(b => b.CpfCnpjPagador)
                .HasColumnName("cpfcnpjpagador")
                .HasMaxLength(14)
                .IsRequired();

            builder.Property(b => b.NomeBeneficiario)
                .HasColumnName("nomebeneficiario")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(b => b.CpfCnpjBeneficiario)
                .HasColumnName("cpfcnpjbeneficiario")
                .HasMaxLength(14)
                .IsRequired();

            builder.Property(b => b.Valor)
                .HasColumnName("valor")
                .HasPrecision(15, 2)
                .IsRequired();

            builder.Property(b => b.DataVencto)
                .HasColumnName("datavencimento")
                .IsRequired();

            builder.Property(b => b.Obs)
                .HasColumnName("obs")
                .HasMaxLength(100);

            builder.Property(b => b.CodigoBanco)
                .HasColumnName("idbanco")
                .IsRequired();

            builder.HasOne(b => b.Banco)
                .WithMany()
                .HasForeignKey(b => b.CodigoBanco)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
