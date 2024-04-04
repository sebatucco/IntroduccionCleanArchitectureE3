using IntroduccionCleanArchitectureE3.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionCleanArchitectureE3.Domain.Users.Events
{
    public sealed record UserCreateDomainEvent(Guid id) : IDomainEvents
    { 
    
    }
   
}
