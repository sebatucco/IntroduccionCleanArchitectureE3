using IntroduccionCleanArchitectureE3.Application.Abstractions.Clock;
using IntroduccionCleanArchitectureE3.Application.Abstractions.Messaging;
using IntroduccionCleanArchitectureE3.Domain.Abstractions;
using IntroduccionCleanArchitectureE3.Domain.Alquileres;
using IntroduccionCleanArchitectureE3.Domain.Alquileres.ObjectValues;
using IntroduccionCleanArchitectureE3.Domain.Alquileres.ServicesAlquiler;
using IntroduccionCleanArchitectureE3.Domain.Interfaces;
using IntroduccionCleanArchitectureE3.Domain.Users;
using IntroduccionCleanArchitectureE3.Domain.Vehiculos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionCleanArchitectureE3.Application.Alquileres.ReservarAlquiler
{
    internal sealed class ReservarAlquilerCommandHandler : ICommandHandler<ReservarAlquilerCommand, Guid>
    {
        private readonly IUserRepository _userRepository;
        private readonly IVehiculoRepository _vehiculoRepository;
        private readonly IAlquilerRepository _alquilerRepository;
        private readonly PrecioService _precioService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDateTimeeProvider _dateTimeeProvider;

        public ReservarAlquilerCommandHandler(IUserRepository userRepository, IVehiculoRepository vehiculoRepository, IAlquilerRepository alquilerRepository, PrecioService precioService, IUnitOfWork unitOfWork, IDateTimeeProvider dateTimeeProvider)
        {
            _userRepository = userRepository;
            _vehiculoRepository = vehiculoRepository;
            _alquilerRepository = alquilerRepository;
            _precioService = precioService;
            _unitOfWork = unitOfWork;
            _dateTimeeProvider = dateTimeeProvider;
        }

        public async Task<Result<Guid>> Handle(ReservarAlquilerCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId, cancellationToken);
            if (user == null) 
            {
                return Result.Failure<Guid>(UserErrors.NotFound);
            }
            var vehiculo = await _vehiculoRepository.GetByIdAsync(request.VehiculoId, cancellationToken);
            if (vehiculo == null) 
            { 
                return Result.Failure<Guid>(VehiculoErrors.NotFound);
            }
            var duracion = DateRange.Create(request.FechaInicio, request.FechaFin);
            if (await _alquilerRepository.IsOverlappingAsync(vehiculo, duracion, cancellationToken))
            {
                return Result.Failure<Guid>(AlquilerErrors.OverLap);
            }

            var alquiler = Alquiler.Reservar(vehiculo, user.Id, duracion, _dateTimeeProvider.CurrentTimeGet, _precioService);
            _alquilerRepository.Add(alquiler);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return alquiler.Id;
        }
    }
}
