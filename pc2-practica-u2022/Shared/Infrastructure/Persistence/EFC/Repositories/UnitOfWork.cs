using pc2_practica_u2022.Shared.Domain.Repositories;
using pc2_practica_u2022.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace pc2_practica_u2022.Shared.Infrastructure.Persistence.EFC.Repositories;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    // inheritedDoc
    public async Task CompleteAsync()
    {
        await context.SaveChangesAsync();
    }
}