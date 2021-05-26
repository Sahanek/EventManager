using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace EventManager.ApplicationServices.API.Domain
{
    public class AddUserRequest : IRequest<AddUserResponse>
    {
        [EmailAddress]
        [Required]
        [MaxLength(100)]
        [MinLength(5)]
        public string Email { get; set; }
        [MaxLength(100)]
        [MinLength(2)]

        public string Name { get; set; }

    }
}
