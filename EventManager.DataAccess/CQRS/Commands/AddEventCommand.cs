using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventManager.DataAccess.Entities;

namespace EventManager.DataAccess.CQRS.Commands
{
    public class AddEventCommand : CommandBase<Event, Event>
    {
        public override async Task<Event> Execute(EventStorageDbContext context)
        {
            await context.Events.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
