using Comercio.Application.Utils;
using Comercio.Application.Dtos.Request;
using Comercio.Application.Dtos.Response;
using Comercio.Domain;

namespace Comercio.Application.Interfaces
{
    public interface IProdutoApplication
    {
        Task<ApiResponse<ProdutoResponseDto>> AddAsync(ProdutoRequestDto produto);
        Task<ApiResponse<ProdutoResponseDto>> UpdateAsync(ProdutoRequestDto produtoRequest, long id);
        Task<ApiResponse<ProdutoResponseDto>>DeleteAsync(long id);
        Task<ApiResponse<ProdutoResponseDto>> GetByIDAsync(long Id);
        Task<ApiResponse<ProdutosResponseDto>> GetAllAsync();
        Task<ApiResponse<ProdutosResponseDto>> GetByValor(decimal valor);
    }
}