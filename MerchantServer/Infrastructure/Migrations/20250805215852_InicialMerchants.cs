using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InicialMerchants : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cozinhas",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cozinhas", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Comercio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AspNetUsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeFantasia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TelefoneEntrega = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CozinhaCode = table.Column<string>(type: "nvarchar(3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comercio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comercio_Cozinhas_CozinhaCode",
                        column: x => x.CozinhaCode,
                        principalTable: "Cozinhas",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    ComercioId = table.Column<int>(type: "int", nullable: false),
                    CEP = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Logradouro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Complemento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pais = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Referencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.ComercioId);
                    table.ForeignKey(
                        name: "FK_Enderecos_Comercio_ComercioId",
                        column: x => x.ComercioId,
                        principalTable: "Comercio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cozinhas",
                columns: new[] { "Code", "Name" },
                values: new object[,]
                {
                    { "AC1", "Açaí" },
                    { "AF1", "Africana" },
                    { "ALE", "Alemã" },
                    { "AR1", "Argentina" },
                    { "ARA", "Árabe" },
                    { "ASI", "Asiática" },
                    { "BA1", "Baiana" },
                    { "BRA", "Brasileira" },
                    { "BUR", "Hambúrguer" },
                    { "CA1", "Cafeteria" },
                    { "CAR", "Carnes" },
                    { "CF1", "Congelados Fit" },
                    { "CHI", "Chinesa" },
                    { "CN1", "Congelados" },
                    { "CNT", "Contemporânea" },
                    { "CO1", "Colombiana" },
                    { "CP1", "Crepe" },
                    { "CR1", "Coreana" },
                    { "CRP", "Cozinha Rápida" },
                    { "CS1", "Casa de Sucos" },
                    { "DCE", "Doces & Bolos" },
                    { "ES1", "Espanhola" },
                    { "FR1", "Frangos" },
                    { "FRA", "Francesa" },
                    { "FRU", "Frutos Do Mar" },
                    { "GA1", "Gaúcha" },
                    { "GRC", "Grega" },
                    { "IND", "Indiana" },
                    { "ITA", "Italiana" },
                    { "JAP", "Japonesa" },
                    { "LCH", "Lanches" },
                    { "MA1", "Marmita" },
                    { "MAR", "Marroquina" },
                    { "MED", "Mediterrânea" },
                    { "MEX", "Mexicana" },
                    { "MI1", "Mineira" },
                    { "NO1", "Nordestina" },
                    { "PA1", "Padaria" },
                    { "PAS", "Pastel" },
                    { "PER", "Peruana" },
                    { "PIZ", "Pizza" },
                    { "POR", "Portuguesa" },
                    { "PQC", "Panqueca" },
                    { "PR1", "Paranaense" },
                    { "PRE", "Presentes" },
                    { "PX1", "Peixes" },
                    { "SAG", "Salgados" },
                    { "SAU", "Saudável" },
                    { "SOR", "Sorvetes" },
                    { "SP1", "Sopas & Caldos" },
                    { "TA1", "Tapioca" },
                    { "THA", "Tailandesa" },
                    { "TN1", "Típica do Norte" },
                    { "VAR", "Variada" },
                    { "VE1", "Vegana" },
                    { "VEG", "Vegetariana" },
                    { "XI1", "Xis" },
                    { "YA1", "Yakisoba" }
                });

            migrationBuilder.InsertData(
                table: "Comercio",
                columns: new[] { "Id", "AspNetUsersId", "CozinhaCode", "DataCriacao", "Descricao", "Nome", "NomeFantasia", "Status", "TelefoneEntrega", "Tipo", "UUID" },
                values: new object[,]
                {
                    { 1, new Guid("97aa75c4-1a41-4a20-a1d0-4fe1f1f5129b"), "AC1", new DateTime(2025, 8, 5, 21, 58, 51, 953, DateTimeKind.Utc).AddTicks(1733), "Descricao do Comercio A", "Comercio A", "Comercio A Fantasia", 1, "1234567890", 1, new Guid("13e2f21a-4283-4ff8-bb7a-096e7b89e0f0") },
                    { 2, new Guid("97aa75c4-1a41-4a20-a1d0-4fe1f1f5129b"), "AF1", new DateTime(2025, 8, 5, 21, 58, 51, 953, DateTimeKind.Utc).AddTicks(2375), "Descricao do Comercio B", "Comercio B", "Comercio B Fantasia", 1, "0987654321", 1, new Guid("283264d6-0e5e-48fe-9d6e-b1599aa0892c") },
                    { 3, new Guid("97aa75c4-1a41-4a20-a1d0-4fe1f1f5129b"), "ALE", new DateTime(2025, 8, 5, 21, 58, 51, 953, DateTimeKind.Utc).AddTicks(2381), "Descricao do Comercio C", "Comercio A", "Comercio A Fantasia", 1, "1122334455", 1, new Guid("7cd0d373-c57d-4c70-aa8c-22791983fe1c") },
                    { 4, new Guid("6377641f-33f7-4997-944c-997cc9d63d88"), "LCH", new DateTime(2025, 8, 5, 21, 58, 51, 953, DateTimeKind.Utc).AddTicks(2383), "Descricao do Comercio D", "Comercio D", "Comercio D Fantasia", 1, "2233445566", 1, new Guid("b1c8f3d2-4e5f-4b6a-9c7e-0d8f9a1b2c3d") }
                });

            migrationBuilder.InsertData(
                table: "Enderecos",
                columns: new[] { "ComercioId", "Bairro", "CEP", "Cidade", "Complemento", "Estado", "Latitude", "Logradouro", "Longitude", "Numero", "Pais", "Referencia" },
                values: new object[,]
                {
                    { 1, "Bairro A", "12345678", "Cidade A", null, "Estado A", -9.8275970000000008, "Rua A", -67.951076999999998, "123", "BR", null },
                    { 2, "Bairro B", "23456789", "Cidade B", null, "Estado B", -9.8275970000000008, "Rua B", -67.951076999999998, "456", "BR", null },
                    { 3, "Bairro C", "34567890", "Cidade C", null, "Estado C", -9.8275970000000008, "Rua C", -67.951076999999998, "789", "BR", null },
                    { 4, "Bairro D", "45678901", "Cidade D", null, "Estado D", -9.8275970000000008, "Rua D", -67.951076999999998, "1011", "BR", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comercio_CozinhaCode",
                table: "Comercio",
                column: "CozinhaCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comercio_UUID",
                table: "Comercio",
                column: "UUID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "Comercio");

            migrationBuilder.DropTable(
                name: "Cozinhas");
        }
    }
}
