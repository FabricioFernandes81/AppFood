using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IComercioRepositorio
    {
        public Task<IEnumerable<Comercio>> ObterTodosComerciosAsync(string AspNetUsersId);
        public Task<Comercio> ObterComercioPorIdAsync(string comercioId, string AspNetUsersId);

        public Task<Comercio> UpdateComercioAsync(Comercio comercio);
    }
}
