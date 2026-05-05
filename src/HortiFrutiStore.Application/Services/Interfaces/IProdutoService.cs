using HortiFrutiStore.Application.DTOs;

namespace HortiFrutiStore.Application.Services.Interfaces;

public interface IProdutoService
{
    void Criar(ProdutoDto produto);
    Task<ProdutoDto> BuscarPorId(Guid id, CancellationToken ct = default);
    Task<List<ProdutoDto>> BuscarTodos(CancellationToken ct = default);
    Task Remover(Guid id, CancellationToken ct = default);
}
