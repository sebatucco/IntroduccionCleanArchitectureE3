﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionCleanArchitectureE3.Application.Vehiculos.SearchVehiculos
{
    public sealed class DireccionResponse
    {
        public string? Pais { get; init; }
        public string? Departamento { get; init; }  
        public string? Provincia { get; init; }
        public string? Calle {  get; init; }
    }
}
