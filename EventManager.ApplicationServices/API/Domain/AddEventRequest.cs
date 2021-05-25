using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace EventManager.ApplicationServices.API.Domain
{
    public class AddEventRequest : IRequest<AddEventResponse>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StarTime { get; set; }
        public DateTime EndTime { get; set; }
        
    }
}
