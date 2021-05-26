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
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdRequest, GetUserByIdResponse>
    {
        private readonly IQueryExecutor _queryExecutor;
        private readonly IMapper _mapper;

        public GetUserByIdHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            _queryExecutor = queryExecutor;
            _mapper = mapper;
        }
        public async Task<GetUserByIdResponse> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetUserByIdQuery()
            {
                Id = request.UserId
            };
            var user = await _queryExecutor.Execute(query);

            var mappedUser = _mapper.Map<Domain.Models.User>(user);

            var response = new GetUserByIdResponse()
            {
                Data = mappedUser
            };

            return response;
        }
    }
}
