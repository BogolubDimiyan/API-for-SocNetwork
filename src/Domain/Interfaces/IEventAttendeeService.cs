using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IEventAttendeeService
    {
        Task<List<EventAttendee>> GetAll();
        Task<EventAttendee> GetById(int id);
        Task Create(EventAttendee model);

        Task Update(EventAttendee model);
        Task Delete(int id);
    }
}
