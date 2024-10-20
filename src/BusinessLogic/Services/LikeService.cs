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
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (model.PostId == 0) 
            { 
                throw new ArgumentNullException(nameof(model.PostId)); 
            }
            if (model.UserId == 0)
            {
                throw new ArgumentNullException(nameof(model.UserId));
            }
            await _repositoryWrapper.Like.Create(model);
            await _repositoryWrapper.Save();
        }
        public async Task Update(Like model)
        {
            await _repositoryWrapper.Like.Update(model);
            await _repositoryWrapper.Save();
        }
        public async Task Delete(int id)
        {
            var Like = await _repositoryWrapper.Like
                .FindCondition(x => x.Id == id);

            await _repositoryWrapper.Like.Delete(Like.First());
            await _repositoryWrapper.Save();
        }

    }
}
