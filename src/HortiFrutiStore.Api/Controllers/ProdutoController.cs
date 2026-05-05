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
    }
}
