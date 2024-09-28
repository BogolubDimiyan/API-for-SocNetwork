using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IEventService
    {
        Task<List<Event>> GetAll();
        Task<Event> GetById(int id);
        Task Create(Event model);

        Task Update(Event model);
        Task Delete(int id);
    }
}
