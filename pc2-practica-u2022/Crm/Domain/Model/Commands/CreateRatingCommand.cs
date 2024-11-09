namespace pc2_practica_u2022.Crm.Domain.Model.Commands;

public record CreateRatingCommand(
    long ProductId,
    string EmailAddress,
    long RatingAspect,
    string Comment);
