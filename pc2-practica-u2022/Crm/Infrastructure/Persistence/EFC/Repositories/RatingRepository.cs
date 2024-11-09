using pc2_practica_u2022.Crm.Domain.Model.Aggregates;
using pc2_practica_u2022.Crm.Domain.Model.ValueObjects;
using pc2_practica_u2022.Crm.Domain.Repositories;
using pc2_practica_u2022.Shared.Infrastructure.Persistence.EFC.Configuration;
using pc2_practica_u2022.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace pc2_practica_u2022.Crm.Infrastructure.Persistence.EFC.Repositories;

public class RatingRepository(AppDbContext context)
: BaseRepository<Rating>(context), IRatingRepository
{
 public async Task<Rating?> FindByUserEmailAddressAndProductIdAndRatingAspectAsync(EmailAddress userEmailAddress,
     ProductId productId, ERatingAspect ratingAspect)
 {
     return  Context.Set<Rating>().FirstOrDefault(p => p.UserEmailAddress == userEmailAddress &&
                                                                 p.ProductId == productId 
                                                                 && p.RatingAspect == ratingAspect);
 }
 
}