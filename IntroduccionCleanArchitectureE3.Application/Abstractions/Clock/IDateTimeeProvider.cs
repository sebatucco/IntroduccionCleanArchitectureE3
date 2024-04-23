using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionCleanArchitectureE3.Application.Abstractions.Clock
{
    public interface IDateTimeeProvider
    {
        DateTime CurrentTimeGet { get; }
    }
}
