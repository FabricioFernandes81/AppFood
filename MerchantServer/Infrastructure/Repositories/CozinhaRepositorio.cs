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
    public class CozinhaRepositorio : ICozinhaRepositorio
    {
        private readonly ContextServer _contextServer;

        public CozinhaRepositorio(ContextServer contextServer)
        {
            _contextServer = contextServer ?? throw new ArgumentNullException(nameof(contextServer), "Context cannot be null");
        }
        public async Task<List<Cozinha>> GetCuisinesAsync()
        {
           var cuisines = await _contextServer.Cozinhas.ToListAsync();
            
            return cuisines;
        }
    }
}
