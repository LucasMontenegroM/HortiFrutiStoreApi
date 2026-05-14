using HortiFrutiStore.Application.DTOs;
using HortiFrutiStore.Application.Services.Interfaces;
using HortiFrutiStore.Domain.Abstracoes;
using Microsoft.AspNetCore.Mvc;

namespace HortiFrutiStore.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoServices;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoServices = produtoService;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Buscar([FromRoute]Guid id, CancellationToken ct)
        {
            var dto = await _produtoServices.BuscarPorId(id, ct);
            return Ok(dto);
        }

        [HttpGet("buscartodos")]
        public async Task<IActionResult> BuscarTodos(int numPagina = 0, int numExibidos = 25, CancellationToken ct = default)
        {
            var retorno = await _produtoServices.BuscarTodos(numPagina, numExibidos, ct);
            return Ok(retorno);
        }

        [HttpPost("Criar")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Criar([FromBody] ProdutoDto dto, CancellationToken ct)
        {
            var dtoRetorno = await _produtoServices.Criar(dto, ct);
            return Created();
        }

        [HttpPatch("nome/{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]

        public async Task<IActionResult> AlterarNome([FromRoute]Guid id, string novoNome, CancellationToken ct)
        {
            await _produtoServices.AlterarNome(id, novoNome, ct);

            return NoContent();
        }

        [HttpPatch("preco/{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> AlterarPreco([FromRoute]Guid id, decimal novoPreco, CancellationToken ct)
        {
            await _produtoServices.AlterarPreco(id, novoPreco, ct);

            return NoContent();
        }

        [HttpDelete("excluir/{id:guid}")]
        public async Task<IActionResult> Remover(Guid id, CancellationToken ct)
        {
            await _produtoServices.Remover(id, ct);
            return Ok();
        }
    }
}
