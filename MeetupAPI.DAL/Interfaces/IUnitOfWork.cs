using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetupAPI.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IMeetupRepository Meetups { get; }
        Task SaveAsync();
    }
}
