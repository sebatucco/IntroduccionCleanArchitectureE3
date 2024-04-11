using IntroduccionCleanArchitectureE3.Domain.Abstractions;
using IntroduccionCleanArchitectureE3.Domain.Alquileres;
using IntroduccionCleanArchitectureE3.Domain.Alquileres.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionCleanArchitectureE3.Domain.Comentarios
{
    public sealed class Comentario : Entity
    {
        public Guid VehiculoId { get; private set; }
        public Guid AlquilerId { get; private set; }
        public Guid UserId { get; private set; }
        public int Rating { get; private set; }
        public string? Review { get; private set; } 
        public DateTime? FechaCreacion { get; private set; } 
        private Comentario(
            Guid id,
            Guid vehiculoId,
            Guid alquilerId,
            Guid userId,
            int rating,
            string review,
            DateTime? fechaCreacion
            ) : base(id)
        {
            VehiculoId = vehiculoId;
            AlquilerId = alquilerId;
            UserId = userId;
            Rating = rating;
            Review = review;
            FechaCreacion = fechaCreacion;      
        }

        public static Result<Comentario> Create(Alquiler alquiler, int rating, string comentario, DateTime fechacreacion)
        {
            if (alquiler.Status != AlquilerStatus.Completado)
            { 
            
            }
        }
    }
}
