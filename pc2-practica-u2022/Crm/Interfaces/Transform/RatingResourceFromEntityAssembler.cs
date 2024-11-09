using pc2_practica_u2022.Crm.Domain.Model.Aggregates;
using pc2_practica_u2022.Crm.Interfaces.REST.Resources;

namespace pc2_practica_u2022.Crm.Interfaces.Transform;

public class RatingResourceFromEntityAssembler
{
    public static RatingResource toResourceFromEntity(Rating rating)
    {
        return new RatingResource(rating.Id, rating.UserEmailAddress.Value, rating.ProductId.Productid,
            rating.RatingAspect.ToString(), rating.Comment);
        
    }
}