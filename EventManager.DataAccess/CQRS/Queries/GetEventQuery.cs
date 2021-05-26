using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventManager.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventManager.DataAccess.CQRS.Queries
{
    public class GetEventQuery : QueryBase<Event>
    {
        public int Id { get; set; }
        public override async Task<Event> Execute(EventStorageDbContext context)
        {
            var eventFromDb = await context.Events
                .Include(x => x.Users)
                .FirstOrDefaultAsync(x => x.Id == Id);
            return eventFromDb;
        }
    }
}
