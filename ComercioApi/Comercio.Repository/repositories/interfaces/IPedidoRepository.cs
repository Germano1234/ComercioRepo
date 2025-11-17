using Comercio.Repository.Repositories.Interfaces;
using Comercio.Domain;

namespace Comercio.Repository.Repositories.Interfaces
{
    public interface IPedidoRepository : IBaseRepository<Pedido>
    {
        Task<List<Pedido>> GetByClienteAsync(string cliente);
    }
}