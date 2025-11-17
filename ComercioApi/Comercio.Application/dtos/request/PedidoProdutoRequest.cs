namespace Comercio.Application.Dtos.Request
{
    public class PedidoProdutoRequestDto
    {
        public long PedidoId { get; set; }
        public long ProdutoId { get; set; }
        public int Quantidade { get; set; }
    }
}