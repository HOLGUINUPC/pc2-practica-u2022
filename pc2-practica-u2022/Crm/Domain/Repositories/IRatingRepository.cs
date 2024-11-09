using pc2_practica_u2022.Crm.Domain.Model.Aggregates;
using pc2_practica_u2022.Crm.Domain.Model.ValueObjects;
using pc2_practica_u2022.Shared.Domain.Repositories;

namespace pc2_practica_u2022.Crm.Domain.Repositories;

public interface IRatingRepository : IBaseRepository<Rating>
{
     Task<Rating?> FindByUserEmailAddressAndProductIdAndRatingAspectAsync(EmailAddress userEmailAddress, ProductId productId, ERatingAspect ratingAspect);     
    
}

    