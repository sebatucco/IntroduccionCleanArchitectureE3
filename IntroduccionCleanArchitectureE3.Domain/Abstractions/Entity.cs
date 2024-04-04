using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionCleanArchitectureE3.Domain.Abstractions
{
    public abstract class Entity
    {
        protected Entity(Guid id)
        {
            Id = id;     
        }
        public Guid Id { get; init; } // init = una vez definida la identificacion no cambia nunca
    }
}
