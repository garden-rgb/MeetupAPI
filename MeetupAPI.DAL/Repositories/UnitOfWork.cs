using MeetupAPI.DAL.DatabaseContext;
using MeetupAPI.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetupAPI.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MeetupContext meetupContext;

        private MeetupRepository meetupRepository;

        public UnitOfWork(MeetupContext _meetupContext)
        {
            meetupContext = _meetupContext;
        }

        public IMeetupRepository Meetups
        {
            get
            {
                if (meetupRepository == null)
                    meetupRepository = new MeetupRepository(meetupContext);
                return meetupRepository;
            }
        }

        public async Task SaveAsync()
        {
            await meetupContext.SaveChangesAsync();
        }

    }
}
