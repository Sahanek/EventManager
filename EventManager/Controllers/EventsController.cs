using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventManager.ApplicationServices.API.Domain;
using MediatR;

namespace EventManager.Controllers
{

    public class EventsController : BaseApiController
    {
        private readonly IMediator _mediator;

        public EventsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllEvents([FromQuery] GetEventsRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("{eventId}")]
        public async Task<IActionResult> GetById([FromRoute] int eventId)
        {
            var request = new GetEventByIdRequest()
            {
                EventId = eventId
            };
            var response = await _mediator.Send(request);

            if (response.Data is null)
                return NotFound($"Event with id:{eventId} does not exist.");

            return Ok(response);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddEvent([FromBody] AddEventRequest request)
        {
            var response = await _mediator.Send(request);
            return CreatedAtAction(nameof(GetById), new {eventId = response.Data.Id}, response.Data);
        }

        [HttpPut("{eventId}/user/{userId}")]
        public async Task<IActionResult> AddUserToEvent([FromRoute] int eventId, [FromRoute] int userId)
        {
            var requestEvent = new GetEventByIdRequest()
            {
                EventId = eventId
            };
            var responseEvent = await _mediator.Send(requestEvent);

            if (responseEvent.Data is null) 
                return NotFound($"Event with id:{eventId} does not exist.");

            if (responseEvent.Data.Participates == 25)
                return BadRequest("Event is full.");

            var userRequest = new GetUserByIdRequest()
            {
                UserId = userId
            };

            var responseUser = await _mediator.Send(userRequest);

            if (responseUser.Data is null)
                return NotFound($"User with id:{userId} does not exist.");

            if (responseEvent.Data.Users.Exists(x => x.Id == userId)) 
                return BadRequest("The user has already added this event.");

            var addUserToEventRequest = new AddUserToEventRequest()
            {
                EventId = eventId,
                UserId = userId
            };

            var response = await _mediator.Send(addUserToEventRequest);
            return Ok(response);
        }

        [HttpDelete("{eventId}")]
        public async Task<IActionResult> DeleteEvent([FromRoute] int eventId)
        {
            var request = new DeleteEventRequest()
            {
                EventId = eventId
            };
            var response = await _mediator.Send(request);


            return Ok(response);
        }
    }
}
