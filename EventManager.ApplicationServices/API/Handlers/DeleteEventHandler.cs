using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EventManager.ApplicationServices.API.Domain;
using EventManager.ApplicationServices.API.Domain.Models;
using EventManager.DataAccess.CQRS;
using EventManager.DataAccess.CQRS.Commands;
using EventManager.DataAccess.CQRS.Queries;
using MediatR;

namespace EventManager.ApplicationServices.API.Handlers
{
    public class DeleteEventHandler : IRequestHandler<DeleteEventRequest, DeleteEventResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQueryExecutor _queryExecutor;
        private readonly ICommandExecutor _commandExecutor;

        public DeleteEventHandler(IMapper mapper, IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
        {
            _mapper = mapper;
            _queryExecutor = queryExecutor;
            _commandExecutor = commandExecutor;
        }
        public async Task<DeleteEventResponse> Handle(DeleteEventRequest request, CancellationToken cancellationToken)
        {
            var query = new GetEventQuery()
            {
                Id = request.EventId
            };
            var eventFromDb = await _queryExecutor.Execute(query);
            if (eventFromDb is null) return null;

            var command = new DeleteEventCommand()
            {
                Parameter = eventFromDb
            };
            var deletedEvent = await _commandExecutor.Execute(command);
            var mappedEvent = _mapper.Map<Domain.Models.Event>(deletedEvent);
            var response = new DeleteEventResponse()
            {
                Data = mappedEvent
            };

            return response;
        }
    }
}
