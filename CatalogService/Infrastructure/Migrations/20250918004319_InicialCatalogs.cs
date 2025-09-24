using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InicialCatalogs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Catalogos",
                columns: table => new
                {
                    CatalogoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disponivel = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    CatalogoGrupo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComercioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalogos", x => x.CatalogoId);
                });

            migrationBuilder.CreateTable(
                name: "GrupoOpcoes",
                columns: table => new
                {
                    OpcaoGrupoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Min = table.Column<int>(type: "int", nullable: false),
                    Max = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Index = table.Column<int>(type: "int", nullable: false),
                    ResourceGroupoType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoOpcoes", x => x.OpcaoGrupoId);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    CategoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Index = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CatalogoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.CategoriaId);
                    table.ForeignKey(
                        name: "FK_Categorias_Catalogos_CatalogoId",
                        column: x => x.CatalogoId,
                        principalTable: "Catalogos",
                        principalColumn: "CatalogoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contextos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CatalogoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContextoType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contextos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contextos_Catalogos_CatalogoId",
                        column: x => x.CatalogoId,
                        principalTable: "Catalogos",
                        principalColumn: "CatalogoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    ProdutoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IsIndustrializado = table.Column<bool>(type: "bit", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Unidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Peso = table.Column<int>(type: "int", nullable: false),
                    Ean = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CatalogoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Serving = table.Column<int>(type: "int", nullable: false),
                    RestriocaoAlimentar = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.ProdutoId);
                    table.ForeignKey(
                        name: "FK_Produtos_Catalogos_CatalogoId",
                        column: x => x.CatalogoId,
                        principalTable: "Catalogos",
                        principalColumn: "CatalogoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Itens",
                columns: table => new
                {
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Index = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProdutoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CategoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Itens", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_Itens_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Itens_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "ProdutoId");
                });

            migrationBuilder.CreateTable(
                name: "Opcoes",
                columns: table => new
                {
                    OpcaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ProdutoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OpcoesGrupoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fracoes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opcoes", x => x.OpcaoId);
                    table.ForeignKey(
                        name: "FK_Opcoes_GrupoOpcoes_OpcoesGrupoId",
                        column: x => x.OpcoesGrupoId,
                        principalTable: "GrupoOpcoes",
                        principalColumn: "OpcaoGrupoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Opcoes_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "ProdutoId");
                });

            migrationBuilder.CreateTable(
                name: "ProdutoOpcoesGrupos",
                columns: table => new
                {
                    ProdutoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GrupoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoOpcoesGrupos", x => new { x.GrupoId, x.ProdutoId });
                    table.ForeignKey(
                        name: "FK_ProdutoOpcoesGrupos_GrupoOpcoes_GrupoId",
                        column: x => x.GrupoId,
                        principalTable: "GrupoOpcoes",
                        principalColumn: "OpcaoGrupoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdutoOpcoesGrupos_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "ProdutoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContextoItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CatalogoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ContextoType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContextoItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContextoItems_Catalogos_CatalogoId",
                        column: x => x.CatalogoId,
                        principalTable: "Catalogos",
                        principalColumn: "CatalogoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContextoItems_Itens_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Itens",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomizacaoModificacoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    customizationOptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    parentCustomizationOptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomizacaoModificacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomizacaoModificacoes_Itens_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Itens",
                        principalColumn: "ItemId");
                    table.ForeignKey(
                        name: "FK_CustomizacaoModificacoes_Opcoes_customizationOptionId",
                        column: x => x.customizationOptionId,
                        principalTable: "Opcoes",
                        principalColumn: "OpcaoId");
                    table.ForeignKey(
                        name: "FK_CustomizacaoModificacoes_Opcoes_parentCustomizationOptionId",
                        column: x => x.parentCustomizationOptionId,
                        principalTable: "Opcoes",
                        principalColumn: "OpcaoId");
                });

            migrationBuilder.InsertData(
                table: "Catalogos",
                columns: new[] { "CatalogoId", "CatalogoGrupo", "ComercioId", "DataCriacao", "Descricao", "Disponivel", "Nome", "Status", "Tipo" },
                values: new object[] { new Guid("50f8a1fc-1672-43e0-8746-aadcb005a3da"), new Guid("ffca0022-eb43-4205-9a1b-73a72f8e3f95"), new Guid("b1c8f3d2-4e5f-4b6a-9c7e-0d8f9a1b2c3d"), new DateTime(2025, 9, 17, 21, 43, 19, 56, DateTimeKind.Local).AddTicks(6689), "Cardápio Principal do comércio", true, "Cardápio Principal", 1, 0 });

            migrationBuilder.InsertData(
                table: "GrupoOpcoes",
                columns: new[] { "OpcaoGrupoId", "DataCriacao", "Index", "Max", "Min", "Nome", "ResourceGroupoType", "Status" },
                values: new object[,]
                {
                    { new Guid("15af8bd9-6d54-43f2-8c74-43d5d4da32d8"), new DateTime(2025, 9, 17, 21, 43, 19, 61, DateTimeKind.Local).AddTicks(1248), 0, 1, 0, "Tamanhos", 1, 1 },
                    { new Guid("1e5e5eb5-84c7-4eca-b0c1-921860434f70"), new DateTime(2025, 9, 17, 21, 43, 19, 61, DateTimeKind.Local).AddTicks(957), 0, 1, 0, "Acompanhamentos", 6, 1 },
                    { new Guid("26b1a876-7ee4-4f15-9bb1-d33c840c5049"), new DateTime(2025, 9, 17, 21, 43, 19, 61, DateTimeKind.Local).AddTicks(1250), 0, 1, 0, "Massas", 2, 1 },
                    { new Guid("668a93a9-704e-4036-a515-11e4ddbe4129"), new DateTime(2025, 9, 17, 21, 43, 19, 61, DateTimeKind.Local).AddTicks(1252), 0, 5, 0, "Bordas", 3, 1 },
                    { new Guid("b5bcb329-4f23-4752-a738-4bfe7ed4bb46"), new DateTime(2025, 9, 17, 21, 43, 19, 61, DateTimeKind.Local).AddTicks(1246), 0, 1, 0, "Turbine seu Lanche", 6, 1 },
                    { new Guid("d1eed8e6-c1f0-4f09-a235-2d459bb33cbb"), new DateTime(2025, 9, 17, 21, 43, 19, 61, DateTimeKind.Local).AddTicks(1256), 0, 1, 0, "Sabores", 4, 1 }
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "CategoriaId", "CatalogoId", "DataCriacao", "Descricao", "Index", "Nome", "Status", "Tipo" },
                values: new object[,]
                {
                    { new Guid("c1a5f8e2-3b6d-4f8e-9c7e-0d8f9a1b2c3d"), new Guid("50f8a1fc-1672-43e0-8746-aadcb005a3da"), new DateTime(2025, 9, 17, 21, 43, 19, 59, DateTimeKind.Local).AddTicks(569), "Categoria de Pizzas Tradicionais", 0, "Pizzas Tradicionais", 1, 1 },
                    { new Guid("d2b6f9e3-4c7e-5f9f-0d8f-1a2b3c4d5e6f"), new Guid("50f8a1fc-1672-43e0-8746-aadcb005a3da"), new DateTime(2025, 9, 17, 21, 43, 19, 59, DateTimeKind.Local).AddTicks(1204), "Categoria de Massas para Pizzas", 1, "Lanches Rápidos", 1, 0 }
                });

            migrationBuilder.InsertData(
                table: "Contextos",
                columns: new[] { "Id", "CatalogoId", "ContextoType" },
                values: new object[,]
                {
                    { new Guid("0c5dfc17-fb38-44d5-8840-328e6b0c4293"), new Guid("50f8a1fc-1672-43e0-8746-aadcb005a3da"), 0 },
                    { new Guid("53e952f7-6a1f-427b-8d82-156d48ec960e"), new Guid("50f8a1fc-1672-43e0-8746-aadcb005a3da"), 1 }
                });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "ProdutoId", "CatalogoId", "DataCriacao", "Descricao", "Ean", "IsIndustrializado", "Nome", "Peso", "RestriocaoAlimentar", "Serving", "Status", "Unidade" },
                values: new object[,]
                {
                    { new Guid("27fa98cd-e119-432d-9b0a-8f99a65be1b7"), new Guid("50f8a1fc-1672-43e0-8746-aadcb005a3da"), new DateTime(2025, 9, 17, 21, 43, 19, 60, DateTimeKind.Local).AddTicks(6787), null, null, false, "Tamanho Médio", 5, null, 0, 1, "g" },
                    { new Guid("39b52e42-c21e-408b-9fa2-d2cccef926d1"), new Guid("50f8a1fc-1672-43e0-8746-aadcb005a3da"), new DateTime(2025, 9, 17, 21, 43, 19, 60, DateTimeKind.Local).AddTicks(6770), "Milho, Tomate, Alface, Queijo, Carne e Maionese", null, false, "X- Gaúcho", 0, null, 1, 0, null },
                    { new Guid("4f3560c5-a6f3-40c9-885e-2e7e7ee4e9d0"), new Guid("50f8a1fc-1672-43e0-8746-aadcb005a3da"), new DateTime(2025, 9, 17, 21, 43, 19, 60, DateTimeKind.Local).AddTicks(6767), "Milho, Tomate, Alface, Queijo, Hamburguer, Frango e Maionese", null, false, "X-Frango", 0, null, 1, 1, null },
                    { new Guid("51b644cc-a90c-4456-992f-f86631176796"), new Guid("50f8a1fc-1672-43e0-8746-aadcb005a3da"), new DateTime(2025, 9, 17, 21, 43, 19, 60, DateTimeKind.Local).AddTicks(6784), null, null, false, "Pizzas Tradicionais", 10, null, 0, 1, "kg" },
                    { new Guid("62133b9f-5542-401d-8743-49ec7da8c847"), new Guid("50f8a1fc-1672-43e0-8746-aadcb005a3da"), new DateTime(2025, 9, 17, 21, 43, 19, 60, DateTimeKind.Local).AddTicks(5837), "Hamburguer, Queijo, Presunto e Maionese", "7891234567890", false, "X-Burger", 5, null, 1, 1, "g" },
                    { new Guid("8d86a76d-9585-440e-9482-457392deff8d"), new Guid("50f8a1fc-1672-43e0-8746-aadcb005a3da"), new DateTime(2025, 9, 17, 21, 43, 19, 60, DateTimeKind.Local).AddTicks(6773), null, null, false, "Fritas P", 200, null, 1, 1, "g" },
                    { new Guid("932e18a2-396d-40d2-8de4-da0cf8f95faf"), new Guid("50f8a1fc-1672-43e0-8746-aadcb005a3da"), new DateTime(2025, 9, 17, 21, 43, 19, 60, DateTimeKind.Local).AddTicks(6789), null, null, false, "Tamanho Grande", 5, null, 0, 1, "g" },
                    { new Guid("9f72cd07-4463-4bfc-8fc1-97129c775e21"), new Guid("50f8a1fc-1672-43e0-8746-aadcb005a3da"), new DateTime(2025, 9, 17, 21, 43, 19, 60, DateTimeKind.Local).AddTicks(6792), null, null, false, "Massa Tradicional", 5, null, 0, 1, "g" },
                    { new Guid("a36cbbdf-7c06-4bde-8cf3-e99efc7603fa"), new Guid("50f8a1fc-1672-43e0-8746-aadcb005a3da"), new DateTime(2025, 9, 17, 21, 43, 19, 60, DateTimeKind.Local).AddTicks(6780), null, null, false, "Bife", 0, null, 0, 0, null },
                    { new Guid("b4a093cc-7e4a-49d2-909a-fed1cc58c572"), new Guid("50f8a1fc-1672-43e0-8746-aadcb005a3da"), new DateTime(2025, 9, 17, 21, 43, 19, 60, DateTimeKind.Local).AddTicks(6804), null, null, false, "Frango com Catupiry", 5, null, 0, 1, "g" },
                    { new Guid("c8eff6c6-f3c5-48ec-9a5b-aa5b3eeec582"), new Guid("50f8a1fc-1672-43e0-8746-aadcb005a3da"), new DateTime(2025, 9, 17, 21, 43, 19, 60, DateTimeKind.Local).AddTicks(6795), null, null, false, "Massa fina", 5, null, 0, 1, "g" },
                    { new Guid("ccea5142-1b90-40d9-b35d-72685950260b"), new Guid("50f8a1fc-1672-43e0-8746-aadcb005a3da"), new DateTime(2025, 9, 17, 21, 43, 19, 60, DateTimeKind.Local).AddTicks(6762), "", null, false, "X-Salada", 0, null, 1, 1, null },
                    { new Guid("d6ae0c15-4db9-454e-868b-a9ec7719da5e"), new Guid("50f8a1fc-1672-43e0-8746-aadcb005a3da"), new DateTime(2025, 9, 17, 21, 43, 19, 60, DateTimeKind.Local).AddTicks(6802), null, null, false, "Calabresa", 5, null, 0, 1, "g" },
                    { new Guid("e4ac0247-33ed-476a-ae69-363f27fe0df7"), new Guid("50f8a1fc-1672-43e0-8746-aadcb005a3da"), new DateTime(2025, 9, 17, 21, 43, 19, 60, DateTimeKind.Local).AddTicks(6797), null, null, false, "Borda Tradicional", 5, null, 0, 1, "g" },
                    { new Guid("eb021b00-0fef-434b-9da5-77e4dbca047e"), new Guid("50f8a1fc-1672-43e0-8746-aadcb005a3da"), new DateTime(2025, 9, 17, 21, 43, 19, 60, DateTimeKind.Local).AddTicks(6800), null, null, false, "Borda Recheada", 5, null, 0, 1, "g" }
                });

            migrationBuilder.InsertData(
                table: "Itens",
                columns: new[] { "ItemId", "CategoriaId", "DataCriacao", "Index", "ProdutoId", "Tipo" },
                values: new object[,]
                {
                    { new Guid("0c8eb292-8786-4707-8025-95a3d834da68"), new Guid("d2b6f9e3-4c7e-5f9f-0d8f-1a2b3c4d5e6f"), new DateTime(2025, 9, 17, 21, 43, 19, 59, DateTimeKind.Local).AddTicks(7655), 0, new Guid("ccea5142-1b90-40d9-b35d-72685950260b"), 0 },
                    { new Guid("289a4fbe-18b9-4506-b21f-2957f5919fbc"), new Guid("c1a5f8e2-3b6d-4f8e-9c7e-0d8f9a1b2c3d"), new DateTime(2025, 9, 17, 21, 43, 19, 59, DateTimeKind.Local).AddTicks(6976), 0, new Guid("51b644cc-a90c-4456-992f-f86631176796"), 1 },
                    { new Guid("56b5c746-57d8-4964-bc3b-46eb18658208"), new Guid("d2b6f9e3-4c7e-5f9f-0d8f-1a2b3c4d5e6f"), new DateTime(2025, 9, 17, 21, 43, 19, 59, DateTimeKind.Local).AddTicks(7652), 0, new Guid("62133b9f-5542-401d-8743-49ec7da8c847"), 0 },
                    { new Guid("b8a99cea-8dbb-426a-bfe0-058fc44333f6"), new Guid("d2b6f9e3-4c7e-5f9f-0d8f-1a2b3c4d5e6f"), new DateTime(2025, 9, 17, 21, 43, 19, 59, DateTimeKind.Local).AddTicks(7659), 0, new Guid("4f3560c5-a6f3-40c9-885e-2e7e7ee4e9d0"), 0 },
                    { new Guid("fa71f64b-55d1-4f50-91a7-5ce4d5b72ee5"), new Guid("d2b6f9e3-4c7e-5f9f-0d8f-1a2b3c4d5e6f"), new DateTime(2025, 9, 17, 21, 43, 19, 59, DateTimeKind.Local).AddTicks(7661), 0, new Guid("39b52e42-c21e-408b-9fa2-d2cccef926d1"), 0 }
                });

            migrationBuilder.InsertData(
                table: "Opcoes",
                columns: new[] { "OpcaoId", "Fracoes", "OpcoesGrupoId", "ProdutoId", "Status" },
                values: new object[,]
                {
                    { new Guid("0d58a046-1871-433d-bd8d-2b33abfbfa70"), null, new Guid("d1eed8e6-c1f0-4f09-a235-2d459bb33cbb"), new Guid("d6ae0c15-4db9-454e-868b-a9ec7719da5e"), 1 },
                    { new Guid("2587c76e-3aa3-45e6-95d9-35c21ac19f9d"), "1,2", new Guid("15af8bd9-6d54-43f2-8c74-43d5d4da32d8"), new Guid("932e18a2-396d-40d2-8de4-da0cf8f95faf"), 1 },
                    { new Guid("7fb0eac3-43e5-41c6-860e-a38793db4988"), null, new Guid("26b1a876-7ee4-4f15-9bb1-d33c840c5049"), new Guid("9f72cd07-4463-4bfc-8fc1-97129c775e21"), 1 },
                    { new Guid("945ef3bc-7741-4bec-a0ce-4660c09a564f"), "1", new Guid("15af8bd9-6d54-43f2-8c74-43d5d4da32d8"), new Guid("27fa98cd-e119-432d-9b0a-8f99a65be1b7"), 1 },
                    { new Guid("a4eb62d0-ca33-459e-82b1-4de25997ba9e"), null, new Guid("d1eed8e6-c1f0-4f09-a235-2d459bb33cbb"), new Guid("b4a093cc-7e4a-49d2-909a-fed1cc58c572"), 1 },
                    { new Guid("aecc1532-da5e-444f-8989-519012edf46e"), null, new Guid("b5bcb329-4f23-4752-a738-4bfe7ed4bb46"), new Guid("8d86a76d-9585-440e-9482-457392deff8d"), 1 },
                    { new Guid("cc71b438-523f-49ac-918a-82df71244f9b"), null, new Guid("668a93a9-704e-4036-a515-11e4ddbe4129"), new Guid("e4ac0247-33ed-476a-ae69-363f27fe0df7"), 1 },
                    { new Guid("d0d0df88-b276-4a21-ab14-063e8f0c3c5d"), null, new Guid("26b1a876-7ee4-4f15-9bb1-d33c840c5049"), new Guid("c8eff6c6-f3c5-48ec-9a5b-aa5b3eeec582"), 1 },
                    { new Guid("d76aca65-4303-4a4d-a046-4c93151a4d67"), null, new Guid("b5bcb329-4f23-4752-a738-4bfe7ed4bb46"), new Guid("a36cbbdf-7c06-4bde-8cf3-e99efc7603fa"), 1 },
                    { new Guid("df8728b2-7773-486b-aa93-47627bdd0c54"), null, new Guid("668a93a9-704e-4036-a515-11e4ddbe4129"), new Guid("eb021b00-0fef-434b-9da5-77e4dbca047e"), 1 }
                });

            migrationBuilder.InsertData(
                table: "ProdutoOpcoesGrupos",
                columns: new[] { "GrupoId", "ProdutoId" },
                values: new object[,]
                {
                    { new Guid("15af8bd9-6d54-43f2-8c74-43d5d4da32d8"), new Guid("51b644cc-a90c-4456-992f-f86631176796") },
                    { new Guid("1e5e5eb5-84c7-4eca-b0c1-921860434f70"), new Guid("62133b9f-5542-401d-8743-49ec7da8c847") },
                    { new Guid("26b1a876-7ee4-4f15-9bb1-d33c840c5049"), new Guid("51b644cc-a90c-4456-992f-f86631176796") },
                    { new Guid("668a93a9-704e-4036-a515-11e4ddbe4129"), new Guid("51b644cc-a90c-4456-992f-f86631176796") },
                    { new Guid("b5bcb329-4f23-4752-a738-4bfe7ed4bb46"), new Guid("ccea5142-1b90-40d9-b35d-72685950260b") },
                    { new Guid("d1eed8e6-c1f0-4f09-a235-2d459bb33cbb"), new Guid("51b644cc-a90c-4456-992f-f86631176796") }
                });

            migrationBuilder.InsertData(
                table: "ContextoItems",
                columns: new[] { "Id", "CatalogoId", "ContextoType", "ItemId", "Status" },
                values: new object[,]
                {
                    { new Guid("068b5586-48b4-4f17-9ee2-6195b92615c3"), new Guid("50f8a1fc-1672-43e0-8746-aadcb005a3da"), 0, new Guid("fa71f64b-55d1-4f50-91a7-5ce4d5b72ee5"), 1 },
                    { new Guid("1f6eb8b1-8bdf-4df0-9115-a6dc7fb24e7b"), new Guid("50f8a1fc-1672-43e0-8746-aadcb005a3da"), 1, new Guid("0c8eb292-8786-4707-8025-95a3d834da68"), 0 },
                    { new Guid("9014b9ab-a3d0-49a6-80d6-5a596f2203d2"), new Guid("50f8a1fc-1672-43e0-8746-aadcb005a3da"), 0, new Guid("b8a99cea-8dbb-426a-bfe0-058fc44333f6"), 1 },
                    { new Guid("93fbbdbb-8bf3-4450-9752-5bc629d7c581"), new Guid("50f8a1fc-1672-43e0-8746-aadcb005a3da"), 1, new Guid("289a4fbe-18b9-4506-b21f-2957f5919fbc"), 0 },
                    { new Guid("95fcc2a8-02ac-4a85-a7fc-67d3ba970f67"), new Guid("50f8a1fc-1672-43e0-8746-aadcb005a3da"), 1, new Guid("b8a99cea-8dbb-426a-bfe0-058fc44333f6"), 0 },
                    { new Guid("a143c9ed-dffb-4d66-87f3-3a17120afb33"), new Guid("50f8a1fc-1672-43e0-8746-aadcb005a3da"), 0, new Guid("289a4fbe-18b9-4506-b21f-2957f5919fbc"), 1 },
                    { new Guid("b1ca6706-97ba-47e7-907e-68486ff81b91"), new Guid("50f8a1fc-1672-43e0-8746-aadcb005a3da"), 1, new Guid("56b5c746-57d8-4964-bc3b-46eb18658208"), 0 },
                    { new Guid("df747025-8547-4eef-8c7b-36d8b4df3f27"), new Guid("50f8a1fc-1672-43e0-8746-aadcb005a3da"), 1, new Guid("fa71f64b-55d1-4f50-91a7-5ce4d5b72ee5"), 1 },
                    { new Guid("e756e2f8-cb5a-4ddb-92d5-ab318a34611e"), new Guid("50f8a1fc-1672-43e0-8746-aadcb005a3da"), 0, new Guid("0c8eb292-8786-4707-8025-95a3d834da68"), 1 },
                    { new Guid("eba99296-dda0-45bb-be6b-7475dae58432"), new Guid("50f8a1fc-1672-43e0-8746-aadcb005a3da"), 0, new Guid("56b5c746-57d8-4964-bc3b-46eb18658208"), 0 }
                });

            migrationBuilder.InsertData(
                table: "CustomizacaoModificacoes",
                columns: new[] { "Id", "ItemId", "Status", "customizationOptionId", "parentCustomizationOptionId" },
                values: new object[,]
                {
                    { new Guid("147635af-235d-4e7c-a2c5-899fc6fe5ca8"), new Guid("289a4fbe-18b9-4506-b21f-2957f5919fbc"), 1, new Guid("a4eb62d0-ca33-459e-82b1-4de25997ba9e"), new Guid("2587c76e-3aa3-45e6-95d9-35c21ac19f9d") },
                    { new Guid("40da28b6-2c2e-4392-ae97-f1101e1893f6"), new Guid("289a4fbe-18b9-4506-b21f-2957f5919fbc"), 1, new Guid("0d58a046-1871-433d-bd8d-2b33abfbfa70"), new Guid("2587c76e-3aa3-45e6-95d9-35c21ac19f9d") },
                    { new Guid("88cf4471-0899-47e3-89cd-6003ef006cb0"), new Guid("289a4fbe-18b9-4506-b21f-2957f5919fbc"), 1, new Guid("a4eb62d0-ca33-459e-82b1-4de25997ba9e"), new Guid("945ef3bc-7741-4bec-a0ce-4660c09a564f") },
                    { new Guid("fe66f09c-aee6-4496-9771-6f6e3af407c8"), new Guid("289a4fbe-18b9-4506-b21f-2957f5919fbc"), 1, new Guid("0d58a046-1871-433d-bd8d-2b33abfbfa70"), new Guid("945ef3bc-7741-4bec-a0ce-4660c09a564f") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Catalogos_CatalogoId",
                table: "Catalogos",
                column: "CatalogoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_CatalogoId",
                table: "Categorias",
                column: "CatalogoId");

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_CategoriaId",
                table: "Categorias",
                column: "CategoriaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContextoItems_CatalogoId",
                table: "ContextoItems",
                column: "CatalogoId");

            migrationBuilder.CreateIndex(
                name: "IX_ContextoItems_ItemId",
                table: "ContextoItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Contextos_CatalogoId",
                table: "Contextos",
                column: "CatalogoId");

            migrationBuilder.CreateIndex(
                name: "IX_Contextos_Id",
                table: "Contextos",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomizacaoModificacoes_customizationOptionId",
                table: "CustomizacaoModificacoes",
                column: "customizationOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomizacaoModificacoes_ItemId",
                table: "CustomizacaoModificacoes",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomizacaoModificacoes_parentCustomizationOptionId",
                table: "CustomizacaoModificacoes",
                column: "parentCustomizationOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_GrupoOpcoes_OpcaoGrupoId",
                table: "GrupoOpcoes",
                column: "OpcaoGrupoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Itens_CategoriaId",
                table: "Itens",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Itens_ItemId",
                table: "Itens",
                column: "ItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Itens_ProdutoId",
                table: "Itens",
                column: "ProdutoId",
                unique: true,
                filter: "[ProdutoId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Opcoes_OpcaoId",
                table: "Opcoes",
                column: "OpcaoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Opcoes_OpcoesGrupoId",
                table: "Opcoes",
                column: "OpcoesGrupoId");

            migrationBuilder.CreateIndex(
                name: "IX_Opcoes_ProdutoId",
                table: "Opcoes",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoOpcoesGrupos_ProdutoId",
                table: "ProdutoOpcoesGrupos",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CatalogoId",
                table: "Produtos",
                column: "CatalogoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_ProdutoId",
                table: "Produtos",
                column: "ProdutoId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContextoItems");

            migrationBuilder.DropTable(
                name: "Contextos");

            migrationBuilder.DropTable(
                name: "CustomizacaoModificacoes");

            migrationBuilder.DropTable(
                name: "ProdutoOpcoesGrupos");

            migrationBuilder.DropTable(
                name: "Itens");

            migrationBuilder.DropTable(
                name: "Opcoes");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "GrupoOpcoes");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Catalogos");
        }
    }
}
