using Application.Interfaces;
using Application.Repository;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.AirCraftFeatures.Queries
{
    public class GetAirCraftByIdQuery : IRequest<AirCraft>
    {
        public int Id { get; set; }
        public class GetAirCraftByIdQueryHandler : IRequestHandler<GetAirCraftByIdQuery, AirCraft>
        {
            private readonly IAircraftRepository _aircraftrepository;
            public GetAirCraftByIdQueryHandler(IAircraftRepository aircraftrepository)
            {
                _aircraftrepository = aircraftrepository;
            }

            public async Task<AirCraft> Handle(GetAirCraftByIdQuery query, CancellationToken cancellationToken)
            {
                var aircraft = await _aircraftrepository.Get(query.Id);
                if (aircraft == null) return null;
                return aircraft;
            }
        }
    }
}

