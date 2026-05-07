using HortiFrutiStore.Application.DTOs;
using HortiFrutiStore.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HortiFrutiStore.Api.Controllers
{
    [Route("api/[controller]")]
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

        [HttpGet]
        public async Task<IActionResult> BuscarTodos(CancellationToken ct)
        {
            var retorno = await _produtoServices.BuscarTodos(ct);
            return Ok(retorno);
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] ProdutoDto dto, CancellationToken ct)
        {
            var dtoRetorno = await _produtoServices.Criar(dto, ct);
            return Created();
        }

        [HttpPatch]

        public async Task<IActionResult> AlterarNomeProduto(Guid id, string novoNome, CancellationToken ct)
        {
            await _produtoServices.AlterarNome(id, novoNome, ct);

            return NoContent();
        }
        [HttpPatch]

        public async Task<IActionResult> AlterarPrecoProduto(Guid id, decimal novoPreco, CancellationToken ct)
        {
            await _produtoServices.AlterarPreco(id, novoPreco, ct);

            return NoContent();
        }
    }
}
