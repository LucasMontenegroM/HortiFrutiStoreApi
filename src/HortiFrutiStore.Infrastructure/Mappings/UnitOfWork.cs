using HortiFrutiStore.Domain.Interfaces;
using HortiFrutiStore.Infrastructure.Contexts;

namespace HortiFrutiStore.Infrastructure.Mappings;

public class UnitOfWork(StoreContext context) : IUnitOfWork
{
    public async Task CommitAsync()
    {
        await context.SaveChangesAsync();
    }
}
