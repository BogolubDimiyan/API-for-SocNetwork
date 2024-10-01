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
    public class EventService : IEventService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public EventService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Event>> GetAll()
        {
            return await _repositoryWrapper.Ev.FindAll();
        }

        public async Task<Event> GetById(int id)
        {
            var fr = await _repositoryWrapper.Ev
                .FindCondition(x => x.Id == id);
            return fr.First();
        }

        public async Task Create(Event model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            await _repositoryWrapper.Ev.Create(model);
            await _repositoryWrapper.Save();
        }
        public async Task Update(Event model)
        {
            await _repositoryWrapper.Ev.Update(model);
            await _repositoryWrapper.Save();
        }
        public async Task Delete(int id)
        {
            var ev = await _repositoryWrapper.Ev
                .FindCondition(x => x.Id == id);

            await _repositoryWrapper.Ev.Delete(ev.First());
            await _repositoryWrapper.Save();
        }

    }
}
