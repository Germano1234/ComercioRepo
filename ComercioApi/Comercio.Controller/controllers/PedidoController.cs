using Comercio.Domain;
using Microsoft.AspNetCore.Mvc;
using Comercio.Application.Interfaces;
using Comercio.Application.Dtos.Request;

namespace Comercio.Controller.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoApplication _pedidoApplication;
        public PedidoController(IPedidoApplication pedidoApplication)
        {
            _pedidoApplication = pedidoApplication;
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] PedidoRequestDto pedidoRequest)
        {
            try
            {

                var pedido = await _pedidoApplication.AddAsync(pedidoRequest);
                return Ok(pedido);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> updateAsync([FromBody] PedidoRequestDto pedidoRequest, [FromRoute] long id)
        {
            try
            {
                var pedido = await _pedidoApplication.UpdateAsync(pedidoRequest, id);
                return Ok(pedido);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] long id)
        {
            try
            {
                var pedido = await _pedidoApplication.GetByIDAsync(id);
                return Ok(pedido);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var pedido = await _pedidoApplication.GetAllAsync();
                return Ok(pedido);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("cliente")]
        public async Task<IActionResult> GetByClienteAsync([FromQuery] string cliente)
        {
            try
            {
                var pedido = await _pedidoApplication.GetByCliente(cliente);
                return Ok(pedido);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] long id)
        {
            try
            {
                var pedido = await _pedidoApplication.DeleteAsync(id);
                return Ok(pedido);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}