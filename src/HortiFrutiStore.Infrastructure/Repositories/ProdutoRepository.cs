using HortiFrutiStore.Domain.Entities;
using HortiFrutiStore.Domain.Interfaces;
using HortiFrutiStore.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HortiFrutiStore.Infrastructure.Repositories;

public class ProdutoRepository : IProdutoRepository
{
    private readonly StoreContext _db;
    public ProdutoRepository(StoreContext db)
    {
        _db = db;
    }

    public void Adicionar(Produto produtoEntity)
        => _db.Produtos.Add(produtoEntity);

    public void Atualizar(Produto produtoEntity)
    => _db.Produtos.Update(produtoEntity);

    public async Task<Produto?> BuscarPor(Expression<Func<Produto, bool>> expression, CancellationToken ct = default)
        => await _db.Produtos.FirstOrDefaultAsync(expression, ct);

    public async Task<Produto?> BuscarPorId(Guid id, CancellationToken ct = default)
        => await _db.Produtos.FirstOrDefaultAsync(p => p.Id == id, ct);

    public async Task<List<Produto>> BuscarTodos(CancellationToken ct = default)
        => await _db.Produtos.AsNoTracking().ToListAsync(ct);

    public void Remover(Produto produtoEntity)
    {
        _db.Produtos.Remove(produtoEntity);
    }
}
