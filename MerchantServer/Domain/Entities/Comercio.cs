using Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Comercio
    {
        public int Id { get; set; }
        public Guid UUID { get; set; }
        public Guid AspNetUsersId { get; set; }

        public string Nome { get; set; }
        public string NomeFantasia { get; set; }
        public string Descricao { get; set; }
        public ResourceTipo Tipo { get; set; }
        public ResourceStatus Status { get; set; }
        public string TelefoneEntrega { get; set; }
        public Endereco Endereco { get; set; }
        public DateTime DataCriacao { get; set; }

        public string CozinhaCode { get; set; }
        public Cozinha Cozinha { get; set; }
    }
}
