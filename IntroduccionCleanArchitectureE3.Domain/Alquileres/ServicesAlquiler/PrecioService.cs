using IntroduccionCleanArchitectureE3.Domain.Alquileres.ObjectValues;
using IntroduccionCleanArchitectureE3.Domain.ObjectValueGlobal;
using IntroduccionCleanArchitectureE3.Domain.Vehiculos;
using IntroduccionCleanArchitectureE3.Domain.Vehiculos.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionCleanArchitectureE3.Domain.Alquileres.ServicesAlquiler
{
    public class PrecioService
    {
        public PrecioDetalle CalcularPrecio(Vehiculo vehiculo, DateRange periodo)
        {
            var tipoMoneda = vehiculo.Precio!.TipoMoneda;

            var precioPeriodo = new Moneda(
                periodo.CantidadDias * vehiculo.Precio.Monto,
                tipoMoneda
                );

            decimal porcentageChange = 0;

            foreach (var accesorio in vehiculo.Accesorios)
            {
                porcentageChange += accesorio switch
                {
                    Accesorio.AppleCar or Accesorio.AndroidCar => 0.05m,
                    Accesorio.AireAcondicionado => 0.01m,
                    Accesorio.Mapas => 0.01m,
                    _=> 0
                };
            }

            var accesorioCharges = Moneda.Zero(tipoMoneda);
            if(porcentageChange > 0) 
            {
                accesorioCharges = new (
                    precioPeriodo.Monto * porcentageChange, 
                    tipoMoneda
                    );
            }

            var precioTotal = Moneda.Zero();
            precioPeriodo += precioPeriodo;

            if (!vehiculo!.Mantenimiento!.IsZero())
            {
                precioTotal += vehiculo.Mantenimiento;
            }

            precioTotal += accesorioCharges;

        }
    }
}
