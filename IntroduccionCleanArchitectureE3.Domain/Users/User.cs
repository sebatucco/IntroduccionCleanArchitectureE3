﻿using IntroduccionCleanArchitectureE3.Domain.Abstractions;
using IntroduccionCleanArchitectureE3.Domain.Users.ObjectValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionCleanArchitectureE3.Domain.Users
{
    public sealed class User : Entity
    {
        private User(Guid id, Nombre nombre, Apellido apellido, Email email) : base(id)
        {
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
        }

        public Nombre? Nombre { get; private set; }
        public Apellido? Apellido { get; private set; }
        public Email? Email { get; private set; }

        public static User Create( Nombre nombre, Apellido apellido, Email email)
        {
            return new User(Guid.NewGuid(), nombre, apellido, email);
        }
    }
}
