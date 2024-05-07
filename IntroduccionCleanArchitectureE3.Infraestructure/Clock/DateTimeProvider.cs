using IntroduccionCleanArchitectureE3.Application.Abstractions.Clock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionCleanArchitectureE3.Infraestructure.Clock
{
    internal sealed class DateTimeProvider : IDateTimeeProvider
    {
        public DateTime CurrentTimeGet => DateTime.UtcNow;
    }
}
