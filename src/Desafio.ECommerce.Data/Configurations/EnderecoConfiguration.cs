using Desafio.ECommerce.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio.ECommerce.Data.Configurations
{
    public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasQueryFilter(a => a.Excluido == false);

            builder.Property(p => p.Logradouro)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Numero)
                .IsRequired()
                .HasColumnType("varchar(10)");

            builder.Property(p => p.Cep)
                .IsRequired()
                .HasColumnType("varchar(8)");

            builder.Property(p => p.Complemento)
                .HasColumnType("varchar(250)");

            builder.Property(p => p.Bairro)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Cidade)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Estado)
                .IsRequired()
                .HasColumnType("varchar(2)");

            builder.HasOne(a => a.Pedido)
                .WithOne(p => p.Endereco)
                .HasForeignKey<Endereco>(a => a.PedidoId)
                .HasPrincipalKey<Pedido>(p => p.Id);

            builder.ToTable("Endereco");
        }
    }
}