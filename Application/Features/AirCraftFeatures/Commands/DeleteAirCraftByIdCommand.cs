using Application.Interfaces;
using Application.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.AirCraftFeatures.Commands
{
    public class DeleteAirCraftByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteAirCraftByIdCommandHandler : IRequestHandler<DeleteAirCraftByIdCommand, int>
        {
            private readonly IAircraftRepository _aircraftrepository;
            public DeleteAirCraftByIdCommandHandler(IAircraftRepository aircraftrepository)
            {
                _aircraftrepository = aircraftrepository;
            }

            public async Task<int> Handle(DeleteAirCraftByIdCommand command, CancellationToken cancellationToken)
            {
                var airCraft = await _aircraftrepository.Get(command.Id);
                if (airCraft == null) return default;
                await _aircraftrepository.Delete(airCraft.Id);
                return airCraft.Id;
            }
        }
    }
}

