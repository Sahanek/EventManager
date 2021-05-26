using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventManager.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventManager.DataAccess.CQRS.Queries
{
    public class GetUserByIdQuery : QueryBase<User>
    {
        public int Id { get; set; }
        public override async Task<User> Execute(EventStorageDbContext context)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Id == Id);
            return user;
        }
    }
}
