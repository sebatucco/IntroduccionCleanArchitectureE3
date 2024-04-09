using IntroduccionCleanArchitectureE3.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionCleanArchitectureE3.Domain.Alquileres
{
    public static class AlquilerErrors
    {
        public static Error NotFound = new Error(
            "Alquiler.Found",
            "El alquiler con el id especificado no fue encontrado"
            );

        public static Error OverLap = new Error(
            "Alquiler.OverLap",
            "El alquiler esta siendo tomado por mas de un cliente a la vez"
            );

        public static Error NotReserved = new Error(
            "Alquiler.NotReserved",
            "El alquiler no esta reservado"
            );

        public static Error NotConfirmed = new Error(
           "Alquiler.NotConfirmed",
           "El alquiler no esta confirmado"
           );

        public static Error AlReadyStarted = new Error(
           "Alquiler.AlReadyStarted",
           "El alquiler ya ha comenzado"
           );
    }
}
