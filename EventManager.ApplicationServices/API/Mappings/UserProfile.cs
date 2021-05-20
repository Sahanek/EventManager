using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EventManager.ApplicationServices.API.Domain.Models;

namespace EventManager.ApplicationServices.API.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<DataAccess.Entities.User, User>();
        }
    }
}
