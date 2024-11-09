using pc2_practica_u2022.Crm.Domain.Model.Commands;
using pc2_practica_u2022.Crm.Interfaces.REST.Resources;

namespace pc2_practica_u2022.Crm.Interfaces.Transform;

public class CreateRatingCommandFromResourceAssembler
{
    public static CreateRatingCommand ToCommandFromResource(CreateRatingResource resource)
    {
        return new CreateRatingCommand(resource.ProductId, resource.UserEmailAddress, resource.RatingAspect,
            resource.Comment);
    }
}