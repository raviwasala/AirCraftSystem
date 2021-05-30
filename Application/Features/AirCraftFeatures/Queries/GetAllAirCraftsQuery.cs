using Application.Interfaces;
using Application.Repository;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.AirCraftFeatures.Queries
{
    public class GetAllAirCraftsQuery : IRequest<IEnumerable<AirCraft>>
    {

        public class GetAllAirCraftsQueryHandler : IRequestHandler<GetAllAirCraftsQuery, IEnumerable<AirCraft>>
        {
            private readonly IAircraftRepository _aircraftrepository;
            public GetAllAirCraftsQueryHandler(IAircraftRepository aircraftrepository)
            {
                _aircraftrepository = aircraftrepository;
            }

            public async Task<IEnumerable<AirCraft>> Handle(GetAllAirCraftsQuery query, CancellationToken cancellationToken)
            {
                var aircraftList = await _aircraftrepository.GetAll();
                if (aircraftList == null)
                {
                    return null;
                }
                return aircraftList;
            }
        }
    }
}

