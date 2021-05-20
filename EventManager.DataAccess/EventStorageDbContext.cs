using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventManager.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventManager.DataAccess
{
    public class EventStorageDbContext : DbContext
    {
        public EventStorageDbContext(DbContextOptions<EventStorageDbContext> opt) : base(opt)
        {
        }
        public DbSet<Event> Events { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
