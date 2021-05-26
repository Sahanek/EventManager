using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EventManager.ApplicationServices.API.Domain;
using EventManager.ApplicationServices.API.Domain.Models;
using User = EventManager.DataAccess.Entities.User;

namespace EventManager.ApplicationServices.API.Mappings
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<DataAccess.Entities.Event, Event>()
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                .ForMember(x => x.Title, y => y.MapFrom(z => z.Title))
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Participates, y => y.MapFrom(z => z.Participates))
                .ForMember(x => x.StartTime, y => y.MapFrom(z => z.StartTime))
                .ForMember(x => x.EndTime, y => y.MapFrom(z => z.EndTime));
                
            CreateMap<DataAccess.Entities.Event, EventWithUsers>()
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                .ForMember(x => x.Title, y => y.MapFrom(z => z.Title))
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Participates, y => y.MapFrom(z => z.Participates))
                .ForMember(x => x.StartTime, y => y.MapFrom(z => z.StartTime))
                .ForMember(x => x.EndTime, y => y.MapFrom(z => z.EndTime))
                .ForMember(x => x.Users, y => y.MapFrom(z => z.Users ?? new List<User>()));

            CreateMap<AddEventRequest, DataAccess.Entities.Event>()
                .ForMember(x => x.Title, y => y.MapFrom(z => z.Title))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                .ForMember(x => x.StartTime, y => y.MapFrom(z => z.StartTime))
                .ForMember(x => x.EndTime, y => y.MapFrom(z => z.EndTime));


        }
    }
}
