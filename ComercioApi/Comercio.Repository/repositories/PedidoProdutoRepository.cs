using Comercio.Domain;
using Comercio.Repository.Contexts;
using Comercio.Repository.Repositories;
using Comercio.Repository.Repositories.Interfaces;
using Dapper;
using Microsoft.EntityFrameworkCore;

namespace Comercio.Repository.Repositories
{
    public class PedidoProdutoRepository : BaseRepository<PedidoProduto>, IPedidoProdutoRepository
    {
        public PedidoProdutoRepository(Context context) : base(context) { }

        public async Task<List<PedidoProduto>> GetByProdutoIdAsync(long produtoId)
        {
            using (var connection = _context.Connection())
            {
                string sql = @$"
                    SELECT 
                        pp.*,
                        pe.*,
                        pr.*
                    FROM
                        PedidosProdutos pp
                    INNER JOIN Pedidos pe ON pp.PedidoId = pe.Id
                    INNER JOIN Produtos pr ON pp.ProdutoId = pr.Id
                    WHERE pp.ProdutoId = @produtoId;
                ";

                var resposta = await connection.QueryAsync<PedidoProduto, Pedido, Produto, PedidoProduto>(
                    sql,
                    (pp, pe, pr) =>
                    {
                        pp.Pedido = pe;
                        pp.Produto = pr;
                        return pp;
                    },
                    new {produtoId},
                    splitOn: "Id,Id"
                );
                return resposta.ToList();
            }
        }

        public async Task<List<PedidoProduto>> GetByPedidoIdAsync(long pedidoId)
        {
            var result = await _context.Set<PedidoProduto>().Where(x => x.PedidoId == pedidoId)
                                                          .Include(x => x.Produto)
                                                          .Include(x => x.Pedido)
                                                          .ToListAsync();
            return result;
            
        }
    }
}