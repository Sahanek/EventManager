using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EventManager.ApplicationServices.API.Domain;
using EventManager.DataAccess.CQRS;
using EventManager.DataAccess.CQRS.Queries;
using MediatR;

namespace EventManager.ApplicationServices.API.Handlers
{
    public class GetEventsHandler : IRequestHandler<GetEventsRequest, GetEventsResponse>
    {
        private readonly IQueryExecutor _queryExecutor;
        private readonly IMapper _mapper;

        public GetEventsHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            _queryExecutor = queryExecutor;
            _mapper = mapper;
        }

        public async Task<GetEventsResponse> Handle(GetEventsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetEventsQuery()
            {
                Title = request.Title
            };
            var events = await _queryExecutor.Execute(query);
            var mappedEvents = _mapper.Map<List<Domain.Models.Event>>(events);

            var response = new GetEventsResponse()
            {
                Data = mappedEvents,
            };

            return response;
        }
    }
}
