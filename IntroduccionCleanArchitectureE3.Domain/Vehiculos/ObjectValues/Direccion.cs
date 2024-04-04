using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionCleanArchitectureE3.Domain.Vehiculos.ObjectValues
{
    public record Direccion
    (
        string Calle,
        string Departamento,
        string Provincia,
        string Ciudad,
        string Pais
    );
}
