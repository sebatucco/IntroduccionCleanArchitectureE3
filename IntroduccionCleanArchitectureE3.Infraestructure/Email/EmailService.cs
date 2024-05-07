using IntroduccionCleanArchitectureE3.Application.Abstractions.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionCleanArchitectureE3.Infraestructure.Email
{
    internal sealed class EmailService : IEmailService
    {
        public Task SendAsync(Domain.Users.ObjectValues.Email recipient, string subject, string body)
        {
            return Task.CompletedTask; // simula que se completo la tarea
        }
    }
}
