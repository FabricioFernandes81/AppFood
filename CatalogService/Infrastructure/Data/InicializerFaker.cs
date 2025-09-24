
using Domain.Entities;
using Domain.Enuns;
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
            builder.Entity<Catalogo>().HasData(GetCatalogos());
            builder.Entity<Categoria>().HasData(GetCategorias());
            builder.Entity<Contexto>().HasData(GetContextos());
            builder.Entity<Item>().HasData(GetItems());
            builder.Entity<Produto>().HasData(GetProdutos());
            builder.Entity<GrupoOpcoes>().HasData(GetOpcoesGrupos());
            builder.Entity<ProdutoOpcoesGrupo>().HasData(GetProdutoOpcoesGrupo());
            builder.Entity<Opcoes>().HasData(GetOpcoes());
            builder.Entity<ModificacaoContextoItem>().HasData(GetModificacaoContextos());
            builder.Entity<CustomizacaoModificacoes>().HasData(GetCustomizacaoModificacoes());
        }

       

        private static List<Catalogo> GetCatalogos()
        {
            return new List<Catalogo>
            {
                new Catalogo
                {

                    CatalogoId = new Guid("50f8a1fc-1672-43e0-8746-aadcb005a3da"),
                    Nome = "Cardápio Principal",
                    Descricao = "Cardápio Principal do comércio",
                    Disponivel = true,
                    Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                    Tipo = Domain.Enuns.ResourceTipoCatalogo.DEFAULT,
                    CatalogoGrupo = new Guid("ffca0022-eb43-4205-9a1b-73a72f8e3f95"), // Grupo Padrão
                    ComercioId = new Guid("b1c8f3d2-4e5f-4b6a-9c7e-0d8f9a1b2c3d") , // Comercio D
                    DataCriacao = DateTime.Now,
                }
            };
        }
        private static List<Contexto> GetContextos()
        {
            return new List<Contexto>
            {
                new Contexto
                    {
                        Id = new Guid("0c5dfc17-fb38-44d5-8840-328e6b0c4293"),
                        CatalogoId= new Guid("50f8a1fc-1672-43e0-8746-aadcb005a3da"),
                        ContextoType = Domain.Enuns.ResourceTipoCatalogo.DEFAULT,
                    },new Contexto
                    {
                        Id = new Guid("53e952f7-6a1f-427b-8d82-156d48ec960e"),
                        CatalogoId= new Guid("50f8a1fc-1672-43e0-8746-aadcb005a3da"),
                        ContextoType = Domain.Enuns.ResourceTipoCatalogo.INDOOR,
                    }
            };
        }
        private static List<Categoria> GetCategorias()
        {
            return new List<Categoria>
            {
                   new Categoria
                   {

                       CategoriaId = new Guid("c1a5f8e2-3b6d-4f8e-9c7e-0d8f9a1b2c3d"),
                       Nome = "Pizzas Tradicionais",
                       Descricao = "Categoria de Pizzas Tradicionais",
                       Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                       DataCriacao = DateTime.Now,
                       Index = 0,
                       Tipo = Domain.Enuns.ResourceItemTipo.PIZZA,
                       CatalogoId = new Guid("50f8a1fc-1672-43e0-8746-aadcb005a3da"),

                   },new Categoria
                   {

                       CategoriaId = new Guid("d2b6f9e3-4c7e-5f9f-0d8f-1a2b3c4d5e6f"),
                       Nome = "Lanches Rápidos",
                       Descricao = "Categoria de Massas para Pizzas",
                       Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                       DataCriacao = DateTime.Now,
                       Index = 1,
                       Tipo = Domain.Enuns.ResourceItemTipo.DEFAULT,
                       CatalogoId = new Guid("50f8a1fc-1672-43e0-8746-aadcb005a3da"),

                   }/*,new Categoria
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
                   }*/
            };
        }

        private static List<Item> GetItems()
        {
            return new List<Item>
            {
                      new Item
                      {

                          ItemId = new Guid("289a4fbe-18b9-4506-b21f-2957f5919fbc"),
                          Tipo = Domain.Enuns.ResourceItemTipo.PIZZA,
                          Index = 0,
                          DataCriacao = DateTime.Now,
                          ProdutoId = new Guid("51b644cc-a90c-4456-992f-f86631176796"),
                          CategoriaId = new Guid("c1a5f8e2-3b6d-4f8e-9c7e-0d8f9a1b2c3d") // Categoria Pizzas
                      },
                      /////////////////////////////////////////////Items ////////////////////////////////////
                     new Item
                      {

                          ItemId = new Guid("56b5c746-57d8-4964-bc3b-46eb18658208"),
                          Tipo = Domain.Enuns.ResourceItemTipo.DEFAULT,
                          Index = 0,
                          DataCriacao = DateTime.Now,
                          ProdutoId = new Guid("62133b9f-5542-401d-8743-49ec7da8c847"), // X-Burger
                          CategoriaId = new Guid("d2b6f9e3-4c7e-5f9f-0d8f-1a2b3c4d5e6f") // Categoria Lanches Rápidos
                     }, new Item{
                         ItemId = new Guid("0c8eb292-8786-4707-8025-95a3d834da68"),
                         Tipo = Domain.Enuns.ResourceItemTipo.DEFAULT,
                         Index = 0,
                         DataCriacao = DateTime.Now,
                         ProdutoId = new Guid("ccea5142-1b90-40d9-b35d-72685950260b"),
                         CategoriaId = new Guid("d2b6f9e3-4c7e-5f9f-0d8f-1a2b3c4d5e6f")
                     }, new Item{
                         ItemId = new Guid("b8a99cea-8dbb-426a-bfe0-058fc44333f6"),
                         Tipo = Domain.Enuns.ResourceItemTipo.DEFAULT,
                         Index = 0,
                         DataCriacao = DateTime.Now,
                         ProdutoId = new Guid("4f3560c5-a6f3-40c9-885e-2e7e7ee4e9d0"),
                         CategoriaId = new Guid("d2b6f9e3-4c7e-5f9f-0d8f-1a2b3c4d5e6f")
                     }, new Item{
                         ItemId = new Guid("fa71f64b-55d1-4f50-91a7-5ce4d5b72ee5"),
                         Tipo = Domain.Enuns.ResourceItemTipo.DEFAULT,
                         Index = 0,
                         DataCriacao = DateTime.Now,
                         ProdutoId = new Guid("39b52e42-c21e-408b-9fa2-d2cccef926d1"),
                         CategoriaId = new Guid("d2b6f9e3-4c7e-5f9f-0d8f-1a2b3c4d5e6f")
                     }

            };
        }

        private static List<Produto> GetProdutos()
        {
            return new List<Produto>
            {

                new Produto{
                ProdutoId = new Guid("62133b9f-5542-401d-8743-49ec7da8c847"),
                Nome = "X-Burger",
                Descricao = "Hamburguer, Queijo, Presunto e Maionese",
                Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                IsIndustrializado = false,
                DataCriacao = DateTime.Now,
                Unidade = "g",
                Peso = 5,
                Ean = "7891234567890",
                RestriocaoAlimentar = null,
                Serving = Domain.Enuns.ResourceProdutoServer.SERVES_1,
                CatalogoId = new Guid("50f8a1fc-1672-43e0-8746-aadcb005a3da"),

                },new Produto
                {
                    ProdutoId = new Guid("ccea5142-1b90-40d9-b35d-72685950260b"),
                    Nome = "X-Salada",
                    Descricao = "",
                    Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                    IsIndustrializado = false,
                    DataCriacao = DateTime.Now,
                    Unidade = null,
                    Peso= 0,
                    Ean= null,
                    RestriocaoAlimentar = null,
                    Serving = Domain.Enuns.ResourceProdutoServer.SERVES_1,
                    CatalogoId = new Guid("50f8a1fc-1672-43e0-8746-aadcb005a3da"),
                },new Produto
                {
                    ProdutoId = new Guid("4f3560c5-a6f3-40c9-885e-2e7e7ee4e9d0"),
                    Nome = "X-Frango",
                    Descricao = "Milho, Tomate, Alface, Queijo, Hamburguer, Frango e Maionese",
                    Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                    IsIndustrializado = false,
                    DataCriacao = DateTime.Now,
                    Unidade = null,
                    Peso= 0,
                    Ean= null,
                    RestriocaoAlimentar = null,
                    Serving = Domain.Enuns.ResourceProdutoServer.SERVES_1,
                    CatalogoId = new Guid("50f8a1fc-1672-43e0-8746-aadcb005a3da")

                }, new Produto
                {
                    ProdutoId = new Guid("39b52e42-c21e-408b-9fa2-d2cccef926d1"),
                    Nome = "X- Gaúcho",
                    Descricao = "Milho, Tomate, Alface, Queijo, Carne e Maionese",
                    Status = Domain.Enuns.ResourceStatus.UNAVAILABLE,
                    IsIndustrializado = false,
                    DataCriacao = DateTime.Now,
                    Unidade = null,
                    Peso= 0,
                    Ean= null,
                    RestriocaoAlimentar = null,
                    Serving = Domain.Enuns.ResourceProdutoServer.SERVES_1,
                    CatalogoId = new Guid("50f8a1fc-1672-43e0-8746-aadcb005a3da")
                },new Produto
                {
                    ProdutoId= new Guid("8d86a76d-9585-440e-9482-457392deff8d"),
                    Nome = "Fritas P",
                    Descricao = null,
                    Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                    IsIndustrializado = false,
                    DataCriacao = DateTime.Now,
                    Unidade = "g",
                    Peso= 200,
                    Ean= null,
                    RestriocaoAlimentar = null,
                    Serving = Domain.Enuns.ResourceProdutoServer.SERVES_1,
                    CatalogoId= new Guid("50f8a1fc-1672-43e0-8746-aadcb005a3da")
                },new Produto
                {
                    ProdutoId= new Guid("a36cbbdf-7c06-4bde-8cf3-e99efc7603fa"),
                    Nome = "Bife",
                    Descricao = null,
                    Status = Domain.Enuns.ResourceStatus.UNAVAILABLE,
                    IsIndustrializado = false,
                    DataCriacao = DateTime.Now,
                    Unidade = null,
                    Peso = 0,
                    Ean= null,
                    RestriocaoAlimentar = null,
                    Serving = Domain.Enuns.ResourceProdutoServer.NOT_APPLICABLE,
                    CatalogoId= new Guid("50f8a1fc-1672-43e0-8746-aadcb005a3da")
                }
                ///////////////////////////////-Pizza Tradicionais/////////////////////////////////////
                ,new Produto
                {

                ProdutoId = new Guid("51b644cc-a90c-4456-992f-f86631176796"),
                Nome = "Pizzas Tradicionais",
                Descricao = null,
                Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                IsIndustrializado = false,
                DataCriacao = DateTime.Now,
                Unidade = "kg",
                Peso = 10,
                CatalogoId = new Guid("50f8a1fc-1672-43e0-8746-aadcb005a3da")
                },
                //--------------------------Pizza Tradicionais Tamanhos--------------------------------////////////
                new Produto
                    {
                        ProdutoId = new Guid("27fa98cd-e119-432d-9b0a-8f99a65be1b7"),
                        Nome = "Tamanho Médio",
                        Descricao = null,
                        Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                        IsIndustrializado = false,
                        DataCriacao = DateTime.Now,
                        Unidade = "g",
                        Peso = 5,
                        CatalogoId = new Guid("50f8a1fc-1672-43e0-8746-aadcb005a3da")
                    },new Produto{
                        ProdutoId = new Guid("932e18a2-396d-40d2-8de4-da0cf8f95faf"),
                        Nome = "Tamanho Grande",
                        Descricao = null,
                        Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                        IsIndustrializado = false,
                        DataCriacao = DateTime.Now,
                        Unidade = "g",
                        Peso = 5,
                        CatalogoId = new Guid("50f8a1fc-1672-43e0-8746-aadcb005a3da")
                        },
                    //--------------------------Pizza Tradicionais Massas--------------------------------////////////
             
                    new Produto
                    {
                        
                        ProdutoId = new Guid("9f72cd07-4463-4bfc-8fc1-97129c775e21"),
                        Nome = "Massa Tradicional",
                        Descricao = null,
                        Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                        IsIndustrializado = false,
                        DataCriacao = DateTime.Now,
                        Unidade = "g",
                        Peso = 5,
                        CatalogoId = new Guid("50f8a1fc-1672-43e0-8746-aadcb005a3da")
                    },new Produto
                    {
                        ProdutoId = new Guid("c8eff6c6-f3c5-48ec-9a5b-aa5b3eeec582"),
                        Nome = "Massa fina",
                        Descricao = null,
                        Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                        IsIndustrializado = false,
                        DataCriacao = DateTime.Now,
                        Unidade = "g",
                        Peso = 5,
                        CatalogoId = new Guid("50f8a1fc-1672-43e0-8746-aadcb005a3da")
                    },  
                    //-----------------------------Pizza Tradicionais Bordas ----------------/
                    new Produto
                        {
                            
                            ProdutoId = new Guid("e4ac0247-33ed-476a-ae69-363f27fe0df7"),
                            Nome = "Borda Tradicional",
                            Descricao = null,
                            Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                            IsIndustrializado = false,
                            DataCriacao = DateTime.Now,
                            Unidade = "g",
                            Peso = 5,
                            CatalogoId = new Guid("50f8a1fc-1672-43e0-8746-aadcb005a3da"),
                        },new Produto{
                            
                            ProdutoId = new Guid("eb021b00-0fef-434b-9da5-77e4dbca047e"),
                            Nome = "Borda Recheada",
                            Descricao = null,
                            Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                            IsIndustrializado = false,
                            DataCriacao = DateTime.Now,
                            Unidade = "g",
                            Peso = 5,
                            CatalogoId = new Guid("50f8a1fc-1672-43e0-8746-aadcb005a3da"),
                        },new Produto{
                           
                            ProdutoId = new Guid("d6ae0c15-4db9-454e-868b-a9ec7719da5e"),
                            Nome = "Calabresa",
                            Descricao = null,
                            Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                            IsIndustrializado = false,
                            DataCriacao = DateTime.Now,
                            Unidade = "g",
                            Peso = 5,
                            CatalogoId = new Guid("50f8a1fc-1672-43e0-8746-aadcb005a3da"),
                        },new Produto{
                            
                            ProdutoId = new Guid("b4a093cc-7e4a-49d2-909a-fed1cc58c572"),
                            Nome = "Frango com Catupiry",
                            Descricao = null,
                            Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                            IsIndustrializado = false,
                            DataCriacao = DateTime.Now,
                            Unidade = "g",
                            Peso = 5,
                            CatalogoId = new Guid("50f8a1fc-1672-43e0-8746-aadcb005a3da"),
                        },/*new Produto{
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
                        }*/
            };
        }
        private static List<GrupoOpcoes> GetOpcoesGrupos()
        {
            return new List<GrupoOpcoes>
            {
                    new GrupoOpcoes
                    {

                        OpcaoGrupoId = new Guid("1e5e5eb5-84c7-4eca-b0c1-921860434f70"),
                        Min= 0,
                        Max = 1,
                        Nome = "Acompanhamentos",
                        Index = 0,
                        Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                        DataCriacao = DateTime.Now,
                        ResourceGroupoType = Domain.Enuns.ResourceGrupoType.INGREDIENTS,
                        // IDS OptiosIds

                    },new GrupoOpcoes
                    {
                        OpcaoGrupoId= new Guid("b5bcb329-4f23-4752-a738-4bfe7ed4bb46"),
                        Min= 0,
                        Max= 1,
                        Nome = "Turbine seu Lanche",
                        Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                        DataCriacao = DateTime.Now,
                        ResourceGroupoType = Domain.Enuns.ResourceGrupoType.INGREDIENTS,

                    },new GrupoOpcoes
                    {
                        OpcaoGrupoId = new Guid("15af8bd9-6d54-43f2-8c74-43d5d4da32d8"),
                        Min= 0,
                        Max = 1,
                        Nome = "Tamanhos",
                        Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                        DataCriacao = DateTime.Now,
                        Index = 0,
                        ResourceGroupoType = Domain.Enuns.ResourceGrupoType.SIZE
                        //IDs OptionsIds
                    },new GrupoOpcoes{

                        OpcaoGrupoId = new Guid("26b1a876-7ee4-4f15-9bb1-d33c840c5049"),
                        Min= 0,
                        Max = 1,
                        Nome = "Massas",
                        Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                        DataCriacao = DateTime.Now,
                        Index = 0,
                        ResourceGroupoType = Domain.Enuns.ResourceGrupoType.CRUST
                        //IDs OptionsIds
                    },new GrupoOpcoes{
                        OpcaoGrupoId = new Guid("668a93a9-704e-4036-a515-11e4ddbe4129"),
                        Min= 0,
                        Max = 5,
                        Nome = "Bordas",
                        Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                        DataCriacao = DateTime.Now,
                        Index = 0,
                        ResourceGroupoType = Domain.Enuns.ResourceGrupoType.EDGE
                        //IDs OptionsIds
                    },new GrupoOpcoes{
                        OpcaoGrupoId = new Guid("d1eed8e6-c1f0-4f09-a235-2d459bb33cbb"),
                        Min= 0,
                        Max = 1,
                        Nome = "Sabores",
                        Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                        DataCriacao = DateTime.Now,
                        Index = 0,
                        ResourceGroupoType = Domain.Enuns.ResourceGrupoType.TOPPING
                        //IDs OptionsIds
                    }/*,new GrupoOpcoes
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
                    }*/
            };
        }


       






        private static List<Opcoes> GetOpcoes()
        {
            return new List<Opcoes>
            {
                new Opcoes
                {
                    OpcaoId = new Guid("d76aca65-4303-4a4d-a046-4c93151a4d67"),
                    Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                    ProdutoId = new Guid("a36cbbdf-7c06-4bde-8cf3-e99efc7603fa"),
                    OpcoesGrupoId = new Guid("b5bcb329-4f23-4752-a738-4bfe7ed4bb46")
                },new Opcoes
                {
                    OpcaoId = new Guid("aecc1532-da5e-444f-8989-519012edf46e"),
                    Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                    ProdutoId = new Guid("8d86a76d-9585-440e-9482-457392deff8d"),
                    OpcoesGrupoId = new Guid("b5bcb329-4f23-4752-a738-4bfe7ed4bb46")
                },
                //----------------------------- Pizza Tradicional Tamanhos---------------------------//
                new Opcoes
                {
                        
                        OpcaoId = new Guid("945ef3bc-7741-4bec-a0ce-4660c09a564f"),
                        Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                        ProdutoId = new Guid("27fa98cd-e119-432d-9b0a-8f99a65be1b7"), // Tamanho Médio
                        OpcoesGrupoId = new Guid("15af8bd9-6d54-43f2-8c74-43d5d4da32d8"), // Tamanhos;
                        Fracoes = new List<int> { 1 }
                },new Opcoes
                {
                      
                        OpcaoId = new Guid("2587c76e-3aa3-45e6-95d9-35c21ac19f9d"),
                        Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                        ProdutoId = new Guid("932e18a2-396d-40d2-8de4-da0cf8f95faf"), // Tamanho Grande
                        OpcoesGrupoId = new Guid("15af8bd9-6d54-43f2-8c74-43d5d4da32d8"), // Tamanhos;
                        Fracoes = new List<int> { 1,2 }

                    }, 
                  //-------------------------------Massas------------------------------------
                    new Opcoes
                        {
                        OpcaoId = new Guid("7fb0eac3-43e5-41c6-860e-a38793db4988"),
                        Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                        ProdutoId = new Guid("9f72cd07-4463-4bfc-8fc1-97129c775e21"), // Massa Tradicional
                        OpcoesGrupoId = new Guid("26b1a876-7ee4-4f15-9bb1-d33c840c5049"), // Grupo Massas;
                        Fracoes = null,
                    },new Opcoes
                    {
                        OpcaoId = new Guid("d0d0df88-b276-4a21-ab14-063e8f0c3c5d"),
                        Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                        ProdutoId = new Guid("c8eff6c6-f3c5-48ec-9a5b-aa5b3eeec582"), // Massa Fina
                        OpcoesGrupoId = new Guid("26b1a876-7ee4-4f15-9bb1-d33c840c5049"), //Grupo Massas;
                        Fracoes = null,
                    },
                      //------------------Pizza Tradicionais Bordas --------------------------- 
                    new Opcoes
                    {
                       
                        OpcaoId = new Guid("cc71b438-523f-49ac-918a-82df71244f9b"),
                        Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                        ProdutoId = new Guid("e4ac0247-33ed-476a-ae69-363f27fe0df7"), // Borda Tradicional
                        OpcoesGrupoId = new Guid("668a93a9-704e-4036-a515-11e4ddbe4129"), // Bordas;
                        Fracoes = null,
                    },new Opcoes
                    {
                        
                        OpcaoId = new Guid("df8728b2-7773-486b-aa93-47627bdd0c54"),
                        Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                        ProdutoId = new Guid("eb021b00-0fef-434b-9da5-77e4dbca047e"), // Borda Recheada
                        OpcoesGrupoId = new Guid("668a93a9-704e-4036-a515-11e4ddbe4129"), // Bordas;
                        Fracoes = null,
                    },
                    /////////////////Pizza Tradicional Sabores ---------------------------//
                    new Opcoes
                    {
                        OpcaoId = new Guid("0d58a046-1871-433d-bd8d-2b33abfbfa70"),
                        Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                        ProdutoId = new Guid("d6ae0c15-4db9-454e-868b-a9ec7719da5e"), // Sabor Calabresa
                        OpcoesGrupoId = new Guid("d1eed8e6-c1f0-4f09-a235-2d459bb33cbb"), // Sabores;
                        Fracoes = null,
                        //Contexto: Pizza inteira ou Meia pizza (1/2) ou 1/3 ou 1/4

                    },new Opcoes
                    {
                        OpcaoId = new Guid("a4eb62d0-ca33-459e-82b1-4de25997ba9e"),
                        Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                        ProdutoId = new Guid("b4a093cc-7e4a-49d2-909a-fed1cc58c572"), // Sabor Frango com Catupiry
                        OpcoesGrupoId = new Guid("d1eed8e6-c1f0-4f09-a235-2d459bb33cbb"), // Sabores;
                        Fracoes = null,


                    },/*new Opcoes
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
                    }*/
            };
        }

        private static List<CustomizacaoModificacoes> GetCustomizacaoModificacoes()
        {
           
            return new List<CustomizacaoModificacoes>
            {
                new CustomizacaoModificacoes
                {
                    Id = new Guid("fe66f09c-aee6-4496-9771-6f6e3af407c8"),
                    customizationOptionId = new Guid("0d58a046-1871-433d-bd8d-2b33abfbfa70"),
                    parentCustomizationOptionId = new Guid("945ef3bc-7741-4bec-a0ce-4660c09a564f"),
                    Status = ResourceStatus.AVAILABLE,
                    ItemId = new Guid("289a4fbe-18b9-4506-b21f-2957f5919fbc"),
                },new CustomizacaoModificacoes
                {
                    Id = new Guid("40da28b6-2c2e-4392-ae97-f1101e1893f6"),
                    customizationOptionId = new Guid("0d58a046-1871-433d-bd8d-2b33abfbfa70"),
                    parentCustomizationOptionId = new Guid("2587c76e-3aa3-45e6-95d9-35c21ac19f9d"),
                    Status = ResourceStatus.AVAILABLE,
                    ItemId = new Guid("289a4fbe-18b9-4506-b21f-2957f5919fbc"),
                },new CustomizacaoModificacoes
                {
                    Id = new Guid("88cf4471-0899-47e3-89cd-6003ef006cb0"),
                    customizationOptionId = new Guid("a4eb62d0-ca33-459e-82b1-4de25997ba9e"),
                    parentCustomizationOptionId = new Guid("945ef3bc-7741-4bec-a0ce-4660c09a564f"),
                    Status = ResourceStatus.AVAILABLE,
                    ItemId = new Guid("289a4fbe-18b9-4506-b21f-2957f5919fbc"),
                },new CustomizacaoModificacoes
                {
                    Id = new Guid("147635af-235d-4e7c-a2c5-899fc6fe5ca8"),
                    customizationOptionId = new Guid("a4eb62d0-ca33-459e-82b1-4de25997ba9e"),
                    parentCustomizationOptionId = new Guid("2587c76e-3aa3-45e6-95d9-35c21ac19f9d"),
                    Status = ResourceStatus.AVAILABLE,
                    ItemId = new Guid("289a4fbe-18b9-4506-b21f-2957f5919fbc"),
                }
            };
        }

        //new Guid("b1c8f3d2-4e5f-4b6a-9c7e-0d8f9a1b2c3d")  Comercio D
        //



        #region Tabelas de Junções

        private static List<ProdutoOpcoesGrupo> GetProdutoOpcoesGrupo()
        {
            return new List<ProdutoOpcoesGrupo>
            {
                     new ProdutoOpcoesGrupo
                     {
                         ProdutoId =  new Guid("62133b9f-5542-401d-8743-49ec7da8c847"), // Xis - Burger
                         GrupoId = new Guid("1e5e5eb5-84c7-4eca-b0c1-921860434f70") //Aconpanhamentos, 

                     },new ProdutoOpcoesGrupo
                     {
                         ProdutoId =  new Guid("ccea5142-1b90-40d9-b35d-72685950260b"), // Xis - Salada
                         GrupoId = new Guid("b5bcb329-4f23-4752-a738-4bfe7ed4bb46") //Bebidas, 

                     }
                     ,new ProdutoOpcoesGrupo
                     {
                         ProdutoId = new Guid("51b644cc-a90c-4456-992f-f86631176796"), //Produto Pizzas Tradicionais
                         GrupoId = new Guid("15af8bd9-6d54-43f2-8c74-43d5d4da32d8"), // Grupo Tamanhos
                     },new ProdutoOpcoesGrupo
                     {
                         ProdutoId = new Guid("51b644cc-a90c-4456-992f-f86631176796"), //Produto Pizzas Tradicionais
                         GrupoId = new Guid("26b1a876-7ee4-4f15-9bb1-d33c840c5049"), // Grupo Massas

                     },new ProdutoOpcoesGrupo
                     {
                         ProdutoId = new Guid("51b644cc-a90c-4456-992f-f86631176796"), //Produto Pizzas Tradicionais
                         GrupoId = new Guid("668a93a9-704e-4036-a515-11e4ddbe4129"), // Grupo Bordas
                     },new ProdutoOpcoesGrupo
                     {
                         ProdutoId = new Guid("51b644cc-a90c-4456-992f-f86631176796"), //Produto Pizzas Tradicionais
                         GrupoId = new Guid("d1eed8e6-c1f0-4f09-a235-2d459bb33cbb"), // Grupo Sabores
                     }
                     /*,new ProdutoOpcoesGrupo
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
                     }*/
            };
        }

        public static List<ModificacaoContextoItem> GetModificacaoContextos()
        {
            return new List<ModificacaoContextoItem>
            {
                new ModificacaoContextoItem
                {
                    Id = Guid.NewGuid(),
                    CatalogoId = new Guid("50f8a1fc-1672-43e0-8746-aadcb005a3da"),
                    ItemId = new Guid("0c8eb292-8786-4707-8025-95a3d834da68"),
                    ContextoType = ResourceTipoCatalogo.DEFAULT,
                    Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                },new ModificacaoContextoItem
                {
                    Id = Guid.NewGuid(),
                    CatalogoId = new Guid("50f8a1fc-1672-43e0-8746-aadcb005a3da"),
                    ItemId = new Guid("0c8eb292-8786-4707-8025-95a3d834da68"),
                    ContextoType = ResourceTipoCatalogo.INDOOR,
                    Status = Domain.Enuns.ResourceStatus.UNAVAILABLE,
                },new ModificacaoContextoItem
                {
                    Id = Guid.NewGuid(),
                    CatalogoId = new Guid("50f8a1fc-1672-43e0-8746-aadcb005a3da"),
                    ItemId = new Guid("b8a99cea-8dbb-426a-bfe0-058fc44333f6"),
                    ContextoType = ResourceTipoCatalogo.DEFAULT,
                    Status = ResourceStatus.AVAILABLE,
                },new ModificacaoContextoItem
                {
                    Id = Guid.NewGuid(),
                    CatalogoId = new Guid("50f8a1fc-1672-43e0-8746-aadcb005a3da"),
                    ItemId = new Guid("b8a99cea-8dbb-426a-bfe0-058fc44333f6"),
                    ContextoType = ResourceTipoCatalogo.INDOOR,
                    Status = ResourceStatus.UNAVAILABLE,
                },new ModificacaoContextoItem
                {
                    Id = Guid.NewGuid(),
                    CatalogoId = new Guid("50f8a1fc-1672-43e0-8746-aadcb005a3da"),
                    ItemId = new Guid("56b5c746-57d8-4964-bc3b-46eb18658208"),
                    ContextoType = ResourceTipoCatalogo.DEFAULT,
                    Status = ResourceStatus.UNAVAILABLE,
                },new ModificacaoContextoItem
                {
                    Id = Guid.NewGuid(),
                    CatalogoId = new Guid("50f8a1fc-1672-43e0-8746-aadcb005a3da"),
                    ItemId = new Guid("56b5c746-57d8-4964-bc3b-46eb18658208"),
                    ContextoType = ResourceTipoCatalogo.INDOOR,
                    Status = ResourceStatus.UNAVAILABLE,
                },new ModificacaoContextoItem
                {
                    Id = Guid.NewGuid(),
                    CatalogoId = new Guid("50f8a1fc-1672-43e0-8746-aadcb005a3da"),
                    ItemId = new Guid("fa71f64b-55d1-4f50-91a7-5ce4d5b72ee5"),
                    ContextoType = ResourceTipoCatalogo.DEFAULT,
                    Status = ResourceStatus.AVAILABLE,
                },new ModificacaoContextoItem
                {
                    Id = Guid.NewGuid(),
                    CatalogoId = new Guid("50f8a1fc-1672-43e0-8746-aadcb005a3da"),
                    ItemId = new Guid("fa71f64b-55d1-4f50-91a7-5ce4d5b72ee5"),
                    ContextoType = ResourceTipoCatalogo.INDOOR,
                    Status = ResourceStatus.AVAILABLE,
                },//
                new ModificacaoContextoItem
                {
                    Id = Guid.NewGuid(),
                    CatalogoId = new Guid("50f8a1fc-1672-43e0-8746-aadcb005a3da"),
                    ItemId = new Guid("289a4fbe-18b9-4506-b21f-2957f5919fbc"),
                    ContextoType = ResourceTipoCatalogo.DEFAULT,
                    Status = Domain.Enuns.ResourceStatus.AVAILABLE,
                },new ModificacaoContextoItem
                {
                    Id = Guid.NewGuid(),
                    CatalogoId = new Guid("50f8a1fc-1672-43e0-8746-aadcb005a3da"),
                    ItemId = new Guid("289a4fbe-18b9-4506-b21f-2957f5919fbc"),
                    ContextoType = ResourceTipoCatalogo.INDOOR,
                    Status = Domain.Enuns.ResourceStatus.UNAVAILABLE,
                }
            };
        }
        
        #endregion
    }
}
