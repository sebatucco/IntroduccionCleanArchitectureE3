﻿using IntroduccionCleanArchitectureE3.Domain.Abstractions;
using IntroduccionCleanArchitectureE3.Domain.Alquileres.Enums;
using IntroduccionCleanArchitectureE3.Domain.Alquileres.Event;
using IntroduccionCleanArchitectureE3.Domain.Alquileres.ObjectValues;
using IntroduccionCleanArchitectureE3.Domain.Alquileres.ServicesAlquiler;
using IntroduccionCleanArchitectureE3.Domain.ObjectValueShared;
using IntroduccionCleanArchitectureE3.Domain.Vehiculos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionCleanArchitectureE3.Domain.Alquileres
{
    public sealed class User : Entity
    {
        private User(
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

        public static User Reservar(
          Vehiculo vehiculo,
          //Guid vehiculoId,
          Guid userId,
          DateRange duracion,
          DateTime fechaCreacion,
          //PrecioDetalle precioDetalle
          PrecioService precioService
        )
        {
            var precioDetalle = precioService.CalcularPrecio(vehiculo, duracion);
            var alquiler = new User(
                Guid.NewGuid(),
                vehiculo.Id,
                userId,
                duracion,
                precioDetalle.PrecioPeriodo,
                precioDetalle.Mantenimiento,
                precioDetalle.Accesorios,
                precioDetalle.PrecioTotal,
                AlquilerStatus.Reservado,
                fechaCreacion
                );
            //publica un evento a la espera que otro componente consuma el evento
            alquiler.RaiseDomainEvent(new AlquilerReservadoDomainEvent(alquiler.Id!));
            vehiculo.FechaUltimoAlquiler = fechaCreacion;
            return alquiler;
        }

        public Result Confirmar(DateTime utcNow)
        {
            if (Status != AlquilerStatus.Reservado)
            {
                return Result.Failure(AlquilerErrors.NotReserved);
            }

            Status = AlquilerStatus.Confirmado;
            FechaConfirmacion = utcNow;

            RaiseDomainEvent(new AlquilerConfirmadoDomainEvent(Id));

            return Result.Success();
        }

        public Result Rechazar(DateTime utcNow)
        {
            if (Status != AlquilerStatus.Reservado)
            {
                return Result.Failure(AlquilerErrors.NotReserved);
            }

            Status = AlquilerStatus.Rechazado;
            FechaDenegacion = utcNow;

            RaiseDomainEvent(new AlquilerRechazadoDomainEvent(Id));

            return Result.Success();

        }

        public Result Cancelar(DateTime utcNow)
        {
            if (Status != AlquilerStatus.Confirmado)
            {
                return Result.Failure(AlquilerErrors.NotConfirmed);
            }

            var currenDate = DateOnly.FromDateTime(utcNow);

            if (currenDate > DuracionAlquiler.Inicio)
            {
                return Result.Failure(AlquilerErrors.AlReadyStarted);
            }

            Status = AlquilerStatus.Cancelado;
            FechaCancelacion = utcNow;

            RaiseDomainEvent(new AlquilerCanceladoDomainEvent(Id));

            return Result.Success();

        }

        public Result Completar(DateTime utcNow)
        {
            if (Status != AlquilerStatus.Confirmado)
            {
                return Result.Failure(AlquilerErrors.NotConfirmed);
            }

            Status = AlquilerStatus.Completado;
            FechaCompletado = utcNow;

            RaiseDomainEvent(new AlquilerCompletadoDomainEvent(Id));

            return Result.Success();

        }
    }
}
