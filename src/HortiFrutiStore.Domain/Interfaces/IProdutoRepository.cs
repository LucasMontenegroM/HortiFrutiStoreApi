using HortiFrutiStore.Domain.Entities;

namespace HortiFrutiStore.Domain.Interfaces;

public interface IProdutoRepository : IRepository<Produto>
{
    void Adicionar(Produto produtoEntity);
    void Atualizar(Produto produtoEntity);
    void Remover(Produto produtoEntity);
}
