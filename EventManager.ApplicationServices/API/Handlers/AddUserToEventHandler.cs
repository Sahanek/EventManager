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
    public class AddUserToEventHandler : IRequestHandler<AddUserToEventRequest, AddUserToEventResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICommandExecutor _commandExecutor;

        public AddUserToEventHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            _mapper = mapper;
            _commandExecutor = commandExecutor;
        }
        public async Task<AddUserToEventResponse> Handle(AddUserToEventRequest request, CancellationToken cancellationToken)
        {
            var eventUser = _mapper.Map<EventUser>(request);
            var command = new AddUserToEventCommand() { Parameter = eventUser };
            var eventToReturn = await _commandExecutor.Execute(command);

            return new AddUserToEventResponse()
            {
                Data = _mapper.Map<Domain.Models.Event>(eventToReturn)
            };
        }
    }
}
