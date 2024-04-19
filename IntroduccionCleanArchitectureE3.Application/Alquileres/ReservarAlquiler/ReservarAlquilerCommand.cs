using IntroduccionCleanArchitectureE3.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionCleanArchitectureE3.Application.Alquileres.ReservarAlquiler
{
    public record ReservarAlquilerCommand(Guid VehiculoId, Guid UserId, DateOnly FechaInicio, DateOnly FechaFin): ICommand<Guid>;
}
