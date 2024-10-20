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
    public class PostService : IPostService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public PostService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Post>> GetAll()
        {
            return await _repositoryWrapper.Post.FindAll();
        }

        public async Task<Post> GetById(int id)
        {
            var pt = await _repositoryWrapper.Post
                .FindCondition(x => x.Id == id);
            return pt.First();
        }

        public async Task Create(Post model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if(model.UserId == 0)
            {
                throw new ArgumentNullException(nameof(model.UserId));
            }
            if (string.IsNullOrEmpty(model.Content))
            {
                throw new ArgumentNullException(nameof(model.UserId));
            }
            if (string.IsNullOrEmpty(model.ImageUrl))
            {
                throw new ArgumentNullException(nameof(model.ImageUrl));
            }
            await _repositoryWrapper.Post.Create(model);
            await _repositoryWrapper.Save();
        }
        public async Task Update(Post model)
        {
            await _repositoryWrapper.Post.Update(model);
            await _repositoryWrapper.Save();
        }
        public async Task Delete(int id)
        {
            var pt = await _repositoryWrapper.Post
                .FindCondition(x => x.Id == id);

            await _repositoryWrapper.Post.Delete(pt.First());
            await _repositoryWrapper.Save();
        }

    }
}
