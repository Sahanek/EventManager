using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EventManager.ApplicationServices.API.Domain;
using EventManager.DataAccess;
using EventManager.DataAccess.Entities;
using MediatR;

namespace EventManager.ApplicationServices.API.Handlers
{
    public class GetUsersHandler : IRequestHandler<GetUsersRequest,GetUsersResponse>
    {
        private readonly IRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public GetUsersHandler(IRepository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<GetUsersResponse> Handle(GetUsersRequest request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAll();

            var mappedUsers = _mapper.Map<List<Domain.Models.User>>(users);

            var response = new GetUsersResponse()
            {
                Data = mappedUsers
            };

            return response;
        }
    }
}
