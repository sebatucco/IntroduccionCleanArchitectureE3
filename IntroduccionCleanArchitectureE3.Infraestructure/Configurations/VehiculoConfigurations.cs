using IntroduccionCleanArchitectureE3.Domain.Abstractions;
using IntroduccionCleanArchitectureE3.Domain.ObjectValueShared;
using IntroduccionCleanArchitectureE3.Domain.Vehiculos;
using IntroduccionCleanArchitectureE3.Domain.Vehiculos.ObjectValues;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionCleanArchitectureE3.Infraestructure.Configurations
{
    internal sealed class VehiculoConfigurations : IEntityTypeConfiguration<Vehiculo>
    {
        public void Configure(EntityTypeBuilder<Vehiculo> builder) // configuraciones de mapeo a la base
        {
            builder.ToTable("vehiculos"); 
            builder.HasKey(Vehiculo => Vehiculo.Id);

            builder.OwnsOne(Vehiculo => Vehiculo.Direccion);//se agregan campos en vehiculo y tambien permite mapear los object values que tienen mas de una propiedad

            builder.Property(vehiculo => vehiculo.Modelo).HasMaxLength(200)
                .HasConversion(modelo => modelo!.Value, value => new Modelo(value)); // como modelo es record y la base solo recibe tipos primitivos aqui transformo modelo a su tipo primitivo

            builder.Property(vehiculo => vehiculo.Vin).HasMaxLength(500)
                .HasConversion(vin => vin!.Value, value => new Vin(value));

            builder.OwnsOne(vehiculo => vehiculo.Precio, priceBuilder => 
            {
                priceBuilder.Property(moneda => moneda.TipoMoneda)
                .HasConversion(tipoMoneda => tipoMoneda.Codigo, codigo => TipoMoneda.FromCodigo(codigo!));
            });

            builder.OwnsOne(vehiculo => vehiculo.Mantenimiento, priceBuilder =>
            {
                priceBuilder.Property(moneda => moneda.TipoMoneda)
                .HasConversion(tipoMoneda => tipoMoneda.Codigo, codigo => TipoMoneda.FromCodigo(codigo!));
            });
        }
    }
}
