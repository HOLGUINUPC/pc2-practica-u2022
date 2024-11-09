using upcpc2_web.Shared.Domain.Repositories;
using upcpc2_web.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace upcpc2_web.Shared.Infrastructure.Persistence.EFC.Repositories;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    // inheritedDoc
    public async Task CompleteAsync()
    {
        await context.SaveChangesAsync();
    }
}