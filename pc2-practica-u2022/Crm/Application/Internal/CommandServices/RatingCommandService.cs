using pc2_practica_u2022.Crm.Domain.Model.Aggregates;
using pc2_practica_u2022.Crm.Domain.Model.Commands;
using pc2_practica_u2022.Crm.Domain.Model.ValueObjects;
using pc2_practica_u2022.Crm.Domain.Repositories;
using pc2_practica_u2022.Crm.Domain.Services;
using pc2_practica_u2022.Shared.Domain.Repositories;

namespace pc2_practica_u2022.Crm.Application.Internal.CommandServices;

public class RatingCommandService(IRatingRepository ratingRepository, IUnitOfWork unitOfWork)
    : IRatingCommandService
{
    public async Task<Rating?> Handle(CreateRatingCommand command)
    {

        var emailAddress = new EmailAddress(command.EmailAddress);
        var productId = new ProductId(command.ProductId);
        var ratingAspect = (ERatingAspect)command.RatingAspect;

        var rating =
            await ratingRepository.FindByUserEmailAddressAndProductIdAndRatingAspectAsync(emailAddress, productId,
                ratingAspect);
        
        if (rating != null)
            throw new ArgumentException("Rating already exists");
        
        rating = new Rating(command);
        try
        {
            await ratingRepository.AddAsync(rating);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            return null;
        }

        return rating;
    }

    }

        
    
    
        