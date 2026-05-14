using HortiFrutiStore.Domain.Abstracoes;
using System.Linq.Expressions;

namespace HortiFrutiStore.Domain.Interfaces
{
    public interface IRepository <T> where T : Entity
    {
        Task<List<T>> BuscarTodos(CancellationToken ct = default);
        Task<T?> BuscarPor(Expression<Func<T, bool>> expression, CancellationToken ct = default);
        void Adicionar(T entity);
        void Atualizar(T entity);
        void Remover(T entity);

    }
}
