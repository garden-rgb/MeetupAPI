using AutoMapper;
using MeetupAPI.BLL.Interfaces;
using MeetupAPI.BLL.Model;
using MeetupAPI.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeetupAPI.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetupController : ControllerBase
    {
        private readonly IMeetupService meetupService;
        private readonly IMapper mapper;

        private const string NotFoundErrorMessage = "This object didn't exist in the database";

        public MeetupController(IMeetupService _meetupService, IMapper _mapper)
        {
            meetupService = _meetupService;
            mapper = _mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetMeetupsAsync()
        {
            var meetupsData = await meetupService.GetAllMeetupsAsync();

            if (meetupsData == null)
            {
                return NotFound(NotFoundErrorMessage);
            }

            var meetups = mapper.Map<IEnumerable<Meetup>>(meetupsData);

            return Ok(meetups);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMeetupByIdAsync(int id)
        {
            var meetupData = await meetupService.GetByIdAsync(id);

            if (meetupData == null)
            {
                return NotFound(NotFoundErrorMessage);
            }

            var meetup = mapper.Map<Meetup>(meetupData);

            return Ok(meetup);
        }


        [HttpPost]
        public async Task<IActionResult> CreateMeetupAsync(Meetup meetup)
        {
            var meetupData = mapper.Map<MeetupData>(meetup);

            await meetupService.CreateMeetupAsync(meetupData);

            return Ok(meetupData);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> EditMeetup(int id, Meetup meetup)
        {
            var meetupData = await meetupService.GetByIdAsync(id);

            if (meetupData == null)
            {
                return NotFound(NotFoundErrorMessage);
            }

            mapper.Map<Meetup>(meetupData);
            meetup.Id = meetupData.Id;

            if (id != meetup.Id)
            {
                return BadRequest();
            }
            
            var meetupDataToSave = mapper.Map<MeetupData>(meetup);

            await meetupService.EditMeetupAsync(meetupDataToSave);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMeetup(int id)
        {
            var meetupData = await meetupService.GetByIdAsync(id);

            if (meetupData == null)
            {
                return NotFound(NotFoundErrorMessage);
            }

            await meetupService.DeleteMeetupAsync(id);

            return NoContent();
        }

    }
}
