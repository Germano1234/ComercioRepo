using Comercio.Domain;
using Microsoft.AspNetCore.Mvc;
using Comercio.Application.Interfaces;
using Comercio.Application.Dtos.Request;

namespace Comercio.Controller.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoApplication _produtoApplication;
        public ProdutoController(IProdutoApplication produtoApplication)
        {
            _produtoApplication = produtoApplication;
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] ProdutoRequestDto produtoRequest)
        {
            try
            {

                var produtos = await _produtoApplication.AddAsync(produtoRequest);
                return Ok(produtos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateAsync([FromBody] ProdutoRequestDto produtoRequest, [FromRoute] long id)
        {
            try
            {
                var produto = await _produtoApplication.UpdateAsync(produtoRequest, id);
                return Ok(produto);
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
                var produto = await _produtoApplication.GetByIDAsync(id);
                return Ok(produto);
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
                var produto = await _produtoApplication.GetAllAsync();
                return Ok(produto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("valor")]
        public async Task<IActionResult> GetByValorAsync([FromQuery] decimal valor)
        {
            try
            {
                var produto = await _produtoApplication.GetByValor(valor);
                return Ok(produto);
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
                var produto = await _produtoApplication.DeleteAsync(id);
                return Ok(produto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

