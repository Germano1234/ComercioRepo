using Comercio.Application.Dtos.Request;
using Comercio.Application.Dtos.Response;
using Comercio.Application.Utils;

namespace Comercio.Application.Interfaces
{
    public interface IPedidoProdutoApplication
    {
        Task<ApiResponse<PedidoProdutoResponseDto>> AddAsync(PedidoProdutoRequestDto pedidoProduto);
        Task<ApiResponse<PedidoProdutoResponseDto>> UpdateAsync(PedidoProdutoRequestDto pedidoProdutoRequest, long id);
        Task<ApiResponse<PedidoProdutoResponseDto>> DeleteAsync(long id);
        Task<ApiResponse<PedidoProdutoResponseDto>> GetByIDAsync(long id);
        Task<ApiResponse<PedidoProdutosResponseDto>> GetAllAsync();
        Task<ApiResponse<PedidoProdutosResponseDto>> GetByProdutoIdAsync(long produtoId);
        Task<ApiResponse<PedidoProdutosResponseDto>> GetByPedidoIdAsync(long pedidoId);

    }
}