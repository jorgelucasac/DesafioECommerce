using System;
using System.Collections.Generic;
using System.Linq;
using Desafio.ECommerce.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace Desafio.ECommerce.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Equipe> Equipes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            foreach (var relacionamento in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relacionamento.DeleteBehavior = DeleteBehavior.NoAction;
            }


            CargaInicial(modelBuilder);
            CriarSequenciPedidos(modelBuilder);
            ConfigurarCamposStrings(modelBuilder);

        }

        private void ConfigurarCamposStrings(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
            {
                if (property.GetColumnType() == "varchar(max)" || property.GetColumnType() == "nvarchar(max)")
                    property.SetColumnType("varchar(200)");
            }
        }

        private void CriarSequenciPedidos(ModelBuilder modelBuilder)
        {
            modelBuilder.HasSequence<int>("SequenciaPedidos", "sequencias")
                .StartsAt(100)
                .IncrementsBy(1)
                .HasMin(100);

        }

        private void CargaInicial(ModelBuilder modelBuilder)
        {

            var equipes = new List<Equipe>()
            {
                new Equipe { Nome = "Equipe 1", Descricao = "Equipe de pedidos 1", PlacaVeiculo = "KZC9055"},
                new Equipe { Nome = "Equipe 2", Descricao = "Equipe de pedidos 2", PlacaVeiculo = "LWI5199"},
            };
            modelBuilder.Entity<Equipe>().HasData(equipes);

            var pedidos = new List<Pedido>()
            {
               new Pedido(){EquipeId = equipes[0].Id,DataEntrega = DateTime.Now.AddDays(-15), NumeroIdentificacao = 98},
               new Pedido(){EquipeId = equipes[0].Id,DataEntrega = DateTime.Now.AddDays(-10), NumeroIdentificacao = 99},
               new Pedido(){EquipeId = equipes[1].Id, NumeroIdentificacao = 100},
            };

            modelBuilder.Entity<Pedido>().HasData(pedidos);


            var produtos = new List<Produto>();
            var enderecos = new List<Endereco>();
            int i = 0;
            foreach (var pedido in pedidos)
            {
                var max = i + 5;
                for (; i < max; i++)
                {
                    produtos.Add(new Produto()
                    {
                        PedidoId = pedido.Id,
                        Nome = $"Nome Produto {i}",
                        Descricao = $"Descricão Produto {i}",
                        Valor = new Random().Next(10, 100),
                    });
                }

                i = max;

                enderecos.Add(new Endereco()
                {
                    PedidoId = pedido.Id,
                    Bairro = $"Bairro {i}",
                    Cep = $"00000000",
                    Cidade = $"Cidade {i}",
                    Estado = "TO",
                    Numero = new Random().Next(20,2000).ToString(),
                    Logradouro = $"Rua {i}"
                });
            }

            modelBuilder.Entity<Produto>().HasData(produtos);
            modelBuilder.Entity<Endereco>().HasData(enderecos);

        }
    }
}