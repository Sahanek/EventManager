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
using EventManager.DataAccess.CQRS.Queries;

using MediatR;

namespace EventManager.ApplicationServices.API.Handlers
{
    class GetEventByIdHandler : IRequestHandler<GetEventByIdRequest, GetEventByIdResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQueryExecutor _queryExecutor;

        public GetEventByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            _mapper = mapper;
            _queryExecutor = queryExecutor;
        }
        public async Task<GetEventByIdResponse> Handle(GetEventByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetEventQuery()
            {
                Id = request.EventId
            };

            var eventFromDb = await _queryExecutor.Execute(query);
            var mappedEvent = _mapper.Map<Event>(eventFromDb);
            var response = new GetEventByIdResponse()
            {
                Data = mappedEvent
            };

            return response;
        }
    }
}
