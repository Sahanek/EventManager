using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManager.DataAccess.Entities
{
    public class Event : EntityBase
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(300)]
        public string Description { get; set; }
        [Range(0,25)]
        public short Participates { get; set; }
        [Required]
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public List<User> Users { get; set; } = new ();
    }
}
