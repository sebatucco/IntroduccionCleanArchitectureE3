using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionCleanArchitectureE3.Application.Alquileres.ReservarAlquiler
{
    public class ReservarAlquilerCommandValidador : AbstractValidator<ReservarAlquilerCommand>
    {
        public ReservarAlquilerCommandValidador()
        {
            RuleFor(c => c.UserId).NotEmpty();
            RuleFor(c => c.VehiculoId).NotEmpty();
            RuleFor(c => c.FechaInicio).LessThan(c => c.FechaFin);
        }
    }
}
