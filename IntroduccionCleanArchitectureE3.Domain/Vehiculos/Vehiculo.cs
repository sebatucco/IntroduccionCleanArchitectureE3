using IntroduccionCleanArchitectureE3.Domain.Abstractions;
using IntroduccionCleanArchitectureE3.Domain.ObjectValueGlobal;
using IntroduccionCleanArchitectureE3.Domain.Vehiculos.Enums;
using IntroduccionCleanArchitectureE3.Domain.Vehiculos.ObjectValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionCleanArchitectureE3.Domain.Vehiculos
{
    // solo se setea valor al momento de la creacion del objeto
    public sealed class Vehiculo : Entity
    {
        public Vehiculo(
            Guid id,
            Modelo modelo,
            Vin vin,
            Moneda precio,
            Moneda mantenimiento,
            DateTime? fechaUltimoAlquiler,
            List<Accesorio> accesorios,
            Direccion? direccion
            ) : base(id)
        {
            Modelo = modelo;
            Vin = vin;
            Precio = precio;
            Mantenimiento = mantenimiento;
            FechaUltimoAlquiler = fechaUltimoAlquiler;
            Accesorios = accesorios;
            Direccion = direccion;
        }
        public Modelo? Modelo { get; private set; }
        public Vin? Vin { get; private set; }
        public Direccion? Direccion { get; private set; } // Object Value permite no tener un modelo anemico basado en datos primitivos
        public Moneda? Precio { get; private set; }
        public Moneda?  Mantenimiento { get; private set; }
        public DateTime? FechaUltimoAlquiler { get; set; }
        public List<Accesorio> Accesorios { get; private set; } = new List<Accesorio>();

    }
}
