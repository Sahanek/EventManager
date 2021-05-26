using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventManager.ApplicationServices.API.Domain;
using MediatR;

namespace EventManager.Controllers
{
    public class UserController : BaseApiController
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserById([FromRoute] int userId)
        {
            var userRequest = new GetUserByIdRequest()
            {
                UserId = userId
            };

            var responseUser = await _mediator.Send(userRequest);
            if (responseUser.Data is null)
                return NotFound($"User with id:{userId} does not exist.");

            return Ok(responseUser);
        }

        [HttpPost()]
        public async Task<IActionResult> AddUser([FromBody] AddUserRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }


    }
}
