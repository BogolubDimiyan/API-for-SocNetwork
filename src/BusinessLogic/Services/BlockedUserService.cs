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
    public class BlockedUserService : IBlockedUserService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public BlockedUserService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<BlockedUser>> GetAll()
        {
            return await _repositoryWrapper.Bu.FindAll();
        }

        public async Task<BlockedUser> GetById(int id)
        {
            var fr = await _repositoryWrapper.Bu
                .FindCondition(x => x.Id == id);
            return fr.First();
        }

        public async Task Create(BlockedUser model)
        {
            _repositoryWrapper.Bu.Create(model);
            _repositoryWrapper.Save();
        }
        public async Task Update(BlockedUser model)
        {
            _repositoryWrapper.Bu.Update(model);
            _repositoryWrapper.Save();
        }
        public async Task Delete(int id)
        {
            var ev = await _repositoryWrapper.Bu
                .FindCondition(x => x.Id == id);

            _repositoryWrapper.Bu.Delete(ev.First());
            _repositoryWrapper.Save();
        }

    }
}
