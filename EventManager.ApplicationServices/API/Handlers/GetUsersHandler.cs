using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EventManager.ApplicationServices.API.Domain;
using EventManager.DataAccess;
using EventManager.DataAccess.CQRS;
using EventManager.DataAccess.CQRS.Queries;
using EventManager.DataAccess.Entities;
using MediatR;

namespace EventManager.ApplicationServices.API.Handlers
{
    public class GetUsersHandler : IRequestHandler<GetUsersRequest,GetUsersResponse>
    {
        private readonly IQueryExecutor _queryExecutor;
        private readonly IMapper _mapper;

        public GetUsersHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            _queryExecutor = queryExecutor;
            _mapper = mapper;
        }
        public async Task<GetUsersResponse> Handle(GetUsersRequest request, CancellationToken cancellationToken)
        {
            var query = new GetUsersQuery();
            var users = await _queryExecutor.Execute(query);

            var mappedUsers = _mapper.Map<List<Domain.Models.User>>(users);

            var response = new GetUsersResponse()
            {
                Data = mappedUsers
            };

            return response;
        }
    }
}
