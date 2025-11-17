using Comercio.Application.Dtos.Request;
using Comercio.Application.Dtos.Response;
using Comercio.Application.Utils;

namespace Comercio.Application.Interfaces
{
    public interface IPedidoApplication
    {
        Task<ApiResponse<PedidoResponseDto>> AddAsync(PedidoRequestDto pedido);
        Task<ApiResponse<PedidoResponseDto>> UpdateAsync(PedidoRequestDto pedidoRequest, long id);
        Task<ApiResponse<PedidoResponseDto>> DeleteAsync(long id);
        Task<ApiResponse<PedidoResponseDto>> GetByIDAsync(long id);
        Task<ApiResponse<PedidosResponseDto>> GetAllAsync();
        Task<ApiResponse<PedidosResponseDto>> GetByCliente(string nome);
        
    }
}