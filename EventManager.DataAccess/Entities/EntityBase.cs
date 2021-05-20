using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManager.DataAccess.Entities
{
    public class EntityBase
    {
        [Required]
        public int Id { get; set; }
    }
}
