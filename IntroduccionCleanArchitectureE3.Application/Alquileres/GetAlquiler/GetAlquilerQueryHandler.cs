﻿using Dapper;
using IntroduccionCleanArchitectureE3.Application.Abstractions.Data;
using IntroduccionCleanArchitectureE3.Application.Abstractions.Messaging;
using IntroduccionCleanArchitectureE3.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionCleanArchitectureE3.Application.Alquileres.GetAlquiler
{
    internal sealed class GetAlquilerQueryHandler : IQueryHandler<GetAlquilerQuery, AlquilerResponse>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetAlquilerQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<Result<AlquilerResponse>> Handle(GetAlquilerQuery request, CancellationToken cancellationToken)
        {
            using var connection = _sqlConnectionFactory.CreateConnection();

            var alquiler = await connection.QueryFirstOrDefaultAsync<AlquilerResponse>(
                sql,
                new
                {
                    request.AlquilerId
                }
                );
            return alquiler;
        }
    }
}
