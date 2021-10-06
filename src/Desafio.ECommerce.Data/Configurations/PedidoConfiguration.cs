using Desafio.ECommerce.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio.ECommerce.Data.Configurations
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasQueryFilter(a => a.Excluido == false);

            builder.Property(p => p.NumeroIdentificacao)
                .HasDefaultValueSql("NEXT VALUE FOR sequencias.SequenciaPedidos")
                .IsRequired();


            builder.HasOne(a => a.Equipe)
                .WithMany(p => p.Pedidos);

            builder.HasOne(a => a.Endereco)
                .WithOne(b => b.Pedido);

            builder.HasMany(a => a.Produtos)
                .WithOne(b => b.Pedido);



            builder.ToTable("Pedido");
        }
    }
}