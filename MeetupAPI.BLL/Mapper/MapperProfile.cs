using AutoMapper;
using MeetupAPI.BLL.Model;
using MeetupAPI.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetupAPI.BLL.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<MeetupData, Meetup>();
            CreateMap<IEnumerable<MeetupData>, Meetup>();
            CreateMap<Meetup, MeetupData>();
        }
    }
}
