using System.ComponentModel.DataAnnotations.Schema;

namespace pc2_practica_u2022.Crm.Domain.Model.Aggregates;

public partial class RatingAudit
{
    [Column("CreatedAt")] public DateTimeOffset? CreatedDate { get; set; }
    [Column("UpdatedAt")]public DateTimeOffset? UpdatedDate { get; set; }


}