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
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (model.UserId <= 0)
            {
                throw new ArgumentNullException(nameof(model.UserId));
            }
            if (model.GroupId <= 0)
            {
                throw new ArgumentNullException(nameof(model.GroupId));
            }
            if (string.IsNullOrEmpty(model.Role))
            {
                throw new ArgumentNullException(nameof(model.Role));
            }
            await _repositoryWrapper.Gm.Create(model);
            await _repositoryWrapper.Save();
        }
        public async Task Update(GroupMember model)
        {
            await _repositoryWrapper.Gm.Update(model);
            await _repositoryWrapper.Save();
        }
        public async Task Delete(int id)
        {
            var Gm = await _repositoryWrapper.Gm
                .FindCondition(x => x.Id == id);

            await _repositoryWrapper.Gm.Delete(Gm.First());
            await _repositoryWrapper.Save();
        }

    }
}
