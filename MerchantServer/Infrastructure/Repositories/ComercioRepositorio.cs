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
    public class ComercioRepositorio : IComercioRepositorio
    {
        private readonly ContextServer _contextServer;

        public ComercioRepositorio(ContextServer contextServer)
        {
            _contextServer = contextServer;
        }

        public async Task<Comercio> ObterComercioPorIdAsync(string comercioId, string AspNetUsersId)
        {
            if (!Guid.TryParse(AspNetUsersId, out Guid aspNetUsersGuid))
                return (Comercio)Enumerable.Empty<Comercio>();

            var commercio = await _contextServer.Comercio
                .Where(c => c.AspNetUsersId == aspNetUsersGuid && c.UUID.ToString() == comercioId)
                .Include(end=> end.Endereco)
                .Include(coz => coz.Cozinha)
                .FirstOrDefaultAsync();

            return commercio;
        }

        public async Task<IEnumerable<Comercio>> ObterTodosComerciosAsync(string AspNetUsersId)
        {
            // Converte AspNetUsersId para Guid antes de comparar
            if (!Guid.TryParse(AspNetUsersId, out Guid aspNetUsersGuid))
                return Enumerable.Empty<Comercio>();

            var comercios = await _contextServer.Comercio
                .Where(c => c.AspNetUsersId == aspNetUsersGuid)
                .ToListAsync();

            return comercios;
        }

        public async Task<Comercio> UpdateComercioAsync(Comercio comercio)
        {
            if (comercio != null)
            {
                _contextServer.Comercio.Update(comercio);
                 var result = await _contextServer.SaveChangesAsync();
                return comercio;
            }
            return null;
        }
    }
}
