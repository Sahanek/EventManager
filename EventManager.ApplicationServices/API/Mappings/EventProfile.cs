using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EventManager.ApplicationServices.API.Domain.Models;

namespace EventManager.ApplicationServices.API.Mappings
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<DataAccess.Entities.Event, Event>();
        }
    }
}
