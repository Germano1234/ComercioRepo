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
    public class PedidoApplication : IPedidoApplication
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IMapper _mapper;
        public PedidoApplication(IPedidoRepository pedidoRepository, IMapper mapper)
        {
            _pedidoRepository = pedidoRepository;
            _mapper = mapper;
        }
        public async Task<ApiResponse<PedidoResponseDto>> AddAsync(PedidoRequestDto pedidoRequest)
        {
            try
            {
                var pedido = _mapper.Map<Pedido>(pedidoRequest);
                var respostaValidator = await ValidarPedido(pedido);

                if (!respostaValidator.Sucesso)
                {
                    return respostaValidator;
                }

                var pedidoResposta =  await _pedidoRepository.AddAsync(pedido);
                respostaValidator.Dado = _mapper.Map<PedidoResponseDto>(pedidoResposta);
                return respostaValidator;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao criar um pedido: {ex.Message}");
            }
        }

        public async Task<ApiResponse<PedidoResponseDto>> DeleteAsync(long id)
        {
            try
            {
                var pedido = await _pedidoRepository.GetByIdAsync(id);
                if (pedido == null)
                {
                    return new ApiResponse<PedidoResponseDto>(new List<string>() { "O pedido nao foi encontrado" });
                }

                await _pedidoRepository.DeleteAsync(pedido);
                return new ApiResponse<PedidoResponseDto>(_mapper.Map<PedidoResponseDto>(pedido = null));
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro inesperado ao deletar pedido: {ex.Message}");
            }
        }

        public async Task<ApiResponse<PedidosResponseDto>> GetAllAsync()
        {
            try
            {
                var pedidos = await _pedidoRepository.GetAllASync();
                var pedidosList = _mapper.Map<List<PedidoResponseDto>>(pedidos);
                var pedidosResponse = new PedidosResponseDto(pedidosList);
                return new ApiResponse<PedidosResponseDto>(pedidosResponse);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro inesperado ao listar todos pedodos: {ex.Message}");
            }
        }

        public async Task<ApiResponse<PedidosResponseDto>> GetByCliente(string nome)
        {
            try
            {
                var pedidos = await _pedidoRepository.GetByClienteAsync(nome);
                var pedidoList = _mapper.Map<List<PedidoResponseDto>>(pedidos);
                var pedidoResponse = new PedidosResponseDto(pedidoList);
                return new ApiResponse<PedidosResponseDto>(pedidoResponse);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro inesperado ao listar pedidos: {ex.Message}");
            }
        }

        public async Task<ApiResponse<PedidoResponseDto>> GetByIDAsync(long id)
        {
            try
            {
                var pedido = await _pedidoRepository.GetByIdAsync(id);
                var pedidoResponse = _mapper.Map<PedidoResponseDto>(pedido);
                return new ApiResponse<PedidoResponseDto>(pedidoResponse);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro inesperado ao obter o pedido: {ex.Message}");
            }
        }

        public async Task<ApiResponse<PedidoResponseDto>> UpdateAsync(PedidoRequestDto pedidoRequest, long id)
        {
            try
            {
                var pedidoResponse = await _pedidoRepository.GetByIdAsync(id);
                if (pedidoResponse == null)
                {
                    return new ApiResponse<PedidoResponseDto>(new List<string>() { "O pedido nao foi encontrado" });
                }


                _mapper.Map(pedidoRequest, pedidoResponse);


                var resposta = await ValidarPedido(pedidoResponse);

                if (!resposta.Sucesso)
                {
                    return resposta;
                }

                pedidoResponse = await _pedidoRepository.UpdateAsync(pedidoResponse);
                resposta.Dado = _mapper.Map<PedidoResponseDto>(pedidoResponse);
                return resposta;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro inesperado ao atualizar pedido: {ex.Message}");
            }
        }

        #region utils
        private async Task<ApiResponse<PedidoResponseDto>> ValidarPedido(Pedido pedido)
        {
            if (pedido == null)
            {
                return new ApiResponse<PedidoResponseDto>(new List<string>() { "Pedido nao pode ser nulo" });
            }
            var validator = new PedidoValidator();

            var resposta = await validator.ValidateAsync(pedido);

            if (!resposta.IsValid)
            {
                return new ApiResponse<PedidoResponseDto>(resposta.Errors.Select(x => x.ErrorMessage).ToList());
            }
            return new ApiResponse<PedidoResponseDto>(_mapper.Map<PedidoResponseDto>(pedido));
        }
        #endregion
    }
}