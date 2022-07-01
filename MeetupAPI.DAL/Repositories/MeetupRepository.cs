using MeetupAPI.DAL.DatabaseContext;
using MeetupAPI.DAL.Entities;
using MeetupAPI.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetupAPI.DAL.Repositories
{
    public class MeetupRepository : IMeetupRepository
    {
        private readonly MeetupContext _context;

        public MeetupRepository(MeetupContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Meetup>> GetAllAsync()
        {
            return await _context.Meetups.AsNoTracking().ToListAsync();
        }

        public async Task<Meetup> GetByIdAsync(int id)
        {
            return await _context.Meetups.FindAsync(id);
        }

        public async Task CreateAsync(Meetup meetup)
        {
            await _context.Meetups.AddAsync(meetup);
        }

        public async Task DeleteAsync(int id)
        {
            var meetup = await _context.Meetups.FindAsync(id);

            _context.Meetups.Remove(meetup);
        }

        public void Edit(Meetup meetup)
        {
            _context.Update(meetup);
        }

    }
}
