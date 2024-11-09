using pc2_practica_u2022.Crm.Domain.Model.Aggregates;
using pc2_practica_u2022.Crm.Domain.Model.Commands;

namespace pc2_practica_u2022.Crm.Domain.Services;

public interface IRatingCommandService
{
    Task<Rating?> Handle(CreateRatingCommand command);
}