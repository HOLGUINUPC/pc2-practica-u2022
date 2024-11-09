namespace pc2_practica_u2022.Crm.Interfaces.REST.Resources;

public record CreateRatingResource(
    string UserEmailAddress,
    long ProductId,
    int RatingAspect,
    string Comment
);