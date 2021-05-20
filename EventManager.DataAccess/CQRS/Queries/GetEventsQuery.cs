using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventManager.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventManager.DataAccess.CQRS.Queries
{
    class GetEventsQuery : QueryBase<List<Event>>
    {
        public override  Task<List<Event>> Execute(EventStorageDbContext context)
        {
            return context.Events.ToListAsync();
        }
    }
}
