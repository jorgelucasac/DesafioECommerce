using Desafio.ECommerce.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio.ECommerce.Data.Configurations
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasQueryFilter(a => a.Excluido == false);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(200)");


            builder.HasOne(a => a.Pedido)
                .WithMany(p => p.Produtos)
                .HasForeignKey(a => a.PedidoId)
                .IsRequired();

            builder.ToTable("Produto");
        }
    }
}