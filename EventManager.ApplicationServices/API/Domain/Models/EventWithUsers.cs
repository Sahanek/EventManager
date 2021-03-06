using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManager.ApplicationServices.API.Domain.Models
{
    public class EventWithUsers 
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public short Participates { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public List<User> Users { get; set; }
    }
}
