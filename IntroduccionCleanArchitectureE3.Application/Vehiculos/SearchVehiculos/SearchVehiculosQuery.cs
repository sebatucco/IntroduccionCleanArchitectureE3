using IntroduccionCleanArchitectureE3.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionCleanArchitectureE3.Application.Vehiculos.SearchVehiculos
{
    public sealed record SearchVehiculosQuery(DateOnly fechaInicio, DateOnly fechaFin): IQuery<IReadOnlyList<VehiculoResponse>>;
}
