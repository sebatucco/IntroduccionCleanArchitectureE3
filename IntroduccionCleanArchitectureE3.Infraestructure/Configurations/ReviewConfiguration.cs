using IntroduccionCleanArchitectureE3.Domain.Alquileres;
using IntroduccionCleanArchitectureE3.Domain.Reviews;
using IntroduccionCleanArchitectureE3.Domain.Vehiculos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionCleanArchitectureE3.Infraestructure.Configurations
{
    internal sealed class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.ToTable("reviews");

            builder.HasKey(review => review.Id);

            builder.Property(review => review.Rating)
                .HasConversion(rating => rating.Value, value => Rating.Create(value).Value);

            builder.Property(review => review.Comentario)
                .HasMaxLength(200)
                .HasConversion(comentario => comentario.value, value => new Comentario(value));

            builder.HasOne<Vehiculo>()
                .WithMany()
                .HasForeignKey(review => review.VehiculoId);

            builder.HasOne<User>()
               .WithMany()
               .HasForeignKey(review => review.AlquilerId);

            builder.HasOne<User>()
               .WithMany()
               .HasForeignKey(review => review.UserId);
        }
    }
}
