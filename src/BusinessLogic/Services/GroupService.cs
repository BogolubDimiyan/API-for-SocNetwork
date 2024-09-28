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
            _repositoryWrapper.G.Create(model);
            _repositoryWrapper.Save();
        }
        public async Task Update(Group model)
        {
            _repositoryWrapper.G.Update(model);
            _repositoryWrapper.Save();
        }
        public async Task Delete(int id)
        {
            var G = await _repositoryWrapper.G
                .FindCondition(x => x.Id == id);

            _repositoryWrapper.G.Delete(G.First());
            _repositoryWrapper.Save();
        }

    }
}
