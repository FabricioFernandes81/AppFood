using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IEnderecoRepositorio
    {
        Task<Endereco> UpdateEndereco(Endereco endereco);
        Task<Endereco> EnderecoById(string merchantId, string userId);
    }
}
