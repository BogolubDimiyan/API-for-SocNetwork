using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (model.Id <= 0)
            {
                throw new ArgumentNullException(nameof(model.Id));
            }
            if (model.PostId <= 0)
            {
                throw new ArgumentNullException(nameof(model.PostId));
            }
            if (model.UserId <= 0)
            {
                throw new ArgumentNullException(nameof(model.UserId));
            }
            if (string.IsNullOrEmpty(nameof(model.Content)))
            {
                throw new ArgumentNullException(nameof(model.Content));
            }
            await _repositoryWrapper.Com.Create(model);
            await _repositoryWrapper.Save();
        }
        public async Task Update(Comment model)
        {
            await _repositoryWrapper.Com.Update(model);
            await _repositoryWrapper.Save();
        }
        public async Task Delete(int id)
        {
            var ev = await _repositoryWrapper.Com
                .FindCondition(x => x.Id == id);

            await _repositoryWrapper.Com.Delete(ev.First());
            await _repositoryWrapper.Save();
        }

    }
}
