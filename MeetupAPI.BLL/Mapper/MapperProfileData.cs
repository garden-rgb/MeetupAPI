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
    public class MapperProfileData : Profile
    {
        public MapperProfileData()
        {
            CreateMap<MeetupData, Meetup>();
            CreateMap<IEnumerable<MeetupData>, List<Meetup>>();
            CreateMap<Meetup, MeetupData>();
        }
    }
}
