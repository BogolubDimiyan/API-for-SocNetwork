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
    public class GroupService : IGroupService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public GroupService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Group>> GetAll()
        {
            return await _repositoryWrapper.G.FindAll();
        }

        public async Task<Group> GetById(int id)
        {
            var G = await _repositoryWrapper.G
                .FindCondition(x => x.Id == id);
            return G.First();
        }

        public async Task Create(Group model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (string.IsNullOrEmpty(model.Name))
            {
                throw new ArgumentNullException(nameof(model.Name));
            }
            if (string.IsNullOrEmpty(model.Description))
            {
                throw new ArgumentNullException(nameof(model.Description));
            }
            if (model.CreatedBy == 0)
            {
                throw new ArgumentNullException(nameof(model.CreatedBy));
            }
            await _repositoryWrapper.G.Create(model);
            await _repositoryWrapper.Save();
        }
        public async Task Update(Group model)
        {
            await _repositoryWrapper.G.Update(model);
            await _repositoryWrapper.Save();
        }
        public async Task Delete(int id)
        {
            var G = await _repositoryWrapper.G
                .FindCondition(x => x.Id == id);

            await _repositoryWrapper.G.Delete(G.First());
            await _repositoryWrapper.Save();
        }

    }
}
