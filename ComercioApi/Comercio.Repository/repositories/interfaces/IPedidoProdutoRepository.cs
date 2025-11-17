using Comercio.Repository.Repositories.Interfaces;
using Comercio.Domain;

namespace Comercio.Repository.Repositories.Interfaces
{
    public interface IPedidoProdutoRepository : IBaseRepository<PedidoProduto>
    {
        Task<List<PedidoProduto>> GetByProdutoIdAsync(long produtoId);
        Task<List<PedidoProduto>> GetByPedidoIdAsync(long pedidoId);
    }
}