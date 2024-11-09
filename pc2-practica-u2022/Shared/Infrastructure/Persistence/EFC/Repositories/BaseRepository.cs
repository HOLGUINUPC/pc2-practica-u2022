using Microsoft.EntityFrameworkCore;
using pc2_practica_u2022.Shared.Domain.Repositories;
using pc2_practica_u2022.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace pc2_practica_u2022.Shared.Infrastructure.Persistence.EFC.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    protected readonly AppDbContext Context;

    /// <summary>
    ///     Default constructor for the base repository
    /// </summary>
    protected BaseRepository(AppDbContext context)
    {
        Context = context;
    }

    // inheritedDoc
    public async Task AddAsync(TEntity entity)
    {
        await Context.Set<TEntity>().AddAsync(entity);
    }

    // inheritedDoc
    public async Task<TEntity?> FindByIdAsync(int id)
    {
        return await Context.Set<TEntity>().FindAsync(id);
    }

    // inheritedDoc
    public void Update(TEntity entity)
    {
        Context.Set<TEntity>().Update(entity);
    }

    // inheritedDoc
    public void Remove(TEntity entity)
    {
        Context.Set<TEntity>().Remove(entity);
    }

    // inheritedDoc
    public async Task<IEnumerable<TEntity>> ListAsync()
    {
        return await Context.Set<TEntity>().ToListAsync();
    }
}