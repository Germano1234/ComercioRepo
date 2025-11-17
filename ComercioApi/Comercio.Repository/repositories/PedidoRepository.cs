using Comercio.Domain;
using Comercio.Repository.Contexts;
using Comercio.Repository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Comercio.Repository.Repositories
{
    public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(Context context) : base(context){ }

        public async Task<List<Pedido>> GetByClienteAsync(string cliente)
        {
            var respost = await _context.Set<Pedido>().Where(x => x.Cliente.Contains(cliente)).ToListAsync();
            return respost;
        }
    }
}