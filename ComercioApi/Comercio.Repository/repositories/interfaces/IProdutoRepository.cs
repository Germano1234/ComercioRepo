using Comercio.Repository.Repositories.Interfaces;
using Comercio.Domain;

namespace Comercio.Repository.Repositories.Interfaces
{
    public interface IProdutoRepository : IBaseRepository<Produto>
    {
        Task<List<Produto>> GetByValorAsync(decimal valor);
    }
}