using HortiFrutiStore.Application.DTOs;

namespace HortiFrutiStore.Application.Services.Interfaces;

public interface IProdutoService
{
    Task<ProdutoDto> Criar(ProdutoDto produto, CancellationToken ct);
    Task<ProdutoDto> BuscarPorId(Guid id, CancellationToken ct = default);
    Task<List<ProdutoDto>> BuscarTodos(CancellationToken ct = default);
    Task Remover(Guid id, CancellationToken ct = default);
    Task AlterarNome(Guid id, string novoNome, CancellationToken ct);
    Task AlterarPreco(Guid id, decimal novoPreco, CancellationToken ct);
    Task AplicarDesconto(Guid id, decimal novoDesconto, CancellationToken ct);
}
