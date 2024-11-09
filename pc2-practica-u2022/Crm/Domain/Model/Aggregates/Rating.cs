using pc2_practica_u2022.Crm.Domain.Model.Commands;
using pc2_practica_u2022.Crm.Domain.Model.ValueObjects;

namespace pc2_practica_u2022.Crm.Domain.Model.Aggregates;

public partial class Rating
{
    public long Id { get; set; }
    public ProductId ProductId { get; set; }
    public EmailAddress UserEmailAddress { get;  set; }
    public ERatingAspect RatingAspect { get; set; }
    public string Comment { get; set; }
    public DateTime RatedAt { get; set; }

    
    
    public Rating()
    { 
    }

    
    

    public Rating(CreateRatingCommand command)
    {   
        ProductId = new ProductId(command.ProductId);
        UserEmailAddress = new EmailAddress(command.EmailAddress);
        RatingAspect = (ERatingAspect)command.RatingAspect;
        Comment = command.Comment;
        RatedAt = new DateTime();


    }
    

}