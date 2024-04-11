using IntroduccionCleanArchitectureE3.Domain.Alquileres;
using IntroduccionCleanArchitectureE3.Domain.Alquileres.ObjectValues;
using IntroduccionCleanArchitectureE3.Domain.Vehiculos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionCleanArchitectureE3.Domain.Interfaces
{
    public interface IAlquilerRepository
    {

        Task<Alquiler> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<bool> IsOverlappingAsync(Vehiculo vehiculo, DateRange duracion, CancellationToken cancellationToken = default);

        void Add(Alquiler alquiler);
    }
}
