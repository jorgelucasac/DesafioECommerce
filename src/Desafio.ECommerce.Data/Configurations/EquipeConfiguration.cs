using Desafio.ECommerce.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio.ECommerce.Data.Configurations
{
    public class EquipeConfiguration : IEntityTypeConfiguration<Equipe>
    {
        public void Configure(EntityTypeBuilder<Equipe> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasQueryFilter(a => a.Excluido == false);


            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.PlacaVeiculo)
                .IsRequired()
                .HasColumnType("varchar(7)");


            builder.HasMany(a => a.Pedidos)
                .WithOne(p => p.Equipe);

            builder.ToTable("Equipe");
        }
    }
}