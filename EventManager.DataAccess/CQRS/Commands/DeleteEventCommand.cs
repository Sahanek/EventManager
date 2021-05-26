using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventManager.DataAccess.Entities;

namespace EventManager.DataAccess.CQRS.Commands
{
    public class DeleteEventCommand : CommandBase<Event, Event>
    {
        public override async Task<Event> Execute(EventStorageDbContext context)
        {
            context.Events.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
