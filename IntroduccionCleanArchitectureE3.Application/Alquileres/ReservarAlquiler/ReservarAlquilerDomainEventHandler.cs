using IntroduccionCleanArchitectureE3.Application.Abstractions.Email;
using IntroduccionCleanArchitectureE3.Domain.Alquileres.Event;
using IntroduccionCleanArchitectureE3.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionCleanArchitectureE3.Application.Alquileres.ReservarAlquiler
{
    // INotificationHandler escucha los eventos
    internal sealed class ReservarAlquilerDomainEventHandler : INotificationHandler<AlquilerReservadoDomainEvent>
    {

        private readonly IUserRepository _userRepository;
        private readonly IAlquilerRepository _alquilerRepository;
        private readonly IEmailService _emailService;

        public ReservarAlquilerDomainEventHandler(IUserRepository userRepository, IAlquilerRepository alquilerRepository, IEmailService emailService)
        {
            _userRepository = userRepository;
            _alquilerRepository = alquilerRepository;
            _emailService = emailService;
        }

        public async Task Handle(AlquilerReservadoDomainEvent notification, CancellationToken cancellationToken)
        {
            var alquiler = await _alquilerRepository.GetByIdAsync(notification.alquilerId, cancellationToken);

            if (alquiler is null) 
            {
                return;
            }

            var user = await _userRepository.GetByIdAsync(alquiler.UserId, cancellationToken);
            if (user is null) 
            { 
             return ;
            }

            await _emailService.SendAsync(user.Email, "Alquiler Reservado", "Confirmar Reserva!");
        }
    }
}
