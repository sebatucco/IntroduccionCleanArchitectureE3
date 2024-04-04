using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionCleanArchitectureE3.Domain.Abstractions
{
    public interface IDomainEvents : INotification // patron publisher/suscriber
    {
    }
}
