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
            new Meetup { Id = 1, Name = "Tom", Age = 37 },
            new Meetup { Id = 2, Name = "Bob", Age = 41 },
            new Meetup { Id = 3, Name = "Sam", Age = 24 }
            );
        }

    }
}
