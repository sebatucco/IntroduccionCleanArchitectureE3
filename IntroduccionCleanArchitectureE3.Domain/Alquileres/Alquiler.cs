﻿using IntroduccionCleanArchitectureE3.Domain.Abstractions;
using IntroduccionCleanArchitectureE3.Domain.Alquileres.Enums;
using IntroduccionCleanArchitectureE3.Domain.Alquileres.ObjectValues;
using IntroduccionCleanArchitectureE3.Domain.ObjectValueGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionCleanArchitectureE3.Domain.Alquileres
{
    public sealed class Alquiler : Entity
    {
        private Alquiler(
            Guid id,
            Guid vehiculoId,
            Guid userId,
            DateRange duracionAlquiler,
            Moneda precioPorPeriodo,
            Moneda mantenimiento,
            Moneda accesorios,
            Moneda precioTotal,
            AlquilerStatus status,
            DateTime fechaCreacion
        ) : base(id)
        {
            VehiculoId = vehiculoId;
            UserId = userId;
            DuracionAlquiler = duracionAlquiler;
            PrecioPorPeriodo = precioPorPeriodo;
            Mantenimiento = mantenimiento;
            Accesorios = accesorios;
            PrecioTotal = precioTotal;
            Status = status;
            FechaCreacion = fechaCreacion;
        }

        public Guid VehiculoId { get; private set; }

        public Guid UserId { get; private set; }

        public Moneda? PrecioPorPeriodo { get; private set; }

        public Moneda? Mantenimiento { get; private set; }

        public Moneda? Accesorios { get; private set; }

        public Moneda? PrecioTotal { get; private set; }

        public AlquilerStatus Status { get; private set; }

        public DateRange DuracionAlquiler { get; private set; }

        public DateTime? FechaCreacion { get; private set; }

        public DateTime? FechaConfirmacion { get; private set; }

        public DateTime? FechaDenegacion { get; private set; }

        public DateTime? FechaCompletado { get; private set; }

        public DateTime? FechaCancelacion { get; private set; }


    }
}