
using Domain.Entities;
using Domain.Juncoes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public static class InicializerFaker
    {

        public static void FakerInicializa(ModelBuilder builder)
        {
            builder.Entity<Categoria>().HasData(GetCategorias());
            builder.Entity<Produto>().HasData(GetProdutos());
            builder.Entity<Item>().HasData(GetItems());
            builder.Entity<GrupoOpcoes>().HasData(GetOpcoesGrupos());
            builder.Entity<Opcoes>().HasData(GetOpcoes());
            builder.Entity<ProdutoOpcoesGrupo>().HasData(GetProdutoOpcoesGrupo());
            builder.Entity<Contexto>().HasData(GetContextos());
        }

        private static List<Contexto> GetContextos()
        {
            return new List<Contexto>
                    {
                        new Contexto
                        {
                            Id = 1,
                            OpcaoId = 1, // Tamanho Médio
                            parentOptionId = 3, // sabor Calabresa
                            ContextoId = Guid.NewGuid(),
                            Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                        },new Contexto
                        {
                            Id = 2,
                            OpcaoId = 1, // Tamanho Médio
                            parentOptionId = 3, // Sabor Calabresa
                            ContextoId = Guid.NewGuid(),
                            Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                        },new Contexto
                        {
                            Id = 3,
                            OpcaoId = 1, 
                            parentOptionId = 4, 
                            ContextoId = Guid.NewGuid(),
                            Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                        },new Contexto
                        {
                            Id = 4,
                            OpcaoId = 2, 
                            parentOptionId = 4, 
                            ContextoId = Guid.NewGuid(),
                            Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                        },new Contexto
                        {
                            Id = 5,
                            OpcaoId = 13, 
                            parentOptionId = 10, 
                            ContextoId = Guid.NewGuid(),
                            Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                        },new Contexto
                        {
                            Id = 6,
                            OpcaoId = 14, 
                            parentOptionId = 10, 
                            ContextoId = Guid.NewGuid(),
                            Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                        },new Contexto
                        {
                            Id = 7,
                            OpcaoId = 14,
                            parentOptionId = 10,
                            ContextoId = Guid.NewGuid(),
                            Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                        },new Contexto
                        {
                            Id = 8,
                            OpcaoId = 14, 
                            parentOptionId = 11,
                            ContextoId = Guid.NewGuid(),
                            Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                        }
            };
        }

        private static List<ProdutoOpcoesGrupo> GetProdutoOpcoesGrupo()
        {
            return new List<ProdutoOpcoesGrupo>
            {
                new ProdutoOpcoesGrupo
                {
                    ProdutoId = 1, //Produto Pizzas Tradicionais
                    GrupoId = 1, // Grupo Tamanhos
                    
                },new ProdutoOpcoesGrupo
                {
                    ProdutoId = 1, //Produto Pizzas Tradicionais
                    GrupoId = 2, // Grupo Massas
                },new ProdutoOpcoesGrupo
                {
                    ProdutoId = 1, //Produto Pizzas Tradicionais
                    GrupoId = 3, // Grupo Bordas

                },new ProdutoOpcoesGrupo
                {
                    ProdutoId = 1, //Produto Pizzas Tradicionais
                    GrupoId = 4, // Grupo Sabores
                },new ProdutoOpcoesGrupo
                {
                    ProdutoId = 10, //Produto X-Burger
                    GrupoId = 5, // Grupo Acompanhamentos
                },new ProdutoOpcoesGrupo
                {
                    ProdutoId = 12, //Produto Pizzas Doces
                    GrupoId = 6, // Grupo Tamanhos
                },new ProdutoOpcoesGrupo
                {
                    ProdutoId = 12, //Produto Pizzas Doces
                    GrupoId = 7, // Grupo Massas
                },new ProdutoOpcoesGrupo
                {
                    ProdutoId = 12, //Produto Pizzas Doces
                    GrupoId = 8, // Grupo Bordas
                },new ProdutoOpcoesGrupo
                {
                    ProdutoId = 12, //Produto Pizzas Doces
                    GrupoId = 9, // Grupo Sabores
                },new ProdutoOpcoesGrupo
                {
                    ProdutoId = 11, //Produto Batata Frita
                    GrupoId = 5, // Grupo Acompanhamentos
                }
            };
        }

        private static List<Categoria> GetCategorias()
        {
            return new List<Categoria>
            {
                new Categoria
                {
                    Id = 1,
                    CategoriaId = new Guid("c1a5f8e2-3b6d-4f8e-9c7e-0d8f9a1b2c3d"),
                    Nome = "Pizzas",
                    Descricao = "Categoria de Pizzas Tradicionais",
                    Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                    DataCriacao = DateTime.Now,
                    Index = 0,
                    Tipo = Domain.Enuns.ResourceItemTipo.PIZZA,
                    ComercioUId = new Guid("b1c8f3d2-4e5f-4b6a-9c7e-0d8f9a1b2c3d") // Comercio D
                },new Categoria
                {
                    Id = 2,
                    CategoriaId = new Guid("d2b6f9e3-4c7e-5f9f-0d8f-1a2b3c4d5e6f"),
                    Nome = "Lanches Rápidos",
                    Descricao = "Categoria de Massas para Pizzas",
                    Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                    DataCriacao = DateTime.Now,
                    Index = 1,
                    Tipo = Domain.Enuns.ResourceItemTipo.DEFAULT,
                    ComercioUId = new Guid("b1c8f3d2-4e5f-4b6a-9c7e-0d8f9a1b2c3d") // Comercio D
                },new Categoria
                {
                    Id = 3,
                    CategoriaId = new Guid("68a418a3-ae7f-4623-8afc-35afbeed4b15"),
                    Nome = "Pizza Doces",
                    Descricao = "Categoria de Pizzas Doces",
                    Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                    DataCriacao = DateTime.Now,
                    Index = 2,
                    Tipo = Domain.Enuns.ResourceItemTipo.PIZZA,
                    ComercioUId = new Guid("b1c8f3d2-4e5f-4b6a-9c7e-0d8f9a1b2c3d") // Comercio D
                }
            };
        }

        private static List<Opcoes> GetOpcoes()
        {
            return new List<Opcoes>
            {
                new Opcoes
                {
                    Id = 1,
                    OpcaoId = new Guid("945ef3bc-7741-4bec-a0ce-4660c09a564f"),
                    Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                    ProdutoId = 4, // Tamanho Médio
                    OpcoesGrupoId = 1, // Tamanhos;
                    Fracoes = new List<int> { 1 }
                },new Opcoes
                {
                    Id = 2,
                    OpcaoId = new Guid("2587c76e-3aa3-45e6-95d9-35c21ac19f9d"),
                    Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                    ProdutoId = 5, // Tamanho Grande
                    OpcoesGrupoId = 1, // Tamanhos;
                    Fracoes = new List<int> { 1,2 }

                },new Opcoes
                {
                    Id = 3,
                    OpcaoId = new Guid("0d58a046-1871-433d-bd8d-2b33abfbfa70"),
                    Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                    ProdutoId = 8, // Sabor Calabresa
                    OpcoesGrupoId = 4, // Sabores;
                    Fracoes = null,
                    //Contexto: Pizza inteira ou Meia pizza (1/2) ou 1/3 ou 1/4
                    
                },new Opcoes
                {
                    Id = 4,
                    OpcaoId = new Guid("a4eb62d0-ca33-459e-82b1-4de25997ba9e"),
                    Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                    ProdutoId = 9, // Sabor Frango com Catupiry
                    OpcoesGrupoId = 4, // Sabores;
                    Fracoes = null,
                  
                   
                },new Opcoes
                {
                    Id = 5,
                    OpcaoId = new Guid("cc71b438-523f-49ac-918a-82df71244f9b"),
                    Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                    ProdutoId = 6, // Borda Tradicional
                    OpcoesGrupoId = 3, // Bordas;
                    Fracoes = null,
                },new Opcoes
                {
                    Id = 6,
                    OpcaoId = new Guid("df8728b2-7773-486b-aa93-47627bdd0c54"),
                    Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                    ProdutoId = 7, // Borda Recheada
                    OpcoesGrupoId = 3, // Bordas;
                    Fracoes = null,
                },new Opcoes
                {
                    Id = 7,
                    OpcaoId = new Guid("7fb0eac3-43e5-41c6-860e-a38793db4988"),
                    Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                    ProdutoId = 2, // Massa Tradicional
                    OpcoesGrupoId = 2, // Massas;
                    Fracoes = null,
                },new Opcoes
                {
                    Id = 8,
                    OpcaoId = new Guid("d0d0df88-b276-4a21-ab14-063e8f0c3c5d"),
                    Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                    ProdutoId = 3, // Massa Fina
                    OpcoesGrupoId = 2, // Massas;
                    Fracoes = null,
                },new Opcoes
                {
                    Id = 9,
                    OpcaoId = new Guid("d3e31829-a215-47e3-9576-3fddec9417ec"),
                    Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                    ProdutoId = 11, // Produto Batata Frita
                    OpcoesGrupoId = 5, // Acompanhamentos
                    Fracoes = null,
                },new Opcoes
                {
                    Id = 10,
                    OpcaoId = Guid.NewGuid(),
                    Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                    ProdutoId = 13, // Produto Chocolate
                    OpcoesGrupoId = 9, // Sabores Pizzas Doces
                    Fracoes = null,
                   
                },new Opcoes
                {
                    Id = 11,
                    OpcaoId = Guid.NewGuid(),
                    Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                    ProdutoId = 14, // Produto Morango com Chocolate
                    OpcoesGrupoId = 9, // Sabores Pizzas Doces
                    Fracoes = null,
                    

                },new Opcoes
                {
                    Id = 12,
                    OpcaoId = Guid.NewGuid(),
                    Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                    ProdutoId = 15, // Produto Massa Tradicional Doces
                    OpcoesGrupoId = 7, // Massas Pizzas Doces
                    Fracoes = null,
                },new Opcoes
                {
                    Id = 13,
                    OpcaoId = Guid.NewGuid(),
                    Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                    ProdutoId = 16, // Produto Tamanho Pequeno
                    OpcoesGrupoId = 6, // Tamanhos Pizzas Doces
                    Fracoes = new List<int> { 1 }
                },new Opcoes
                {
                    Id = 14,
                    OpcaoId = Guid.NewGuid(),
                    Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                    ProdutoId = 17, // Produto Tamanho Médio
                    OpcoesGrupoId = 6, // Tamanhos Pizzas Doces
                    Fracoes = new List<int> { 1,2 }
                },new Opcoes
                {
                    Id = 15,
                    OpcaoId = Guid.NewGuid(),
                    Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                    ProdutoId = 18, // Produto Tamanho Grande
                    OpcoesGrupoId = 6, // Tamanhos Pizzas Doces
                    Fracoes = new List<int> { 1,2,3 }
                }
            };
        }

        private static List<GrupoOpcoes> GetOpcoesGrupos()
        {
            return new List<GrupoOpcoes>
            {
                new GrupoOpcoes
                {
                    Id = 1,
                    OpcaoGrupoId = new Guid("15af8bd9-6d54-43f2-8c74-43d5d4da32d8"),
                    Min= 0,
                    Max = 1,
                    Nome = "Tamanhos",
                    Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                    DataCriacao = DateTime.Now,
                    Index = 0,
                  //  ProdutoId = 1,
                    ResourceGroupoType = Domain.Enuns.ResourceGrupoType.SIZE
                    //IDs OptionsIds
                },new GrupoOpcoes{
                    Id = 2,
                    OpcaoGrupoId = new Guid("26b1a876-7ee4-4f15-9bb1-d33c840c5049"),
                    Min= 0,
                    Max = 1,
                    Nome = "Massas",
                    Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                    DataCriacao = DateTime.Now,
                    Index = 0,
                  //  ProdutoId = 1,
                    ResourceGroupoType = Domain.Enuns.ResourceGrupoType.CRUST
                    //IDs OptionsIds
                },new GrupoOpcoes{
                    Id = 3,
                    OpcaoGrupoId = new Guid("668a93a9-704e-4036-a515-11e4ddbe4129"),
                    Min= 0,
                    Max = 5,
                    Nome = "Bordas",
                    Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                    DataCriacao = DateTime.Now,
                    Index = 0,
                  //  ProdutoId = 1,
                    ResourceGroupoType = Domain.Enuns.ResourceGrupoType.EDGE
                    //IDs OptionsIds
                },new GrupoOpcoes{
                    Id = 4,
                    OpcaoGrupoId = new Guid("d1eed8e6-c1f0-4f09-a235-2d459bb33cbb"),
                    Min= 0,
                    Max = 1,
                    Nome = "Sabores",
                    Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                    DataCriacao = DateTime.Now,
                    Index = 0,
                  //  ProdutoId = 1,
                    ResourceGroupoType = Domain.Enuns.ResourceGrupoType.TOPPING
                    //IDs OptionsIds
                },new GrupoOpcoes
                {
                    Id = 5,
                    OpcaoGrupoId = new Guid("1e5e5eb5-84c7-4eca-b0c1-921860434f70"),
                    Min= 0,
                    Max = 1,
                    Nome = "Acompanhamentos",
                    Index = 0,
                    Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                    DataCriacao = DateTime.Now,
                    ResourceGroupoType = Domain.Enuns.ResourceGrupoType.INGREDIENTS,
                  //  ProdutoId = 10, // Produto X-Burger
                    // IDS OptiosIds
                    
                },new GrupoOpcoes
                {
                    Id = 6,
                    OpcaoGrupoId = Guid.NewGuid(),
                    Min= 0,
                    Max = 1,
                    Nome = "Tamanhos",
                    Index = 0,
                    Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                    DataCriacao = DateTime.Now,
                    ResourceGroupoType = Domain.Enuns.ResourceGrupoType.SIZE,
                  //  ProdutoId = 12, // Produto Pizzas Doces
                    // IDS OptiosIds
                },new GrupoOpcoes
                {
                    Id = 7,
                    OpcaoGrupoId = Guid.NewGuid(),
                    Min= 0,
                    Max = 1,
                    Nome = "Massas",
                    Index = 0,
                    Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                    DataCriacao = DateTime.Now,
                    ResourceGroupoType = Domain.Enuns.ResourceGrupoType.CRUST,
                  //  ProdutoId = 12, // Produto Pizzas Doces
                                    // IDS OptiosIds
                },new GrupoOpcoes
                {
                    Id = 8,
                    OpcaoGrupoId = Guid.NewGuid(),
                    Min= 0,
                    Max = 5,
                    Nome = "Bordas",
                    Index = 0,
                    Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                    DataCriacao = DateTime.Now,
                    ResourceGroupoType = Domain.Enuns.ResourceGrupoType.EDGE,
                  //  ProdutoId = 12, // Produto Pizzas Doces
                                    // IDS OptiosIds
                },new GrupoOpcoes
                {
                    Id = 9,
                    OpcaoGrupoId = Guid.NewGuid(),
                    Min= 0,
                    Max = 1,
                    Nome = "Sabores",
                    Index = 0,
                    Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                    DataCriacao = DateTime.Now,
                    ResourceGroupoType = Domain.Enuns.ResourceGrupoType.TOPPING,
                  //  ProdutoId = 12, // Produto Pizzas Doces
                                    // IDS OptiosIds
                }
            };
        }

        //new Guid("b1c8f3d2-4e5f-4b6a-9c7e-0d8f9a1b2c3d")  Comercio D
        //
        private static List<Item> GetItems()
        {
           return new List<Item>
            {
                new Item
                {
                    Id = 1,
                    ItemId = Guid.NewGuid(),
                    Tipo = Domain.Enuns.ResourceItemTipo.PIZZA,
                 //   Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                    Index = 0,
                    DataCriacao = DateTime.Now,
                    ProdutoId = 1,
                    CategoriaId = 1 // Categoria Pizzas
                },new Item
                {
                    Id = 2,
                    ItemId = Guid.NewGuid(),
                    Tipo = Domain.Enuns.ResourceItemTipo.DEFAULT,
                  //  Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                    Index = 0,
                    DataCriacao = DateTime.Now,
                    ProdutoId = 10, // X-Burger
                    CategoriaId = 2 // Categoria Lanches Rápidos
                },new Item
                {
                    Id = 3,
                    ItemId = Guid.NewGuid(),
                    Tipo = Domain.Enuns.ResourceItemTipo.PIZZA,
                  //  Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                    Index = 0,
                    DataCriacao = DateTime.Now,
                    ProdutoId = 12, // Pizzas Doces
                    CategoriaId = 3, // Categoria Pizzas Doces
                },new Item
                {
                    Id = 4,
                    ItemId = Guid.NewGuid(),
                    Tipo = Domain.Enuns.ResourceItemTipo.DEFAULT,
                  //  Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                    Index = 0,
                    DataCriacao = DateTime.Now,
                    ProdutoId = 11, // Batata Frita
                    CategoriaId = 2 // Categoria Lanches Rápidos
                }
              
            };
        }

        private static List<Produto> GetProdutos()
        {
            return new List<Produto>
            {
                new Produto
                {
                    Id = 1,
                    ProdutoId = new Guid("51b644cc-a90c-4456-992f-f86631176796"),
                    Nome = "Pizzas Tradicionais",
                    Descricao = null,
                    Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                    IsIndustrializado = false,
                    DataCriacao = DateTime.Now,
                    Unidade = "kg",
                    Peso = 10,
                    ComercioUId = new Guid("b1c8f3d2-4e5f-4b6a-9c7e-0d8f9a1b2c3d")
                },
                new Produto
                {
                    Id = 2,
                    ProdutoId = new Guid("9f72cd07-4463-4bfc-8fc1-97129c775e21"),
                    Nome = "Massa Tradicional",
                    Descricao = null,
                    Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                    IsIndustrializado = false,
                    DataCriacao = DateTime.Now,
                    Unidade = "g",
                    Peso = 5,
                    ComercioUId = new Guid("b1c8f3d2-4e5f-4b6a-9c7e-0d8f9a1b2c3d")
                },new Produto
                {
                    Id = 3,
                    ProdutoId = new Guid("c8eff6c6-f3c5-48ec-9a5b-aa5b3eeec582"),
                    Nome = "Massa fina",
                    Descricao = null,
                    Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                    IsIndustrializado = false,
                    DataCriacao = DateTime.Now,
                    Unidade = "g",
                    Peso = 5,
                    ComercioUId = new Guid("b1c8f3d2-4e5f-4b6a-9c7e-0d8f9a1b2c3d")
                },new Produto
                {
                    Id = 4,
                    ProdutoId = new Guid("27fa98cd-e119-432d-9b0a-8f99a65be1b7"),
                    Nome = "Tamanho Médio",
                    Descricao = null,
                    Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                    IsIndustrializado = false,
                    DataCriacao = DateTime.Now,
                    Unidade = "g",
                    Peso = 5,
                    ComercioUId = new Guid("b1c8f3d2-4e5f-4b6a-9c7e-0d8f9a1b2c3d"),
                },new Produto{
                    Id = 5,
                    ProdutoId = new Guid("932e18a2-396d-40d2-8de4-da0cf8f95faf"),
                    Nome = "Tamanho Grande",
                    Descricao = null,
                    Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                    IsIndustrializado = false,
                    DataCriacao = DateTime.Now,
                    Unidade = "g",
                    Peso = 5,
                    ComercioUId = new Guid("b1c8f3d2-4e5f-4b6a-9c7e-0d8f9a1b2c3d"),
                  },new Produto
                  {
                      Id = 6,
                      ProdutoId = new Guid("e4ac0247-33ed-476a-ae69-363f27fe0df7"),
                      Nome = "Borda Tradicional",
                      Descricao = null,
                      Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                      IsIndustrializado = false,
                      DataCriacao = DateTime.Now,
                      Unidade = "g",
                      Peso = 5,
                      ComercioUId = new Guid("b1c8f3d2-4e5f-4b6a-9c7e-0d8f9a1b2c3d"),
                  },new Produto{
                      Id = 7,
                      ProdutoId = new Guid("eb021b00-0fef-434b-9da5-77e4dbca047e"),
                      Nome = "Borda Recheada",
                      Descricao = null,
                      Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                      IsIndustrializado = false,
                      DataCriacao = DateTime.Now,
                      Unidade = "g",
                      Peso = 5,
                      ComercioUId = new Guid("b1c8f3d2-4e5f-4b6a-9c7e-0d8f9a1b2c3d"),
                  },new Produto{
                      Id = 8,
                      ProdutoId = new Guid("d6ae0c15-4db9-454e-868b-a9ec7719da5e"),
                      Nome = "Calabresa",
                      Descricao = null,
                      Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                      IsIndustrializado = false,
                      DataCriacao = DateTime.Now,
                      Unidade = "g",
                      Peso = 5,
                      ComercioUId = new Guid("b1c8f3d2-4e5f-4b6a-9c7e-0d8f9a1b2c3d"),
                  },new Produto{
                      Id = 9,
                      ProdutoId = new Guid("b4a093cc-7e4a-49d2-909a-fed1cc58c572"),
                      Nome = "Frango com Catupiry",
                      Descricao = null,
                      Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                      IsIndustrializado = false,
                      DataCriacao = DateTime.Now,
                      Unidade = "g",
                      Peso = 5,
                      ComercioUId = new Guid("b1c8f3d2-4e5f-4b6a-9c7e-0d8f9a1b2c3d"),
                  },new Produto{
                      Id = 10,
                      ProdutoId = new Guid("62133b9f-5542-401d-8743-49ec7da8c847"),
                      Nome = "X-Burger",
                      Descricao = "Pão, carne, queijo e salada",
                      Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                      IsIndustrializado = false,
                      DataCriacao = DateTime.Now,
                      Unidade = "g",
                      Peso = 5,
                      ComercioUId = new Guid("b1c8f3d2-4e5f-4b6a-9c7e-0d8f9a1b2c3d"),
                      Ean = "7891234567890",
                      RestriocaoAlimentar = null,
                      Serving = Domain.Enuns.ResourceProdutoServer.SERVES_1,
                  },new Produto{
                      Id = 11,
                      ProdutoId = new Guid("713713e7-641e-44fd-bd92-13ba43daf6a8"),
                      Nome = "Batata Frita",
                      Descricao = "200 g",
                      Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                      IsIndustrializado = false,
                      DataCriacao = DateTime.Now,
                      Unidade = "g",
                      Peso = 5,
                      ComercioUId = new Guid("b1c8f3d2-4e5f-4b6a-9c7e-0d8f9a1b2c3d"),
                  },new Produto
                  {
                    Id = 12,
                    ProdutoId = Guid.NewGuid(),
                    Nome = "Pizzas Doces",
                    Descricao = null,
                    Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                    IsIndustrializado = false,
                    DataCriacao = DateTime.Now,
                    Unidade = "kg",
                    Peso = 10,
                    ComercioUId = new Guid("b1c8f3d2-4e5f-4b6a-9c7e-0d8f9a1b2c3d")
                  },new Produto{
                    Id = 13,
                    ProdutoId = Guid.NewGuid(),
                    Nome = "Chocolate",
                    Descricao = null,
                    Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                    IsIndustrializado = false,
                    DataCriacao = DateTime.Now,
                    Unidade = "g",
                    Peso = 5,
                    ComercioUId = new Guid("b1c8f3d2-4e5f-4b6a-9c7e-0d8f9a1b2c3d")
                  },new Produto
                  {
                    Id = 14,
                    ProdutoId = Guid.NewGuid(),
                    Nome = "Morango com Chocolate",
                    Descricao = null,
                    Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                    IsIndustrializado = false,
                    DataCriacao = DateTime.Now,
                    Unidade = "g",
                    Peso = 5,
                    ComercioUId = new Guid("b1c8f3d2-4e5f-4b6a-9c7e-0d8f9a1b2c3d")
                  },new Produto
                  {
                      Id = 15,
                      ProdutoId = Guid.NewGuid(),
                      Nome = "Massa Tradicional Doces",
                      Descricao = null,
                      Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                      IsIndustrializado = false,
                      DataCriacao = DateTime.Now,
                      Unidade = "g",
                      Peso = 5,
                      ComercioUId = new Guid("b1c8f3d2-4e5f-4b6a-9c7e-0d8f9a1b2c3d")
                  },new Produto
                  {
                      Id = 16,
                      ProdutoId = Guid.NewGuid(),
                      Nome = "Tamanho Pequeno",
                      Descricao = null,
                      Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                      IsIndustrializado = false,
                      DataCriacao = DateTime.Now,
                      Unidade = "g",
                      Peso = 5,
                      ComercioUId = new Guid("b1c8f3d2-4e5f-4b6a-9c7e-0d8f9a1b2c3d")
                  },new Produto
                  {
                      Id = 17,
                      ProdutoId = Guid.NewGuid(),
                      Nome = "Tamanho Médio",
                      Descricao = null,
                      Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                      IsIndustrializado = false,
                      DataCriacao = DateTime.Now,
                      Unidade = "g",
                      Peso = 5,
                      ComercioUId = new Guid("b1c8f3d2-4e5f-4b6a-9c7e-0d8f9a1b2c3d")
                  },new Produto
                  {
                      Id = 18,
                      ProdutoId = Guid.NewGuid(),
                      Nome = "Tamanho Grande",
                      Descricao = null,
                      Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                      IsIndustrializado = false,
                      DataCriacao = DateTime.Now,
                      Unidade = "g",
                      Peso = 5,
                      ComercioUId = new Guid("b1c8f3d2-4e5f-4b6a-9c7e-0d8f9a1b2c3d")
                  }
            };
        }
    }
}
