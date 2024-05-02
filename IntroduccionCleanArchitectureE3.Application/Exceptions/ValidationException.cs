using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionCleanArchitectureE3.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(IEnumerable<ValidationError> validations)
        {
            _Validations = validations;
        }

        public IEnumerable<ValidationError> _Validations { get;}
       
    }
}
