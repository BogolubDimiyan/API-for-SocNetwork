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
    public class CommentService : ICommentService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public CommentService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Comment>> GetAll()
        {
            return await _repositoryWrapper.Com.FindAll();
        }

        public async Task<Comment> GetById(int id)
        {
            var fr = await _repositoryWrapper.Com
                .FindCondition(x => x.Id == id);
            return fr.First();
        }

        public async Task Create(Comment model)
        {
            _repositoryWrapper.Com.Create(model);
            _repositoryWrapper.Save();
        }
        public async Task Update(Comment model)
        {
            _repositoryWrapper.Com.Update(model);
            _repositoryWrapper.Save();
        }
        public async Task Delete(int id)
        {
            var ev = await _repositoryWrapper.Com
                .FindCondition(x => x.Id == id);

            _repositoryWrapper.Com.Delete(ev.First());
            _repositoryWrapper.Save();
        }

    }
}
