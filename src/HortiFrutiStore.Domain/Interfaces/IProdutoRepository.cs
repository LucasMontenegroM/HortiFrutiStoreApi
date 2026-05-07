using HortiFrutiStore.Domain.Entities;

namespace HortiFrutiStore.Domain.Interfaces;

public interface IProdutoRepository : IRepository<Produto>
{
    void Remover(Produto produtoEntity);
}
