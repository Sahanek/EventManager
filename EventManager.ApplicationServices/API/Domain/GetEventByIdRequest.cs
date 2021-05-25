using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace EventManager.ApplicationServices.API.Domain
{
    public class GetEventByIdRequest : IRequest<GetEventByIdResponse>
    {
        public int EventId { get; set; }
    }
}
