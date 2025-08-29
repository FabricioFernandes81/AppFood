using Domain.Entities;
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

            builder.Entity<Domain.Entities.Comercio>().
                HasData(CreateComercio());
            builder.Entity<Domain.Entities.Endereco>().
                HasData(GetEndereco());
            builder.Entity < Domain.Entities.Cozinha>().HasData(GetCozinha()) ;
        }

        private static List<Cozinha> GetCozinha()
        {
            return new List<Cozinha>()
            {
                new Cozinha { Code = "AC1", Name = "Açaí" },
                new Cozinha { Code = "AF1", Name = "Africana" },
                new Cozinha { Code = "ALE", Name = "Alemã" },
                new Cozinha { Code = "ARA", Name = "Árabe" },
                new Cozinha { Code = "AR1", Name = "Argentina" },
                new Cozinha { Code = "ASI", Name = "Asiática" },
                new Cozinha { Code = "BA1", Name = "Baiana" },
                new Cozinha { Code = "BRA", Name = "Brasileira" },
                new Cozinha { Code = "CA1", Name = "Cafeteria" },
                new Cozinha { Code = "CAR", Name = "Carnes" },
                new Cozinha { Code = "CS1", Name = "Casa de Sucos" },
                new Cozinha { Code = "CHI", Name = "Chinesa" },
                new Cozinha { Code = "CO1", Name = "Colombiana" },
                new Cozinha { Code = "CN1", Name = "Congelados" },
                new Cozinha { Code = "CF1", Name = "Congelados Fit" },
                new Cozinha { Code = "CNT", Name = "Contemporânea" },
                new Cozinha { Code = "CR1", Name = "Coreana" },
                new Cozinha { Code = "CRP", Name = "Cozinha Rápida" },
                new Cozinha { Code = "CP1", Name = "Crepe" },
                new Cozinha { Code = "DCE", Name = "Doces & Bolos" },
                new Cozinha { Code = "ES1", Name = "Espanhola" },
                new Cozinha { Code = "FRA", Name = "Francesa" },
                new Cozinha { Code = "FR1", Name = "Frangos" },
                new Cozinha { Code = "FRU", Name = "Frutos Do Mar" },
                new Cozinha { Code = "GA1", Name = "Gaúcha" },
                new Cozinha { Code = "GRC", Name = "Grega" },
                new Cozinha { Code = "BUR", Name = "Hambúrguer" },
                new Cozinha { Code = "IND", Name = "Indiana" },
                new Cozinha { Code = "ITA", Name = "Italiana" },
                new Cozinha { Code = "JAP", Name = "Japonesa" },
                new Cozinha { Code = "LCH", Name = "Lanches" },
                new Cozinha { Code = "MA1", Name = "Marmita" },
                new Cozinha { Code = "MAR", Name = "Marroquina" },
                new Cozinha { Code = "MED", Name = "Mediterrânea" },
                new Cozinha { Code = "MEX", Name = "Mexicana" },
                new Cozinha { Code = "MI1", Name = "Mineira" },
                new Cozinha { Code = "NO1", Name = "Nordestina" },
                new Cozinha { Code = "PA1", Name = "Padaria" },
                new Cozinha { Code = "PQC", Name = "Panqueca" },
                new Cozinha { Code = "PR1", Name = "Paranaense" },
                new Cozinha { Code = "PAS", Name = "Pastel" },
                new Cozinha { Code = "PX1", Name = "Peixes" },
                new Cozinha { Code = "PER", Name = "Peruana" },
                new Cozinha { Code = "PIZ", Name = "Pizza" },
                new Cozinha { Code = "POR", Name = "Portuguesa" },
                new Cozinha { Code = "PRE", Name = "Presentes" },
                new Cozinha { Code = "SAG", Name = "Salgados" },
                new Cozinha { Code = "SAU", Name = "Saudável" },
                new Cozinha { Code = "SP1", Name = "Sopas & Caldos" },
                new Cozinha { Code = "SOR", Name = "Sorvetes" },
                new Cozinha { Code = "THA", Name = "Tailandesa" },
                new Cozinha { Code = "TA1", Name = "Tapioca" },
                new Cozinha { Code = "TN1", Name = "Típica do Norte" },
                new Cozinha { Code = "VAR", Name = "Variada" },
                new Cozinha { Code = "VE1", Name = "Vegana" },
                new Cozinha { Code = "VEG", Name = "Vegetariana" },
                new Cozinha { Code = "XI1", Name = "Xis" },
                new Cozinha { Code = "YA1", Name = "Yakisoba" }

            };
        }

        private static List<Endereco> GetEndereco()
        {
            return new List<Endereco>
            {
                new Endereco
                {
                    ComercioId = 1,
                    Logradouro = "Rua A",
                    Numero = "123",
                    Bairro = "Bairro A",
                    Cidade = "Cidade A",
                    Estado = "Estado A",
                    CEP = "12345678",
                    Pais = "BR",
                    Latitude = -9.827597,
                    Longitude = -67.951077

                },
                new Endereco
                {
                    ComercioId = 2,
                    Logradouro = "Rua B",
                    Numero = "456",
                    Bairro = "Bairro B",
                    Cidade = "Cidade B",
                    Estado = "Estado B",
                    CEP = "23456789",
                    Pais = "BR",
                    Latitude = -9.827597,
                    Longitude = -67.951077
                },
                new Endereco
                {
                    ComercioId = 3,
                    Logradouro = "Rua C",
                    Numero = "789",
                    Bairro = "Bairro C",
                    Cidade = "Cidade C",
                    Estado = "Estado C",
                    CEP = "34567890",
                    Pais = "BR",
                    Latitude = -9.827597,
                    Longitude = -67.951077
                },
                new Endereco
                {
                    ComercioId = 4,
                    Logradouro = "Rua D",
                    Numero = "1011",
                    Bairro = "Bairro D",
                    Cidade = "Cidade D",
                    Estado = "Estado D",
                    CEP = "45678901",
                    Pais = "BR",
                    Latitude = -9.827597,
                    Longitude = -67.951077,
                   
                }
            };
        }

        private static List<Comercio> CreateComercio()
        {
            return new List<Comercio>
            {
                new Comercio
                {
                    Id = 1,
                    Nome = "Comercio A",
                    NomeFantasia = "Comercio A Fantasia",
                    UUID = new Guid("13e2f21a-4283-4ff8-bb7a-096e7b89e0f0"),
                    Descricao = "Descricao do Comercio A",
                    Tipo = Domain.Entities.Enums.ResourceTipo.RESTAURANT,
                    Status = Domain.Entities.Enums.ResourceStatus.AVAILABLE,
                    DataCriacao = DateTime.UtcNow,
                    AspNetUsersId = Guid.Parse("97aa75c4-1a41-4a20-a1d0-4fe1f1f5129b"), // User Client
                    CozinhaCode = "AC1", // Açaí
                    TelefoneEntrega = "1234567890"
                },new Comercio
                {
                    Id = 2,
                    Nome = "Comercio B",
                    NomeFantasia = "Comercio B Fantasia",
                    UUID = new Guid("283264d6-0e5e-48fe-9d6e-b1599aa0892c"),
                    Descricao = "Descricao do Comercio B",
                    Tipo = Domain.Entities.Enums.ResourceTipo.RESTAURANT,
                    Status = Domain.Entities.Enums.ResourceStatus.AVAILABLE,
                    DataCriacao = DateTime.UtcNow,
                    AspNetUsersId = Guid.Parse("97aa75c4-1a41-4a20-a1d0-4fe1f1f5129b"), // User Client
                    CozinhaCode = "AF1", // Africana
                    TelefoneEntrega = "0987654321"
                },new Comercio
                {
                    Id = 3,
                    Nome = "Comercio A",
                    NomeFantasia = "Comercio A Fantasia",
                    UUID = new Guid("7cd0d373-c57d-4c70-aa8c-22791983fe1c"),
                    Descricao = "Descricao do Comercio C",
                    Tipo = Domain.Entities.Enums.ResourceTipo.RESTAURANT,
                    Status = Domain.Entities.Enums.ResourceStatus.AVAILABLE,
                    DataCriacao = DateTime.UtcNow,
                    AspNetUsersId = Guid.Parse("97aa75c4-1a41-4a20-a1d0-4fe1f1f5129b"), // User Client
                    CozinhaCode = "ALE", // Alemã
                    TelefoneEntrega = "1122334455"
                },new Comercio
                {
                    Id = 4,
                    Nome = "Comercio D",
                    NomeFantasia = "Comercio D Fantasia",
                    UUID = new Guid("b1c8f3d2-4e5f-4b6a-9c7e-0d8f9a1b2c3d"),
                    Descricao = "Descricao do Comercio D",
                    Tipo = Domain.Entities.Enums.ResourceTipo.RESTAURANT,
                    Status = Domain.Entities.Enums.ResourceStatus.AVAILABLE,
                    DataCriacao = DateTime.UtcNow,
                    AspNetUsersId = Guid.Parse("6377641f-33f7-4997-944c-997cc9d63d88"), // User Admin
                    CozinhaCode = "LCH", // Lanches
                    TelefoneEntrega = "2233445566"
                }

            };
        }
    }
}
