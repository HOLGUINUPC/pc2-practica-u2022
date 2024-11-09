namespace pc2_practica_u2022.Crm.Interfaces.REST.Resources;

public record RatingResource(
    long Id,
    string UserEmailAddress,
    long ProductId,
    string RatingAspect,
    string Comment
);