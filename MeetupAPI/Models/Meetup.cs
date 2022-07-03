using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace MeetupAPI.Web.Models
{
    public class Meetup
    {
        [SwaggerSchema(ReadOnly = true)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Organizer { get; set; }
        public string Speaker { get; set; }
        public string PlaceOfEvent { get; set; }
        public DateTime TimeOfEvent { get; set; }
    }
}
