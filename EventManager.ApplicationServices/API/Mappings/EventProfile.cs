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
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<DataAccess.Entities.Event, Event>()
                .ForMember(x => x.Description, y => y.MapFrom( z => z.Description))
                .ForMember(x => x.Title, y => y.MapFrom(z => z.Title))
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Participates, y => y.MapFrom(z => z.Participates));

            CreateMap<AddEventRequest, DataAccess.Entities.Event>()
                .ForMember(x => x.Title, y => y.MapFrom(z => z.Title))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description));


        }
    }
}
