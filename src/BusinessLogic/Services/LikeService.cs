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
    public class LikeService : ILikeService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public LikeService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Like>> GetAll()
        {
            return await _repositoryWrapper.Like.FindAll();
        }

        public async Task<Like> GetById(int id)
        {
            var Like = await _repositoryWrapper.Like
                .FindCondition(x => x.Id == id);
            return Like.First();
        }

        public async Task Create(Like model)
        {
            _repositoryWrapper.Like.Create(model);
            _repositoryWrapper.Save();
        }
        public async Task Update(Like model)
        {
            _repositoryWrapper.Like.Update(model);
            _repositoryWrapper.Save();
        }
        public async Task Delete(int id)
        {
            var Like = await _repositoryWrapper.Like
                .FindCondition(x => x.Id == id);

            _repositoryWrapper.Like.Delete(Like.First());
            _repositoryWrapper.Save();
        }

    }
}
