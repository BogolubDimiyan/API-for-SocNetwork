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
    public class PostTagService : IPostTagService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public PostTagService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<PostTag>> GetAll()
        {
            return await _repositoryWrapper.PostTg.FindAll();
        }

        public async Task<PostTag> GetById(int id)
        {
            var ptg = await _repositoryWrapper.PostTg
                .FindCondition(x => x.Id == id);
            return ptg.First();
        }

        public async Task Create(PostTag model)
        {
            _repositoryWrapper.PostTg.Create(model);
            _repositoryWrapper.Save();
        }
        public async Task Update(PostTag model)
        {
            _repositoryWrapper.PostTg.Update(model);
            _repositoryWrapper.Save();
        }
        public async Task Delete(int id)
        {
            var ptg = await _repositoryWrapper.PostTg
                .FindCondition(x => x.Id == id);

            _repositoryWrapper.PostTg.Delete(ptg.First());
            _repositoryWrapper.Save();
        }

    }
}
