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
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
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
            return Ok(response);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddEvent([FromBody] AddEventRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
