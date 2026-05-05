using HortiFrutiStore.Domain.Entities;

namespace HortiFrutiStore.Domain.Interfaces
{
    public interface IRepository <T> where T : class
    {
        Task<T?> BuscarPorId(Guid id, CancellationToken ct = default);
        Task<List<T>> BuscarTodos(CancellationToken ct = default);     
    }
}
