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
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Index = table.Column<int>(type: "int", nullable: false),
                    ComercioUId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GrupoOpcoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    table.PrimaryKey("PK_GrupoOpcoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdutoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IsIndustrializado = table.Column<bool>(type: "bit", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Unidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Peso = table.Column<int>(type: "int", nullable: false),
                    ComercioUId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ean = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Serving = table.Column<int>(type: "int", nullable: false),
                    RestriocaoAlimentar = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Itens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Index = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProdutoId = table.Column<int>(type: "int", nullable: true),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Itens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Itens_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Itens_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Opcoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OpcaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ProdutoId = table.Column<int>(type: "int", nullable: true),
                    OpcoesGrupoId = table.Column<int>(type: "int", nullable: false),
                    Fracoes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opcoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Opcoes_GrupoOpcoes_OpcoesGrupoId",
                        column: x => x.OpcoesGrupoId,
                        principalTable: "GrupoOpcoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Opcoes_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProdutoOpcoesGrupos",
                columns: table => new
                {
                    ProdutoId = table.Column<int>(type: "int", nullable: false),
                    GrupoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoOpcoesGrupos", x => new { x.GrupoId, x.ProdutoId });
                    table.ForeignKey(
                        name: "FK_ProdutoOpcoesGrupos_GrupoOpcoes_GrupoId",
                        column: x => x.GrupoId,
                        principalTable: "GrupoOpcoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdutoOpcoesGrupos_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contextos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContextoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OpcaoId = table.Column<int>(type: "int", nullable: false),
                    parentOptionId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contextos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contextos_Opcoes_parentOptionId",
                        column: x => x.parentOptionId,
                        principalTable: "Opcoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "CategoriaId", "ComercioUId", "DataCriacao", "Descricao", "Index", "Nome", "Status", "Tipo" },
                values: new object[,]
                {
                    { 1, new Guid("c1a5f8e2-3b6d-4f8e-9c7e-0d8f9a1b2c3d"), new Guid("b1c8f3d2-4e5f-4b6a-9c7e-0d8f9a1b2c3d"), new DateTime(2025, 8, 28, 19, 59, 18, 358, DateTimeKind.Local).AddTicks(2591), "Categoria de Pizzas Tradicionais", 0, "Pizzas", 1, 1 },
                    { 2, new Guid("d2b6f9e3-4c7e-5f9f-0d8f-1a2b3c4d5e6f"), new Guid("b1c8f3d2-4e5f-4b6a-9c7e-0d8f9a1b2c3d"), new DateTime(2025, 8, 28, 19, 59, 18, 361, DateTimeKind.Local).AddTicks(8927), "Categoria de Massas para Pizzas", 1, "Lanches Rápidos", 1, 0 },
                    { 3, new Guid("68a418a3-ae7f-4623-8afc-35afbeed4b15"), new Guid("b1c8f3d2-4e5f-4b6a-9c7e-0d8f9a1b2c3d"), new DateTime(2025, 8, 28, 19, 59, 18, 361, DateTimeKind.Local).AddTicks(8960), "Categoria de Pizzas Doces", 2, "Pizza Doces", 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "GrupoOpcoes",
                columns: new[] { "Id", "DataCriacao", "Index", "Max", "Min", "Nome", "OpcaoGrupoId", "ResourceGroupoType", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 8, 28, 19, 59, 18, 367, DateTimeKind.Local).AddTicks(7967), 0, 1, 0, "Tamanhos", new Guid("15af8bd9-6d54-43f2-8c74-43d5d4da32d8"), 1, 1 },
                    { 2, new DateTime(2025, 8, 28, 19, 59, 18, 367, DateTimeKind.Local).AddTicks(9122), 0, 1, 0, "Massas", new Guid("26b1a876-7ee4-4f15-9bb1-d33c840c5049"), 2, 1 },
                    { 3, new DateTime(2025, 8, 28, 19, 59, 18, 367, DateTimeKind.Local).AddTicks(9130), 0, 5, 0, "Bordas", new Guid("668a93a9-704e-4036-a515-11e4ddbe4129"), 3, 1 },
                    { 4, new DateTime(2025, 8, 28, 19, 59, 18, 367, DateTimeKind.Local).AddTicks(9135), 0, 1, 0, "Sabores", new Guid("d1eed8e6-c1f0-4f09-a235-2d459bb33cbb"), 4, 1 },
                    { 5, new DateTime(2025, 8, 28, 19, 59, 18, 367, DateTimeKind.Local).AddTicks(9140), 0, 1, 0, "Acompanhamentos", new Guid("1e5e5eb5-84c7-4eca-b0c1-921860434f70"), 6, 1 },
                    { 6, new DateTime(2025, 8, 28, 19, 59, 18, 367, DateTimeKind.Local).AddTicks(9188), 0, 1, 0, "Tamanhos", new Guid("b1d11fe1-f080-4dcf-847c-4fda4556b796"), 1, 1 },
                    { 7, new DateTime(2025, 8, 28, 19, 59, 18, 367, DateTimeKind.Local).AddTicks(9193), 0, 1, 0, "Massas", new Guid("c3290906-b081-47ab-abdf-38291096b587"), 2, 1 },
                    { 8, new DateTime(2025, 8, 28, 19, 59, 18, 367, DateTimeKind.Local).AddTicks(9198), 0, 5, 0, "Bordas", new Guid("040377c0-6674-4bd6-a55d-6637697aed8e"), 3, 1 },
                    { 9, new DateTime(2025, 8, 28, 19, 59, 18, 367, DateTimeKind.Local).AddTicks(9202), 0, 1, 0, "Sabores", new Guid("dad6ebdd-59e3-47ee-827c-0c0c3c7fa1ae"), 4, 1 }
                });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "ComercioUId", "DataCriacao", "Descricao", "Ean", "IsIndustrializado", "Nome", "Peso", "ProdutoId", "RestriocaoAlimentar", "Serving", "Status", "Unidade" },
                values: new object[,]
                {
                    { 1, new Guid("b1c8f3d2-4e5f-4b6a-9c7e-0d8f9a1b2c3d"), new DateTime(2025, 8, 28, 19, 59, 18, 365, DateTimeKind.Local).AddTicks(3928), null, null, false, "Pizzas Tradicionais", 10, new Guid("51b644cc-a90c-4456-992f-f86631176796"), null, 0, 1, "kg" },
                    { 2, new Guid("b1c8f3d2-4e5f-4b6a-9c7e-0d8f9a1b2c3d"), new DateTime(2025, 8, 28, 19, 59, 18, 365, DateTimeKind.Local).AddTicks(5353), null, null, false, "Massa Tradicional", 5, new Guid("9f72cd07-4463-4bfc-8fc1-97129c775e21"), null, 0, 1, "g" },
                    { 3, new Guid("b1c8f3d2-4e5f-4b6a-9c7e-0d8f9a1b2c3d"), new DateTime(2025, 8, 28, 19, 59, 18, 365, DateTimeKind.Local).AddTicks(5364), null, null, false, "Massa fina", 5, new Guid("c8eff6c6-f3c5-48ec-9a5b-aa5b3eeec582"), null, 0, 1, "g" },
                    { 4, new Guid("b1c8f3d2-4e5f-4b6a-9c7e-0d8f9a1b2c3d"), new DateTime(2025, 8, 28, 19, 59, 18, 365, DateTimeKind.Local).AddTicks(5373), null, null, false, "Tamanho Médio", 5, new Guid("27fa98cd-e119-432d-9b0a-8f99a65be1b7"), null, 0, 1, "g" },
                    { 5, new Guid("b1c8f3d2-4e5f-4b6a-9c7e-0d8f9a1b2c3d"), new DateTime(2025, 8, 28, 19, 59, 18, 365, DateTimeKind.Local).AddTicks(5381), null, null, false, "Tamanho Grande", 5, new Guid("932e18a2-396d-40d2-8de4-da0cf8f95faf"), null, 0, 1, "g" },
                    { 6, new Guid("b1c8f3d2-4e5f-4b6a-9c7e-0d8f9a1b2c3d"), new DateTime(2025, 8, 28, 19, 59, 18, 365, DateTimeKind.Local).AddTicks(5407), null, null, false, "Borda Tradicional", 5, new Guid("e4ac0247-33ed-476a-ae69-363f27fe0df7"), null, 0, 1, "g" },
                    { 7, new Guid("b1c8f3d2-4e5f-4b6a-9c7e-0d8f9a1b2c3d"), new DateTime(2025, 8, 28, 19, 59, 18, 365, DateTimeKind.Local).AddTicks(5416), null, null, false, "Borda Recheada", 5, new Guid("eb021b00-0fef-434b-9da5-77e4dbca047e"), null, 0, 1, "g" },
                    { 8, new Guid("b1c8f3d2-4e5f-4b6a-9c7e-0d8f9a1b2c3d"), new DateTime(2025, 8, 28, 19, 59, 18, 365, DateTimeKind.Local).AddTicks(5424), null, null, false, "Calabresa", 5, new Guid("d6ae0c15-4db9-454e-868b-a9ec7719da5e"), null, 0, 1, "g" },
                    { 9, new Guid("b1c8f3d2-4e5f-4b6a-9c7e-0d8f9a1b2c3d"), new DateTime(2025, 8, 28, 19, 59, 18, 365, DateTimeKind.Local).AddTicks(5431), null, null, false, "Frango com Catupiry", 5, new Guid("b4a093cc-7e4a-49d2-909a-fed1cc58c572"), null, 0, 1, "g" },
                    { 10, new Guid("b1c8f3d2-4e5f-4b6a-9c7e-0d8f9a1b2c3d"), new DateTime(2025, 8, 28, 19, 59, 18, 365, DateTimeKind.Local).AddTicks(5440), "Pão, carne, queijo e salada", "7891234567890", false, "X-Burger", 5, new Guid("62133b9f-5542-401d-8743-49ec7da8c847"), null, 1, 1, "g" },
                    { 11, new Guid("b1c8f3d2-4e5f-4b6a-9c7e-0d8f9a1b2c3d"), new DateTime(2025, 8, 28, 19, 59, 18, 365, DateTimeKind.Local).AddTicks(6631), "200 g", null, false, "Batata Frita", 5, new Guid("713713e7-641e-44fd-bd92-13ba43daf6a8"), null, 0, 1, "g" },
                    { 12, new Guid("b1c8f3d2-4e5f-4b6a-9c7e-0d8f9a1b2c3d"), new DateTime(2025, 8, 28, 19, 59, 18, 365, DateTimeKind.Local).AddTicks(6708), null, null, false, "Pizzas Doces", 10, new Guid("8e5eb648-9591-428a-a08d-edaca8930dac"), null, 0, 1, "kg" },
                    { 13, new Guid("b1c8f3d2-4e5f-4b6a-9c7e-0d8f9a1b2c3d"), new DateTime(2025, 8, 28, 19, 59, 18, 365, DateTimeKind.Local).AddTicks(6714), null, null, false, "Chocolate", 5, new Guid("7c1ada9c-13f8-40cf-9d43-057b4c0e2559"), null, 0, 1, "g" },
                    { 14, new Guid("b1c8f3d2-4e5f-4b6a-9c7e-0d8f9a1b2c3d"), new DateTime(2025, 8, 28, 19, 59, 18, 365, DateTimeKind.Local).AddTicks(6719), null, null, false, "Morango com Chocolate", 5, new Guid("7a66e116-8825-4b92-9816-60b1328018a1"), null, 0, 1, "g" },
                    { 15, new Guid("b1c8f3d2-4e5f-4b6a-9c7e-0d8f9a1b2c3d"), new DateTime(2025, 8, 28, 19, 59, 18, 365, DateTimeKind.Local).AddTicks(6724), null, null, false, "Massa Tradicional Doces", 5, new Guid("df287fd9-f27d-43dc-be1e-53fd1a4ad1cd"), null, 0, 1, "g" },
                    { 16, new Guid("b1c8f3d2-4e5f-4b6a-9c7e-0d8f9a1b2c3d"), new DateTime(2025, 8, 28, 19, 59, 18, 365, DateTimeKind.Local).AddTicks(6728), null, null, false, "Tamanho Pequeno", 5, new Guid("bc90f374-9f12-4914-80f9-fbc1147a0ced"), null, 0, 1, "g" },
                    { 17, new Guid("b1c8f3d2-4e5f-4b6a-9c7e-0d8f9a1b2c3d"), new DateTime(2025, 8, 28, 19, 59, 18, 365, DateTimeKind.Local).AddTicks(6733), null, null, false, "Tamanho Médio", 5, new Guid("33b0b559-eecd-4076-a46b-2e3e78681953"), null, 0, 1, "g" },
                    { 18, new Guid("b1c8f3d2-4e5f-4b6a-9c7e-0d8f9a1b2c3d"), new DateTime(2025, 8, 28, 19, 59, 18, 365, DateTimeKind.Local).AddTicks(6747), null, null, false, "Tamanho Grande", 5, new Guid("6089df30-830f-4e04-a43d-8e476ab176d5"), null, 0, 1, "g" }
                });

            migrationBuilder.InsertData(
                table: "Itens",
                columns: new[] { "Id", "CategoriaId", "DataCriacao", "Index", "ItemId", "ProdutoId", "Tipo" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 8, 28, 19, 59, 18, 366, DateTimeKind.Local).AddTicks(4421), 0, new Guid("05a9521e-183a-4d39-b6e4-0a0fbb9f6c44"), 1, 1 },
                    { 2, 2, new DateTime(2025, 8, 28, 19, 59, 18, 366, DateTimeKind.Local).AddTicks(5204), 0, new Guid("4c4d3948-69f0-4366-85e2-a735e08f7e29"), 10, 0 },
                    { 3, 3, new DateTime(2025, 8, 28, 19, 59, 18, 366, DateTimeKind.Local).AddTicks(5210), 0, new Guid("87ab51ea-5e29-4d68-bd5d-827f95893357"), 12, 1 },
                    { 4, 2, new DateTime(2025, 8, 28, 19, 59, 18, 366, DateTimeKind.Local).AddTicks(5214), 0, new Guid("e837cd76-c1b1-496d-853f-749eca1f0c03"), 11, 0 }
                });

            migrationBuilder.InsertData(
                table: "Opcoes",
                columns: new[] { "Id", "Fracoes", "OpcaoId", "OpcoesGrupoId", "ProdutoId", "Status" },
                values: new object[,]
                {
                    { 1, "1", new Guid("945ef3bc-7741-4bec-a0ce-4660c09a564f"), 1, 4, 1 },
                    { 2, "1,2", new Guid("2587c76e-3aa3-45e6-95d9-35c21ac19f9d"), 1, 5, 1 },
                    { 3, null, new Guid("0d58a046-1871-433d-bd8d-2b33abfbfa70"), 4, 8, 1 },
                    { 4, null, new Guid("a4eb62d0-ca33-459e-82b1-4de25997ba9e"), 4, 9, 1 },
                    { 5, null, new Guid("cc71b438-523f-49ac-918a-82df71244f9b"), 3, 6, 1 },
                    { 6, null, new Guid("df8728b2-7773-486b-aa93-47627bdd0c54"), 3, 7, 1 },
                    { 7, null, new Guid("7fb0eac3-43e5-41c6-860e-a38793db4988"), 2, 2, 1 },
                    { 8, null, new Guid("d0d0df88-b276-4a21-ab14-063e8f0c3c5d"), 2, 3, 1 },
                    { 9, null, new Guid("d3e31829-a215-47e3-9576-3fddec9417ec"), 5, 11, 1 },
                    { 10, null, new Guid("d0ea62e8-dd70-4744-b240-e0da591dd118"), 9, 13, 1 },
                    { 11, null, new Guid("9929499b-60b9-409d-90dc-0cf4db0c4535"), 9, 14, 1 },
                    { 12, null, new Guid("b94317db-7b78-4724-b4c1-dd05020654c6"), 7, 15, 1 },
                    { 13, "1", new Guid("ad163e58-13b9-497b-8133-41d4f6d9cb1e"), 6, 16, 1 },
                    { 14, "1,2", new Guid("d7748cc9-1a02-4a3f-9b1c-0b7094460a1b"), 6, 17, 1 },
                    { 15, "1,2,3", new Guid("273a28f8-3d7f-4164-8ced-3e18ad650181"), 6, 18, 1 }
                });

            migrationBuilder.InsertData(
                table: "ProdutoOpcoesGrupos",
                columns: new[] { "GrupoId", "ProdutoId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 5, 10 },
                    { 5, 11 },
                    { 6, 12 },
                    { 7, 12 },
                    { 8, 12 },
                    { 9, 12 }
                });

            migrationBuilder.InsertData(
                table: "Contextos",
                columns: new[] { "Id", "ContextoId", "OpcaoId", "Status", "parentOptionId" },
                values: new object[,]
                {
                    { 1, new Guid("1cdb162b-7632-4876-8535-76701e7acde2"), 1, 1, 3 },
                    { 2, new Guid("796b05b5-88d9-4793-a9ff-1cc5abe78db5"), 1, 1, 3 },
                    { 3, new Guid("fe76c116-3197-4893-aeb1-e1229d837d30"), 1, 1, 4 },
                    { 4, new Guid("ef61b0f2-31a3-45bb-ad6c-a00895849d5f"), 2, 1, 4 },
                    { 5, new Guid("1bb9af44-966e-4b5d-8d7b-f0def1d0ab82"), 13, 1, 10 },
                    { 6, new Guid("84b1c768-2871-4019-824f-01defec03ea3"), 14, 1, 10 },
                    { 7, new Guid("13f23287-785b-4b15-ba32-4bae9e4fa251"), 14, 1, 10 },
                    { 8, new Guid("c3520267-072b-4dd6-84c5-9c882680797f"), 14, 1, 11 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_CategoriaId",
                table: "Categorias",
                column: "CategoriaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contextos_parentOptionId",
                table: "Contextos",
                column: "parentOptionId");

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
                name: "IX_Produtos_ProdutoId",
                table: "Produtos",
                column: "ProdutoId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contextos");

            migrationBuilder.DropTable(
                name: "Itens");

            migrationBuilder.DropTable(
                name: "ProdutoOpcoesGrupos");

            migrationBuilder.DropTable(
                name: "Opcoes");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "GrupoOpcoes");

            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
