using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventManager.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventManager.DataAccess.CQRS.Commands
{
    public class AddUserToEventCommand : CommandBase<EventUser, Event>
    {
        public override async Task<Event> Execute(EventStorageDbContext context)
        {
            var eventFromDb =  await context.Events.FirstOrDefaultAsync(x => x.Id == this.Parameter.EventId);
            var userFromDb = await context.Users.FirstOrDefaultAsync(x => x.Id == this.Parameter.UserId);
            eventFromDb.Users.Add(userFromDb);
            eventFromDb.Participates++;
            context.Update(eventFromDb);
            await context.SaveChangesAsync();
            return eventFromDb;
        }
    }
}
