using IntroduccionCleanArchitectureE3.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionCleanArchitectureE3.Domain.Reviews.Events
{
    public sealed record ReviewCreatedDomainEvent (Guid AlquilerId): IDomainEvents;
}
