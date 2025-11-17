using System.Dynamic;
using Comercio.Domain;

namespace Comercio.Application.Dtos.Response
{
    public class ProdutosResponseDto
    {
        public List<ProdutoResponseDto> Produtos { get; set; }

        public ProdutosResponseDto(List<ProdutoResponseDto> produtos)
        {
            Produtos = produtos;
        }

    }
}