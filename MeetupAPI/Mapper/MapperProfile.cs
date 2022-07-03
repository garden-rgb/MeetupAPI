using AutoMapper;
using MeetupAPI.BLL.Model;
using MeetupAPI.Web.Models;

namespace MeetupAPI.Web.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Meetup, MeetupData>();
            CreateMap<MeetupData, Meetup>();
        }
    }
}
