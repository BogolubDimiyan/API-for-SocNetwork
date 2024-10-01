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
    public class FriendService : IFriendService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public FriendService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Friend>> GetAll()
        {
            return await _repositoryWrapper.Friend.FindAll();
        }

        public async Task<Friend> GetById(int id)
        {
            var fr = await _repositoryWrapper.Friend
                .FindCondition(x => x.Id == id);
            return fr.First();
        }

        public async Task Create(Friend model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            await _repositoryWrapper.Friend.Create(model);
            await _repositoryWrapper.Save();
        }
        public async Task Update(Friend model)
        {
            await _repositoryWrapper.Friend.Update(model);
            await _repositoryWrapper.Save();
        }
        public async Task Delete(int id)
        {
            var fr = await _repositoryWrapper.Friend
                .FindCondition(x => x.Id == id);

            await _repositoryWrapper.Friend.Delete(fr.First());
            await _repositoryWrapper.Save();
        }

    }
}
