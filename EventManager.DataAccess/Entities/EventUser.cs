using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManager.DataAccess.Entities
{
    public class EventUser : EntityBase
    {
        public int EventId { get; set; }
        public int UserId { get; set; }
    }
}
