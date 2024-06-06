using IntroduccionCleanArchitectureE3.Domain.Abstractions;
using IntroduccionCleanArchitectureE3.Domain.Alquileres;
using IntroduccionCleanArchitectureE3.Domain.Alquileres.Enums;
using IntroduccionCleanArchitectureE3.Domain.Reviews.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionCleanArchitectureE3.Domain.Reviews
{
    public sealed class Review : Entity
    {
        public Guid VehiculoId { get; private set; }
        public Guid AlquilerId { get; private set; }
        public Guid UserId { get; private set; }
        public Rating Rating { get; private set; }
        public Comentario? Comentario { get; private set; } 
        public DateTime? FechaCreacion { get; private set; } 
        private Review(
            Guid id,
            Guid vehiculoId,
            Guid alquilerId,
            Guid userId,
            Rating rating,
            Comentario comentario,
            DateTime? fechaCreacion
            ) : base(id)
        {
            VehiculoId = vehiculoId;
            AlquilerId = alquilerId;
            UserId = userId;
            Rating = rating;
            Comentario = comentario;
            FechaCreacion = fechaCreacion;      
        }

        public static Result<Review> Create(User alquiler, Rating rating, Comentario comentario, DateTime fechacreacion)
        {
            if (alquiler.Status != AlquilerStatus.Completado)
            {
                return Result.Failure<Review>(ReviewError.NotEligible);
            }

            var review = new Review(Guid.NewGuid(), alquiler.VehiculoId, alquiler.Id, alquiler.UserId, rating, comentario, fechacreacion);

            review.RaiseDomainEvent(new ReviewCreatedDomainEvent(review.Id));

            return review;
        }
    }
}
