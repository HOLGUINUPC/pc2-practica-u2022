using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using pc2_practica_u2022.Crm.Domain.Model.Aggregates;
using pc2_practica_u2022.Crm.Domain.Model.ValueObjects;
using pc2_practica_u2022.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

namespace pc2_practica_u2022.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    /// <summary>
    ///     On configuring the database context
    /// </summary>
    /// <remarks>
    ///     This method is used to configure the database context.
    ///     It also adds the created and updated date interceptor to the database context.
    /// </remarks>
    /// <param name="builder">
    ///     The options builder for the database context
    /// </param>
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }

    /// <summary>
    ///     On creating the database model
    /// </summary>
    /// <remarks>
    ///     This method is used to create the database model for the application.
    /// </remarks>
    /// <param name="builder">
    ///     The model builder for the database context
    /// </param>
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Configuración de Rating
        builder.Entity<Rating>()
            .ToTable("Rating")
            .HasKey(p => p.Id);

        builder.Entity<Rating>()
            .Property(p => p.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder.Entity<Rating>()
            .Property(r => r.ProductId)
            .HasConversion(
                v => v.Productid, // Almacena como long en la base de datos
                v => new ProductId(v) // Convierte de long a ProductId al leer
            )
            .IsRequired();

        // Configuración para UserEmailAddress como string en la base de datos
        builder.Entity<Rating>()
            .Property(r => r.UserEmailAddress)
            .HasConversion(
                v => v.ToString(), // Convierte a string al almacenar
                v => new EmailAddress(v) // Convierte de string a EmailAddress al leer
            )
            .IsRequired();

        builder.Entity<Rating>()
            .Property(r => r.RatingAspect)
            .IsRequired();

        builder.Entity<Rating>()
            .Property(r => r.Comment)
            .IsRequired();

        builder.UseSnakeCaseNamingConvention();
    }
}
