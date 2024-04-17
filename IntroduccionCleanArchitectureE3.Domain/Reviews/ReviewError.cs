using IntroduccionCleanArchitectureE3.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionCleanArchitectureE3.Domain.Reviews
{
    public static class ReviewError
    {
        public static readonly Error NotEligible = new
            (
             "Review.NoEligible",
             "Este review y calificacion para el auto no es elegible por que aun o se completa"
            );
    }
}
