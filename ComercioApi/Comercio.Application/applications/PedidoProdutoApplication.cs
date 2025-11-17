using AutoMapper;
using Comercio.Application.Dtos.Request;
using Comercio.Application.Dtos.Response;
using Comercio.Application.Interfaces;
using Comercio.Application.Utils;
using Comercio.Application.Validators;
using Comercio.Domain;
using Comercio.Repository.Repositories.Interfaces;

namespace Comercio.Application.Applications
{
    public class PedidoProdutoApplication : IPedidoProdutoApplication
    {
        private IPedidoProdutoRepository _pedidoProdutoRepository;
        private IMapper _mapper;
        public PedidoProdutoApplication(IPedidoProdutoRepository pedidoProdutoRepository, IMapper mapper)
        {
            _pedidoProdutoRepository = pedidoProdutoRepository;
            _mapper = mapper;
        }
        public async Task<ApiResponse<PedidoProdutoResponseDto>> AddAsync(PedidoProdutoRequestDto pedidoProdutoRequest)
        {
            try
            {
                var pedidoProduto = _mapper.Map<PedidoProduto>(pedidoProdutoRequest);
                var respostaValidator = await ValidarPedidoProduto(pedidoProduto);

                if (!respostaValidator.Sucesso)
                {
                    return respostaValidator;
                }

                var pedidoProdutoResposta =  await _pedidoProdutoRepository.AddAsync(pedidoProduto);
                //Esse dado ja nao era do tipo PedidoProdutoResponseDto? Onde se add o que reconhece uma e outra.
                respostaValidator.Dado = _mapper.Map<PedidoProdutoResponseDto>(pedidoProdutoResposta);
                return respostaValidator;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao criar um pedidoProduto: {ex.Message}");
            }
        }

        public async Task<ApiResponse<PedidoProdutoResponseDto>> DeleteAsync(long id)
        {
            try
            {
                var pedidoProduto = await _pedidoProdutoRepository.GetByIdAsync(id);
                if (pedidoProduto == null)
                {
                    return new ApiResponse<PedidoProdutoResponseDto>(new List<string>() { "O pedidoProduto nao foi encontrado" });
                }

                await _pedidoProdutoRepository.DeleteAsync(pedidoProduto);
                return new ApiResponse<PedidoProdutoResponseDto>(_mapper.Map<PedidoProdutoResponseDto>(pedidoProduto = null));
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro inesperado ao deletar pedidoProduto: {ex.Message}");
            }
        }

        public async Task<ApiResponse<PedidoProdutosResponseDto>> GetAllAsync()
        {
            try
            {
                var pedidoProdutos = await _pedidoProdutoRepository.GetAllASync();
                var pedidoProdutosList = _mapper.Map<List<PedidoProdutoResponseDto>>(pedidoProdutos);
                var pedidoProdutosResponse = new PedidoProdutosResponseDto(pedidoProdutosList);
                return new ApiResponse<PedidoProdutosResponseDto>(pedidoProdutosResponse);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro inesperado ao listar todos pedidoProdutos: {ex.Message}");
            }
        }

        public async Task<ApiResponse<PedidoProdutoResponseDto>> GetByIDAsync(long id)
        {
            try
            {
                var pedidoProduto = await _pedidoProdutoRepository.GetByIdAsync(id);
                var pedidoProdutoResponse = _mapper.Map<PedidoProdutoResponseDto>(pedidoProduto);
                return new ApiResponse<PedidoProdutoResponseDto>(pedidoProdutoResponse);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro inesperado ao obter o pedidoProduto: {ex.Message}");
            }
        }

        public async Task<ApiResponse<PedidoProdutosResponseDto>> GetByPedidoIdAsync(long pedidoId)
        {
            try
            {
                var pedidoProdutos = await _pedidoProdutoRepository.GetByPedidoIdAsync(pedidoId);
                var pedidoProdutosList = _mapper.Map<List<PedidoProdutoResponseDto>>(pedidoProdutos);
                var pedidoProdutosResponse = new PedidoProdutosResponseDto(pedidoProdutosList);
                return new ApiResponse<PedidoProdutosResponseDto>(pedidoProdutosResponse);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro inesperado ao obter os pedidoProdutos: {ex.Message}");
            }
        }

        public async Task<ApiResponse<PedidoProdutosResponseDto>> GetByProdutoIdAsync(long produtoId)
        {
            try
            {
                var pedidoProdutos = await _pedidoProdutoRepository.GetByProdutoIdAsync(produtoId);
                var pedidoProdutosList = _mapper.Map<List<PedidoProdutoResponseDto>>(pedidoProdutos);
                var pedidoProdutosResponse = new PedidoProdutosResponseDto(pedidoProdutosList);
                return new ApiResponse<PedidoProdutosResponseDto>(pedidoProdutosResponse);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro inesperado ao obter os pedidoProdutos: {ex.Message}");
            }
        }

        public async Task<ApiResponse<PedidoProdutoResponseDto>> UpdateAsync(PedidoProdutoRequestDto pedidoProdutoRequest, long id)
        {
            try
            {
                var pedidoProdutoResponse = await _pedidoProdutoRepository.GetByIdAsync(id);
                if (pedidoProdutoResponse == null)
                {
                    return new ApiResponse<PedidoProdutoResponseDto>(new List<string>() { "O pedidoProduto nao foi encontrado" });
                }


                _mapper.Map(pedidoProdutoRequest, pedidoProdutoResponse);


                var resposta = await ValidarPedidoProduto(pedidoProdutoResponse);

                if (!resposta.Sucesso)
                {
                    return resposta;
                }

                pedidoProdutoResponse = await _pedidoProdutoRepository.UpdateAsync(pedidoProdutoResponse);
                resposta.Dado = _mapper.Map<PedidoProdutoResponseDto>(pedidoProdutoResponse);
                return resposta;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro inesperado ao atualizar pedidoProduto: {ex.Message}");
            }
        }

        #region utils
        private async Task<ApiResponse<PedidoProdutoResponseDto>> ValidarPedidoProduto(PedidoProduto pedidoProduto)
        {
            if (pedidoProduto == null)
            {
                return new ApiResponse<PedidoProdutoResponseDto>(new List<string>() { "PedidoProduto nao pode ser nulo" });
            }
            var validator = new PedidoProdutoValidator();

            var resposta = await validator.ValidateAsync(pedidoProduto);

            if (!resposta.IsValid)
            {

                return new ApiResponse<PedidoProdutoResponseDto>(resposta.Errors.Select(x => x.ErrorMessage).ToList());
            }
            return new ApiResponse<PedidoProdutoResponseDto>(_mapper.Map<PedidoProdutoResponseDto>(pedidoProduto));
        }
        #endregion
    }
}