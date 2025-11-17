namespace Comercio.Application.Dtos.Response
{
    public class PedidosResponseDto
    {
        public List<PedidoResponseDto> Pedidos { get; set; }

        public PedidosResponseDto(List<PedidoResponseDto> pedidos)
        {
            Pedidos = pedidos;
        }
    }
}