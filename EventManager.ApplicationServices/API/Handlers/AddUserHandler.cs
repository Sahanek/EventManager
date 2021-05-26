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
    public class AddUserHandler : IRequestHandler<AddUserRequest, AddUserResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICommandExecutor _commandExecutor;


        public AddUserHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            _mapper = mapper;
            _commandExecutor = commandExecutor;
        }
        public async Task<AddUserResponse> Handle(AddUserRequest request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);
            var command = new AddUserCommand() { Parameter = user };
            var userToReturn = await _commandExecutor.Execute(command);

            return new AddUserResponse()
            {
                Data = _mapper.Map<Domain.Models.User>(userToReturn)
            };
        }
    }
}
