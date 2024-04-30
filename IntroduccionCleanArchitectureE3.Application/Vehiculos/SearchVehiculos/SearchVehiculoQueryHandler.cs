using Dapper;
using IntroduccionCleanArchitectureE3.Application.Abstractions.Data;
using IntroduccionCleanArchitectureE3.Application.Abstractions.Messaging;
using IntroduccionCleanArchitectureE3.Domain.Abstractions;
using IntroduccionCleanArchitectureE3.Domain.Alquileres.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionCleanArchitectureE3.Application.Vehiculos.SearchVehiculos
{
    internal sealed class SearchVehiculoQueryHandler : IQueryHandler<SearchVehiculosQuery, IReadOnlyList<VehiculoResponse>>
    {
        private static readonly int[] ActiveAlquilerStatuses =
        {
            (int)AlquilerStatus.Reservado,
            (int)AlquilerStatus.Confirmado,
            (int)AlquilerStatus.Completado
        };
        private readonly ISqlConnectionFactory _connectionFactory;

        public SearchVehiculoQueryHandler(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<Result<IReadOnlyList<VehiculoResponse>>> Handle(SearchVehiculosQuery request, CancellationToken cancellationToken)
        {
            if (request.fechaInicio > request.fechaFin)
            {
                return new List<VehiculoResponse>();
            }

            using var connection = _connectionFactory.CreateConnection();
            const string sql = """
                    SELECT
                    a.id as Id,
                    a.modelo as Modelo,
                    a.vin as Vin, 
                    a.precio_monto as Precio,
                    a.precio_tipo_moneda as TipoMoneda,
                    a.direccion_pais as Pais,
                    a.direccion_departamento as Departamento,
                    a.direccion_provincia as Provincia,
                    a.direccion_ciudad as Ciudad,
                    a.direccion_calle as Calle
                    FROM vehiculos AS a
                    WHERE NOT EXISTS
                    (
                        SELECT 1 FROM alquileres AS b
                        WHERE b.vehiculo_id = a.id,
                              b.duracion_inicio <= @EndDate AND
                              b.ducacion_final >= @StartDate AND
                              b.status = ANY(@ActiveAlquilerStatuses)
                    )

                """;
            //Mapeo estoy diciendo que vehiculo response y direccion response se mapean en un tipo vehiculo response
            var vehiculos = await connection.QueryAsync<VehiculoResponse, DireccionResponse, VehiculoResponse>
                (
                sql,
                (vehiculo, direccion) => 
                { 
                    vehiculo.Direccion = direccion; 
                    return vehiculo;
                },
                new
                { 
                    StartDate = request.fechaInicio,
                    EndDate = request.fechaFin,
                    ActiveAlquilerStatuses
                },
                splitOn:"Pais"
                );
            return vehiculos.ToList();
        }
    }
}
