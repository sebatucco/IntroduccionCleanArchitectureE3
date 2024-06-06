using IntroduccionCleanArchitectureE3.Domain.Alquileres;
using IntroduccionCleanArchitectureE3.Domain.ObjectValueShared;
using IntroduccionCleanArchitectureE3.Domain.Users;
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
    internal sealed class AlquilerConfiguration : IEntityTypeConfiguration<Domain.Alquileres.User>
    {
        public void Configure(EntityTypeBuilder<Domain.Alquileres.User> builder)
        {
            builder.ToTable("lquileres");
            builder.HasKey(alquiler => alquiler.Id);
            // relacion alquiler precio uno a uno
            builder.OwnsOne(alquiler => alquiler.PrecioPorPeriodo, precioBuilder =>
            {
                precioBuilder.Property(moneda => moneda.TipoMoneda)
                .HasConversion(tipoMoneda => tipoMoneda.Codigo, codigo => TipoMoneda.FromCodigo(codigo));
            });

            builder.OwnsOne(alquiler => alquiler.Mantenimiento, precioBuilder =>
            {
                precioBuilder.Property(moneda => moneda.TipoMoneda)
                .HasConversion(tipoMoneda => tipoMoneda.Codigo, codigo => TipoMoneda.FromCodigo(codigo));
            });


            builder.OwnsOne(alquiler => alquiler.Accesorios, precioBuilder =>
            {
                precioBuilder.Property(moneda => moneda.TipoMoneda)
                .HasConversion(tipoMoneda => tipoMoneda.Codigo, codigo => TipoMoneda.FromCodigo(codigo));
            });

            builder.OwnsOne(alquiler => alquiler.PrecioTotal, precioBuilder =>
            {
                precioBuilder.Property(moneda => moneda.TipoMoneda)
                .HasConversion(tipoMoneda => tipoMoneda.Codigo, codigo => TipoMoneda.FromCodigo(codigo));
            });

            builder.OwnsOne(alquiler => alquiler.DuracionAlquiler);

            // relacion uno a muchos
            builder.HasOne<Vehiculo>()
            .WithMany()
            .HasForeignKey(alquiler => alquiler.VehiculoId);

            // tiene un solo usuario donde la fk es user id
            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(alquiler => alquiler.UserId);
        }
    }
}
