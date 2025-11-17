using System.Threading.Tasks;
using Comercio.Application.Utils;
using Comercio.Application.Validators;
using Comercio.Application.Dtos.Response;
using Comercio.Application.Interfaces;
using Comercio.Domain;
using Comercio.Repository.Repositories.Interfaces;
using Comercio.Application.Dtos.Request;
using AutoMapper;

namespace Comercio.Application.Applications
{
    public class ProdutoApplication : IProdutoApplication
    {
        private IProdutoRepository _produtoRepository;
        private IMapper _mapper;
        public ProdutoApplication(IProdutoRepository produtoRepository, IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }
        public async Task<ApiResponse<ProdutoResponseDto>> AddAsync(ProdutoRequestDto produtoRequest)
        {
            try
            {
                var produto = _mapper.Map<Produto>(produtoRequest);
                var resposta = await ValidarProduto(produto);

                if (!resposta.Sucesso)
                {
                    return resposta;
                }

                var produtoResponse = await _produtoRepository.AddAsync(produto);

                resposta.Dado = _mapper.Map<ProdutoResponseDto>(produtoResponse);
                return resposta;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro inesperado ao adicionar produto: {ex.Message}");
            }
        }

        public async Task<ApiResponse<ProdutoResponseDto>> DeleteAsync(long id)
        {
            try
            {
                var produto = await _produtoRepository.GetByIdAsync(id);
                if (produto == null)
                {
                    return new ApiResponse<ProdutoResponseDto>(new List<string>() { "O produto nao foi encontrado" });
                }

                await _produtoRepository.DeleteAsync(produto);
                return new ApiResponse<ProdutoResponseDto>(_mapper.Map<ProdutoResponseDto>(produto = null));
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro inesperado ao deletar um produto: {ex.Message}");
            }
        }

        public async Task<ApiResponse<ProdutosResponseDto>> GetAllAsync()
        {
            try
            {
                var produtos = await _produtoRepository.GetAllASync();
                var produtoList = _mapper.Map<List<ProdutoResponseDto>>(produtos);
                var produtoResponse = new ProdutosResponseDto(produtoList);
                return new ApiResponse<ProdutosResponseDto>(_mapper.Map<ProdutosResponseDto>(produtoResponse));
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro inesperado ao listar todos produtos: {ex.Message}");
            }
        }

        public async Task<ApiResponse<ProdutoResponseDto>> GetByIDAsync(long id)
        {
            try
            {
                var produto = await _produtoRepository.GetByIdAsync(id);
                var produtoResponse = _mapper.Map<ProdutoResponseDto>(produto);
                return new ApiResponse<ProdutoResponseDto>(produtoResponse);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro inesperado ao obter o produto: {ex.Message}");
            }
        }

        public async Task<ApiResponse<ProdutosResponseDto>> GetByValor(decimal valor)
        {
            try
            {
                var produtos = await _produtoRepository.GetByValorAsync(valor);
                var produtoList = _mapper.Map<List<ProdutoResponseDto>>(produtos);
                var produtoResponse = new ProdutosResponseDto(produtoList);
                return new ApiResponse<ProdutosResponseDto>(produtoResponse);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro inesperado ao listar todos produtos: {ex.Message}");
            }
        }

        public async Task<ApiResponse<ProdutoResponseDto>> UpdateAsync(ProdutoRequestDto produtoRequest, long id)
        {
            try
            {
                var produtoResponse = await _produtoRepository.GetByIdAsync(id);
                if (produtoResponse == null)
                {
                    return new ApiResponse<ProdutoResponseDto>(new List<string>() { "O produto nao foi encontrado" });
                }


                _mapper.Map(produtoRequest, produtoResponse);


                var resposta = await ValidarProduto(produtoResponse);

                if (!resposta.Sucesso)
                {
                    return resposta;
                }

                produtoResponse = await _produtoRepository.UpdateAsync(produtoResponse);
                resposta.Dado = _mapper.Map<ProdutoResponseDto>(produtoResponse);
                return resposta;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro inesperado ao atualizar produto: {ex.Message}");
            }
        }

        #region utils
        private async Task<ApiResponse<ProdutoResponseDto>> ValidarProduto(Produto produto)
        {
            if (produto == null)
            {
                return new ApiResponse<ProdutoResponseDto>(new List<string>() { "Produto nao pode ser nulo" });
            }
            var validator = new ProdutoValidator();

            var resposta = await validator.ValidateAsync(produto);

            if (!resposta.IsValid)
            {

                return new ApiResponse<ProdutoResponseDto>(resposta.Errors.Select(x => x.ErrorMessage).ToList());
            }
            return new ApiResponse<ProdutoResponseDto>(_mapper.Map<ProdutoResponseDto>(produto));
        }
        #endregion
    }
}

// Interface metodos de add, atualizar, deleta, getbyid, getall, obterporcliente.
// Pedido validator, mapping - classe pra outra (criar pedido responsedto e requestdto e pedidosresponsedto)
// Fazer na application
// Adicionar scope no program
// Fazer o controller.
