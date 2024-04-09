using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionCleanArchitectureE3.Domain.Abstractions
{
    public record Error(string code, string message)
    {
        public static Error None = new(string.Empty, string.Empty);

        public static Error NullValue = new("Error.NulValue", "Un valor null fue ingresado");
    }
}
