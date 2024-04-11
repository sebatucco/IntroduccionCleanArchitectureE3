using IntroduccionCleanArchitectureE3.Domain.ObjectValueShared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionCleanArchitectureE3.Domain.Alquileres
{
    public record PrecioDetalle(Moneda PrecioPeriodo, Moneda Mantenimiento, Moneda Accesorios, Moneda PrecioTotal);
    
}
