using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventManager.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventManager.DataAccess.CQRS.Queries
{
    public class GetUsersQuery : QueryBase<List<User>>
    {
        public override Task<List<User>> Execute(EventStorageDbContext context)
        {
            return context.Users.ToListAsync();
        }
    }
}
