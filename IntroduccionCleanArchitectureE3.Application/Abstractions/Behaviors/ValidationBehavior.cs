using FluentValidation;
using IntroduccionCleanArchitectureE3.Application.Abstractions.Messaging;
using IntroduccionCleanArchitectureE3.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionCleanArchitectureE3.Application.Abstractions.Behaviors
{
    public class ValidationBehavior<TRequest, Tresponse> : IPipelineBehavior<TRequest, Tresponse> where TRequest : IBaseCommand
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<Tresponse> Handle(TRequest request, RequestHandlerDelegate<Tresponse> next, CancellationToken cancellationToken)
        {
            if (!_validators.Any())
            {
                return await next();
            }

            var context = new ValidationContext<TRequest>(request);
            var validationErrors = _validators
                .Select(validators => validators.Validate(context))
                .Where(validationResult => validationResult.Errors.Any())
                .SelectMany(validationResult => validationResult.Errors)
                .Select(validationFailure => new ValidationError(validationFailure.PropertyName, validationFailure.ErrorMessage)).ToList();

            if (validationErrors.Any()) 
            {
                throw new Exceptions.ValidationException(validationErrors);
            }

            return await next();
        }
    }
}
