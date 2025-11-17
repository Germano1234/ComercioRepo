using Comercio.Domain;
using Microsoft.AspNetCore.Mvc;
using Comercio.Application.Interfaces;
using Comercio.Application.Dtos.Request;

namespace Comercio.Controller.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoProdutoController : ControllerBase
    {
        private readonly IPedidoProdutoApplication _pedidoProdutoApplication;
        public PedidoProdutoController(IPedidoProdutoApplication pedidoProdutoApplication)
        {
            _pedidoProdutoApplication = pedidoProdutoApplication;
        }
        [HttpPost]
        public async Task<IActionResult> GetAsync([FromBody] PedidoProdutoRequestDto pedidoProdutoRequest)
        {
            try
            {

                var pedidoProduto = await _pedidoProdutoApplication.AddAsync(pedidoProdutoRequest);
                return Ok(pedidoProduto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateAsync([FromBody] PedidoProdutoRequestDto pedidoProdutoRequest, [FromRoute] long id)
        {
            try
            {
                var pedidoProduto = await _pedidoProdutoApplication.UpdateAsync(pedidoProdutoRequest, id);
                return Ok(pedidoProduto);
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
                var pedidoProduto = await _pedidoProdutoApplication.GetByIDAsync(id);
                return Ok(pedidoProduto);
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
                var pedidoProduto = await _pedidoProdutoApplication.GetAllAsync();
                return Ok(pedidoProduto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("PedidoId")]
        public async Task<IActionResult> GetByPedidoIdAsync([FromQuery] long pedidoId)
        {
            try
            {
                var pedidoProduto = await _pedidoProdutoApplication.GetByPedidoIdAsync(pedidoId);
                return Ok(pedidoProduto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("ProdutoId")]
        public async Task<IActionResult> GetByProdutoIdAsync([FromQuery] long produtoId)
        {
            try
            {
                var pedidoProduto = await _pedidoProdutoApplication.GetByProdutoIdAsync(produtoId);
                return Ok(pedidoProduto);
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
                var pedidoProduto = await _pedidoProdutoApplication.DeleteAsync(id);
                return Ok(pedidoProduto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}