using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Desafio.ECommerce.Data.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "sequencias");

            migrationBuilder.CreateSequence<int>(
                name: "SequenciaPedidos",
                schema: "sequencias",
                startValue: 100L,
                minValue: 100L);

            migrationBuilder.CreateTable(
                name: "Equipe",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(200)", nullable: false),
                    PlacaVeiculo = table.Column<string>(type: "varchar(7)", nullable: false),
                    DataExclusao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    Excluido = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EquipeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumeroIdentificacao = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR sequencias.SequenciaPedidos"),
                    DataEntrega = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataExclusao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    Excluido = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedido_Equipe_EquipeId",
                        column: x => x.EquipeId,
                        principalTable: "Equipe",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PedidoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Logradouro = table.Column<string>(type: "varchar(200)", nullable: false),
                    Numero = table.Column<string>(type: "varchar(10)", nullable: false),
                    Complemento = table.Column<string>(type: "varchar(250)", nullable: true),
                    Cep = table.Column<string>(type: "varchar(8)", nullable: false),
                    Bairro = table.Column<string>(type: "varchar(100)", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(100)", nullable: false),
                    Estado = table.Column<string>(type: "varchar(2)", nullable: false),
                    DataExclusao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    Excluido = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Endereco_Pedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedido",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PedidoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(200)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataExclusao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    Excluido = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produto_Pedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedido",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Equipe",
                columns: new[] { "Id", "Ativo", "DataExclusao", "Descricao", "Excluido", "Nome", "PlacaVeiculo" },
                values: new object[] { new Guid("270c2575-d6f0-4c7f-909c-0ec04eff0e19"), true, null, "Equipe de pedidos 1", false, "Equipe 1", "KZC9055" });

            migrationBuilder.InsertData(
                table: "Equipe",
                columns: new[] { "Id", "Ativo", "DataExclusao", "Descricao", "Excluido", "Nome", "PlacaVeiculo" },
                values: new object[] { new Guid("ca555f2f-7aa5-43c2-a18d-bbe01fc7a0c8"), true, null, "Equipe de pedidos 2", false, "Equipe 2", "LWI5199" });

            migrationBuilder.InsertData(
                table: "Pedido",
                columns: new[] { "Id", "Ativo", "DataEntrega", "DataExclusao", "EquipeId", "Excluido", "NumeroIdentificacao" },
                values: new object[] { new Guid("2f55aecb-0d49-4a4c-aa60-109046cfe383"), true, new DateTime(2021, 9, 21, 18, 54, 53, 980, DateTimeKind.Local).AddTicks(8191), null, new Guid("270c2575-d6f0-4c7f-909c-0ec04eff0e19"), false, 98 });

            migrationBuilder.InsertData(
                table: "Pedido",
                columns: new[] { "Id", "Ativo", "DataEntrega", "DataExclusao", "EquipeId", "Excluido", "NumeroIdentificacao" },
                values: new object[] { new Guid("c21193c0-8b1b-4d0b-930c-f54d43becc0b"), true, new DateTime(2021, 9, 26, 18, 54, 53, 980, DateTimeKind.Local).AddTicks(9953), null, new Guid("270c2575-d6f0-4c7f-909c-0ec04eff0e19"), false, 99 });

            migrationBuilder.InsertData(
                table: "Pedido",
                columns: new[] { "Id", "Ativo", "DataEntrega", "DataExclusao", "EquipeId", "Excluido", "NumeroIdentificacao" },
                values: new object[] { new Guid("e02f6cf2-b407-447f-9fb7-1333d026eb44"), true, null, null, new Guid("ca555f2f-7aa5-43c2-a18d-bbe01fc7a0c8"), false, 100 });

            migrationBuilder.InsertData(
                table: "Endereco",
                columns: new[] { "Id", "Ativo", "Bairro", "Cep", "Cidade", "Complemento", "DataExclusao", "Estado", "Excluido", "Logradouro", "Numero", "PedidoId" },
                values: new object[,]
                {
                    { new Guid("4b158ff8-392c-49f6-878c-9b584f3e1453"), true, "Bairro 5", "00000000", "Cidade 5", null, null, "TO", false, "Rua 5", "1240", new Guid("2f55aecb-0d49-4a4c-aa60-109046cfe383") },
                    { new Guid("e66f392f-80f9-4f15-affd-38daa6bf8126"), true, "Bairro 15", "00000000", "Cidade 15", null, null, "TO", false, "Rua 15", "1790", new Guid("e02f6cf2-b407-447f-9fb7-1333d026eb44") },
                    { new Guid("23f8068d-2de2-41d1-9947-dd99566c4dba"), true, "Bairro 10", "00000000", "Cidade 10", null, null, "TO", false, "Rua 10", "1089", new Guid("c21193c0-8b1b-4d0b-930c-f54d43becc0b") }
                });

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "Ativo", "DataExclusao", "Descricao", "Excluido", "Nome", "PedidoId", "Valor" },
                values: new object[,]
                {
                    { new Guid("5596a2b5-6859-4b70-a27a-d361b63f8e2a"), true, null, "Descricão Produto 12", false, "Nome Produto 12", new Guid("e02f6cf2-b407-447f-9fb7-1333d026eb44"), 44m },
                    { new Guid("f31ebbca-bfca-4ff4-854a-ecab7e3ed5b9"), true, null, "Descricão Produto 11", false, "Nome Produto 11", new Guid("e02f6cf2-b407-447f-9fb7-1333d026eb44"), 26m },
                    { new Guid("e9cc2061-14bc-4aef-948c-1f44017fa4d6"), true, null, "Descricão Produto 10", false, "Nome Produto 10", new Guid("e02f6cf2-b407-447f-9fb7-1333d026eb44"), 22m },
                    { new Guid("b97fe92f-75a7-49fb-95ff-06efc5f16227"), true, null, "Descricão Produto 9", false, "Nome Produto 9", new Guid("c21193c0-8b1b-4d0b-930c-f54d43becc0b"), 48m },
                    { new Guid("905a384d-8bb2-427d-8ec2-5344cb928896"), true, null, "Descricão Produto 8", false, "Nome Produto 8", new Guid("c21193c0-8b1b-4d0b-930c-f54d43becc0b"), 27m },
                    { new Guid("043a66c1-1c35-4a76-bcdd-cecd2050d3fd"), true, null, "Descricão Produto 7", false, "Nome Produto 7", new Guid("c21193c0-8b1b-4d0b-930c-f54d43becc0b"), 81m },
                    { new Guid("87146e65-9cf5-45cd-beab-cf4fa3eab1aa"), true, null, "Descricão Produto 6", false, "Nome Produto 6", new Guid("c21193c0-8b1b-4d0b-930c-f54d43becc0b"), 84m },
                    { new Guid("f7f0dc10-ebc1-4809-9e3b-ac6dbd55c94f"), true, null, "Descricão Produto 5", false, "Nome Produto 5", new Guid("c21193c0-8b1b-4d0b-930c-f54d43becc0b"), 11m },
                    { new Guid("06c75078-8480-46c9-bd03-0011b2e10fe2"), true, null, "Descricão Produto 4", false, "Nome Produto 4", new Guid("2f55aecb-0d49-4a4c-aa60-109046cfe383"), 53m },
                    { new Guid("328e3296-d624-42ca-96f2-c1d453200720"), true, null, "Descricão Produto 3", false, "Nome Produto 3", new Guid("2f55aecb-0d49-4a4c-aa60-109046cfe383"), 86m },
                    { new Guid("c42c4d2a-971a-4608-9bbc-bc1f34208426"), true, null, "Descricão Produto 2", false, "Nome Produto 2", new Guid("2f55aecb-0d49-4a4c-aa60-109046cfe383"), 52m },
                    { new Guid("c2870a3c-ed2e-4b9a-889e-e634caf5b9be"), true, null, "Descricão Produto 1", false, "Nome Produto 1", new Guid("2f55aecb-0d49-4a4c-aa60-109046cfe383"), 56m },
                    { new Guid("7dbf5673-3064-4d48-949c-019edeef0d98"), true, null, "Descricão Produto 0", false, "Nome Produto 0", new Guid("2f55aecb-0d49-4a4c-aa60-109046cfe383"), 84m },
                    { new Guid("ac78565c-1bc5-4b7f-9fbe-89da14877159"), true, null, "Descricão Produto 13", false, "Nome Produto 13", new Guid("e02f6cf2-b407-447f-9fb7-1333d026eb44"), 27m },
                    { new Guid("48ef182d-b6ee-4159-9c19-6f51c5a39df2"), true, null, "Descricão Produto 14", false, "Nome Produto 14", new Guid("e02f6cf2-b407-447f-9fb7-1333d026eb44"), 61m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_PedidoId",
                table: "Endereco",
                column: "PedidoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_EquipeId",
                table: "Pedido",
                column: "EquipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_PedidoId",
                table: "Produto",
                column: "PedidoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "Equipe");

            migrationBuilder.DropSequence(
                name: "SequenciaPedidos",
                schema: "sequencias");
        }
    }
}
