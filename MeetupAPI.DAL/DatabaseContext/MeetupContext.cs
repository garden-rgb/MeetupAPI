using MeetupAPI.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetupAPI.DAL.DatabaseContext
{
    public class MeetupContext : DbContext
    {
        public DbSet<Meetup> Meetups { get; set; } = null!;
        public MeetupContext(DbContextOptions<MeetupContext> options) : base(options)
        {
            Database.EnsureCreated();   
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Meetup>().HasData(
            new Meetup { Id = 1, Name = "FirstMeetup", Description = "First meetup today", Organizer = "Modsen", Speaker = "Tom Holland", PlaceOfEvent = "Minsk, Belarus", TimeOfEvent = DateTime.UtcNow },
            new Meetup { Id = 2, Name = "SecondMeetup", Description = "Second meetup today", Organizer = "Modsen", Speaker = "James", PlaceOfEvent = "Warszawa, Poland", TimeOfEvent = DateTime.UtcNow },
            new Meetup { Id = 3, Name = "Thirdeetup", Description = "Third meetup today", Organizer = "Modsen", Speaker = "Luke", PlaceOfEvent = "NY, USA", TimeOfEvent = DateTime.UtcNow }
            );
        }

    }
}
