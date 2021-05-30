using Application.Interfaces;
using Application.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.AirCraftFeatures.Commands
{
    public class UpdateAirCraftCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Registration { get; set; }
        public string Location { get; set; }
        public DateTime TxnDate { get; set; }

        public class UpdateAirCraftCommandHandler : IRequestHandler<UpdateAirCraftCommand, int>
        {
            private readonly IAircraftRepository _aircraftrepository;
            public UpdateAirCraftCommandHandler(IAircraftRepository aircraftrepository)
            {
                _aircraftrepository = aircraftrepository;
            }

            public async Task<int> Handle(UpdateAirCraftCommand command, CancellationToken cancellationToken)
            {
                var aircraft = await _aircraftrepository.Get(command.Id);

                if (aircraft == null)
                {
                    return default;
                }
                else
                {
                    aircraft.Make = command.Make;
                    aircraft.Model = command.Model;
                    aircraft.Registration = command.Registration;
                    aircraft.Location = command.Location;
                    aircraft.TxnDate = command.TxnDate;
                    await _aircraftrepository.Update(aircraft);
                    return aircraft.Id;
                }
            }
        }
    }
}

