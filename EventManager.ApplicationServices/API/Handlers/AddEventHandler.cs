using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EventManager.ApplicationServices.API.Domain;
using EventManager.DataAccess.CQRS;
using EventManager.DataAccess.CQRS.Commands;
using EventManager.DataAccess.Entities;
using MediatR;

namespace EventManager.ApplicationServices.API.Handlers
{
    public class AddEventHandler :  IRequestHandler<AddEventRequest, AddEventResponse>
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IMapper _mapper;

        public AddEventHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            _commandExecutor = commandExecutor;
            _mapper = mapper;
        }
        public async Task<AddEventResponse> Handle(AddEventRequest request, CancellationToken cancellationToken)
        {
            var eventEntity = _mapper.Map<Event>(request);
            var command = new AddEventCommand() {Parameter = eventEntity};
            var eventFromDb = await _commandExecutor.Execute(command);

            return new AddEventResponse()
            {
                Data = _mapper.Map<Domain.Models.Event>(eventFromDb)
            };

        }
    }
}
