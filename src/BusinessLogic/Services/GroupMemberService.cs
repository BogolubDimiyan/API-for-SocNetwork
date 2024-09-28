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
    public class GroupMemberService : IGroupMemberService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public GroupMemberService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<GroupMember>> GetAll()
        {
            return await _repositoryWrapper.Gm.FindAll();
        }

        public async Task<GroupMember> GetById(int id)
        {
            var Gm = await _repositoryWrapper.Gm
                .FindCondition(x => x.Id == id);
            return Gm.First();
        }

        public async Task Create(GroupMember model)
        {
            _repositoryWrapper.Gm.Create(model);
            _repositoryWrapper.Save();
        }
        public async Task Update(GroupMember model)
        {
            _repositoryWrapper.Gm.Update(model);
            _repositoryWrapper.Save();
        }
        public async Task Delete(int id)
        {
            var Gm = await _repositoryWrapper.Gm
                .FindCondition(x => x.Id == id);

            _repositoryWrapper.Gm.Delete(Gm.First());
            _repositoryWrapper.Save();
        }

    }
}
