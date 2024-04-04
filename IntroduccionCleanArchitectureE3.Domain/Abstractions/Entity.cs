using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionCleanArchitectureE3.Domain.Abstractions
{
    public abstract class Entity
    {
        public readonly List<IDomainEvents> _Events = new();
        protected Entity(Guid id)
        {
            Id = id;     
        }
        public Guid Id { get; init; } // init = una vez definida la identificacion no cambia nunca

        public IReadOnlyList<IDomainEvents> GetDomainEvents()
        { 
          return _Events.ToList();
        }

        public void ClearDomainEvents()
        { 
         _Events.Clear();
        }

        protected void RaiseDomainEvent(IDomainEvents domainEvents)
        {
            _Events.Add(domainEvents);
        }
    }
}
