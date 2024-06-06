using IntroduccionCleanArchitectureE3.Domain.Users;
using IntroduccionCleanArchitectureE3.Domain.Users.ObjectValues;
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
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");
            builder.HasKey(user => user.Id);

            builder.Property(user => user.Nombre)
                .HasMaxLength(200)
                .HasConversion(nombre => nombre!.value, value => new Nombre(value));
            builder.Property(user => user.Apellido)
               .HasMaxLength(200)
               .HasConversion(apellido => apellido!.value, value => new Apellido(value));

            builder.Property(user => user.Email)
            .HasMaxLength(400)
            .HasConversion(email => email!.value, value => new Domain.Users.ObjectValues.Email(value));

            builder.HasIndex(user => user.Email).IsUnique();
        }
    }
}
