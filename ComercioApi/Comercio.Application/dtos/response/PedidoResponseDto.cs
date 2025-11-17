namespace Comercio.Application.Dtos.Response
{
    public class PedidoResponseDto
    {
        public long Id { get; set; }
        public DateTime DataPedido { get; set; }
        public string Cliente { get; set; }
    }
}