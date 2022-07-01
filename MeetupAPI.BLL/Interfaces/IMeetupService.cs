using MeetupAPI.BLL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetupAPI.BLL.Interfaces
{
    public interface IMeetupService
    {
        Task<IEnumerable<MeetupData>> GetAllMeetupsAsync();
        Task<MeetupData> GetByIdAsync(int id);
        Task CreateMeetupAsync(MeetupData meetupData);
        Task EditMeetupAsync(MeetupData meetupData);
        Task DeleteMeetupAsync(int id);

    }
}
