using AutoMapper;
using MeetupAPI.BLL.Interfaces;
using MeetupAPI.BLL.Model;
using MeetupAPI.DAL.Entities;
using MeetupAPI.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetupAPI.BLL.Services
{
    public class MeetupService : IMeetupService
    {
        IUnitOfWork Database { get; set; }
        private readonly IMapper _mapper;

        public MeetupService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            Database = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MeetupData>> GetAllMeetupsAsync()
        {
            var meetups = await Database.Meetups.GetAllAsync();
            var meetupsData = _mapper.Map<IEnumerable<MeetupData>>(meetups);

            return meetupsData;
        }

        public async Task<MeetupData> GetByIdAsync(int id)
        {
            var meetup = await Database.Meetups.GetByIdAsync(id);

            var meetupData = _mapper.Map<MeetupData>(meetup);

            return meetupData;
        }
        public async Task EditMeetupAsync(MeetupData meetupData)
        {
            var meetup = _mapper.Map<Meetup>(meetupData);
            Database.Meetups.Edit(meetup);

            await Database.SaveAsync();
        }

        public async Task CreateMeetupAsync(MeetupData meetupData)
        {
            var meetup = _mapper.Map<Meetup>(meetupData);

            await Database.Meetups.CreateAsync(meetup);
            await Database.SaveAsync();
        }

        public async Task DeleteMeetupAsync(int id)
        {
            await Database.Meetups.DeleteAsync(id);

            await Database.SaveAsync();
        }

    }
}
