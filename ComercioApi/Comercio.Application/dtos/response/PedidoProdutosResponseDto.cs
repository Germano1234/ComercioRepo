namespace Comercio.Application.Dtos.Response
{
    public class PedidoProdutosResponseDto
    {
        public List<PedidoProdutoResponseDto> PedidoProdutos { get; set; }
        public PedidoProdutosResponseDto(List<PedidoProdutoResponseDto> pedidos)
        {
            PedidoProdutos = pedidos;
        }
    }
}