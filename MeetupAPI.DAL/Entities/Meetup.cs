using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetupAPI.DAL.Entities
{
    public class Meetup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Organizer { get; set; }
        public string Speaker { get; set; }
        public string PlaceOfEvent { get; set; }
        public DateTime TimeOfEvent { get; set; }
    }
}
