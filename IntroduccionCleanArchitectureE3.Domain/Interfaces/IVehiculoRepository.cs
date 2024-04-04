using IntroduccionCleanArchitectureE3.Domain.Users;
using IntroduccionCleanArchitectureE3.Domain.Vehiculos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionCleanArchitectureE3.Domain.Interfaces
{
    public interface IVehiculoRepository
    {
        Task<Vehiculo> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);  // cancelationToken si demora mas tiempo de lo esperado se cancela

        void Add(Vehiculo vehiculo);

    }
}
