using Comercio.Domain;

namespace Comercio.Application.Dtos.Response
{
    public class ProdutoResponseDto
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }

    }
}