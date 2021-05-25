using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventManager.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventManager.DataAccess.CQRS.Queries
{
    public class GetEventsQuery : QueryBase<List<Event>>
    {
        public string Title { get; set; }
        public override  Task<List<Event>> Execute(EventStorageDbContext context)
        {
            return Title is null
                ? context.Events.ToListAsync()
                : context.Events.Where(x => x.Title.ToLower().Contains(Title.ToLower())).ToListAsync();
        }
    }
}
