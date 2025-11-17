using AutoMapper;
using Comercio.Application.Dtos.Request;
using Comercio.Application.Dtos.Response;
using Comercio.Domain;
namespace Comercio.Application.Utils
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Produto, ProdutoResponseDto>();
            CreateMap<ProdutoRequestDto, Produto>();
            CreateMap<PedidoRequestDto, Pedido>();
            CreateMap<Pedido, PedidoResponseDto>();
            CreateMap<PedidoProdutoRequestDto, PedidoProduto>();
            CreateMap<PedidoProduto, PedidoProdutoResponseDto>();
        }
    }
}
