using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class EventAttendeeService : IEventAttendeeService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public EventAttendeeService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<EventAttendee>> GetAll()
        {
            return await _repositoryWrapper.Ea.FindAll();
        }

        public async Task<EventAttendee> GetById(int id)
        {
            var fr = await _repositoryWrapper.Ea
                .FindCondition(x => x.Id == id);
            return fr.First();
        }

        public async Task Create(EventAttendee model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            await _repositoryWrapper.Ea.Create(model);
            await _repositoryWrapper.Save();
        }
        public async Task Update(EventAttendee model)
        {
            await _repositoryWrapper.Ea.Update(model);
            await _repositoryWrapper.Save();
        }
        public async Task Delete(int id)
        {
            var ev = await _repositoryWrapper.Ea
                .FindCondition(x => x.Id == id);

            await _repositoryWrapper.Ea.Delete(ev.First());
            await _repositoryWrapper.Save();
        }

    }
}
