using Comercio.Domain;

namespace Comercio.Application.Dtos.Request
{
    public class ProdutoRequestDto
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
    }
}