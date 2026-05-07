using HortiFrutiStore.Domain.Entities;
using HortiFrutiStore.Domain.Interfaces;
using HortiFrutiStore.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HortiFrutiStore.Infrastructure.Repositories;

public class ProdutoRepository : IProdutoRepository
{
    private readonly StoreContext _db;
    public ProdutoRepository(StoreContext db)
    {
        _db = db;
    }
    public async Task<Produto?> BuscarPorId(Guid id, CancellationToken ct = default)
        => await _db.Produtos.FirstOrDefaultAsync(p => p.Id == id, ct);

    public async Task<List<Produto>> BuscarTodos(CancellationToken ct = default)
        => await _db.Produtos.AsNoTracking().ToListAsync(ct);

    public void Remover(Produto produtoEntity)
    {
        _db.Produtos.Remove(produtoEntity);
    }
}
