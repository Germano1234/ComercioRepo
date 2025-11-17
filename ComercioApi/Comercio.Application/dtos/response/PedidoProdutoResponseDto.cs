namespace Comercio.Application.Dtos.Response
{
    public class PedidoProdutoResponseDto
    {
        public long Id { get; set; }
        public long PedidoId { get; set; }
        public long ProdutoId { get; set; }
        public int Quantidade { get; set; }
    }
}