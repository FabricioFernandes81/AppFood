using Domain.Entities;
using Domain.IRepositories;
using Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class EnderecoRepositorio : IEnderecoRepositorio
    {
        private readonly ContextServer _context;

        public EnderecoRepositorio(ContextServer context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context), "Context cannot be null");
        }

        public Task<Endereco> EnderecoById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Endereco> EnderecoById(string merchantId, string userId)
        {
            if (!Guid.TryParse(merchantId, out var guidMerchant))
                throw new ArgumentException("merchantId inválido");
            if (!Guid.TryParse(userId, out var guidUserId))
                throw new ArgumentException("Usuario inválido");

            var enderecoEntity = await _context.Enderecos
                .Where(e => e.Comercio.UUID == guidMerchant || e.Comercio.AspNetUsersId == guidUserId)
                .FirstOrDefaultAsync();

            return enderecoEntity;
        }


        public async Task<Endereco> UpdateEndereco(Endereco endereco)
        {
             _context.Update(endereco);
            var result = await _context.SaveChangesAsync();
            return result > 0 ? endereco : null;
        }
    }
}
