using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace EventManager.ApplicationServices.API.Domain
{
    public class GetEventsRequest :  IRequest<GetEventsResponse>
    {
        public string Title { get; set; }
    }
}
