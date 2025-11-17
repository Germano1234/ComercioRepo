using Comercio.Domain;
using Comercio.Repository.Contexts;
using Comercio.Repository.Repositories.Interfaces;
using Dapper;

namespace Comercio.Repository.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(Context context) : base(context) { }

        public async Task<List<Produto>> GetByValorAsync(decimal valor)
        {
            using (var connection = _context.Connection())
            {
                string sql = "SELECT * FROM Produtos WHERE Valor = @preco";
                var parametros = 
                new {
                    preco = valor
                };
                return (await connection.QueryAsync<Produto>(sql,parametros)).ToList(); 
            }
        }
    }
}