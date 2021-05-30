using Application.Interfaces;
using Application.Repository;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.AirCraftFeatures.Commands
{
    public class CreateAirCraftCommand : IRequest<int>
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string Registration { get; set; }
        public string Location { get; set; }
        public DateTime TxnDate { get; set; }

        public class CreateAirCraftCommandHandler : IRequestHandler<CreateAirCraftCommand, int>
        {
            private readonly IAircraftRepository _aircraftrepository;
            public CreateAirCraftCommandHandler(IAircraftRepository aircraftrepository)
            {
                _aircraftrepository = aircraftrepository;
            }
            public async Task<int> Handle(CreateAirCraftCommand command, CancellationToken cancellationToken)
            {
                var aircraft = new AirCraft();
                aircraft.Make = command.Make;
                aircraft.Model = command.Model;
                aircraft.Registration = command.Registration;
                aircraft.Location = command.Location;
                aircraft.TxnDate = command.TxnDate;

                await _aircraftrepository.Add(aircraft);
                return aircraft.Id;
            }
        }
    }
}



