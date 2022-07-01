using MeetupAPI.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetupAPI.DAL.Interfaces
{
    public interface IMeetupRepository
    {
        Task<IEnumerable<Meetup>> GetAllAsync();
        Task<Meetup> GetByIdAsync(int id);
        Task CreateAsync(Meetup meetup);
        Task DeleteAsync(int id);
        void Edit(Meetup meetup);
    }
}
