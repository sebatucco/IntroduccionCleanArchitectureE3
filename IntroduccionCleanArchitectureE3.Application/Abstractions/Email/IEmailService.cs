
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionCleanArchitectureE3.Application.Abstractions.Email
{
    public interface IEmailService
    {
        Task SendAsync(Domain.Users.ObjectValues.Email recipient, string subject, string body);
    }
}
