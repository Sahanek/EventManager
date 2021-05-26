using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EventManager.ApplicationServices.API.Domain;
using EventManager.ApplicationServices.API.Domain.Models;

namespace EventManager.ApplicationServices.API.Mappings
{
    public class EventUserProfile : Profile
    {
        public EventUserProfile()
        {
            CreateMap<DataAccess.Entities.EventUser, EventUser>();

            CreateMap<AddUserToEventRequest, DataAccess.Entities.EventUser>();
        }
    }
}
