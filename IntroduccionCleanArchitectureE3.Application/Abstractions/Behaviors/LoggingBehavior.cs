using IntroduccionCleanArchitectureE3.Application.Abstractions.Messaging;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionCleanArchitectureE3.Application.Abstractions.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IBaseCommand
    {
        private readonly ILogger<TRequest> _logger;

        public LoggingBehavior(ILogger<TRequest> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var name = request.GetType().Name; // el objeto de que tipo es y retorna el nombre de la clase
            try
            {
                _logger.LogInformation($"Ejecutando el command request {name}");
                var result = await next();
                _logger.LogInformation($"El comando se ejecuto exitosamente");
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"El comando {name} tuvo errores");
                throw;
                throw;
            }
        }
    }
}
