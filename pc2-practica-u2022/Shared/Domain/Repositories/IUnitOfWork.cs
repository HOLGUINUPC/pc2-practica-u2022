

namespace pc2_practica_u2022.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    /// <summary>
    ///     Save changes to the repository
    /// </summary>
    /// <returns></returns>
    Task CompleteAsync();
}