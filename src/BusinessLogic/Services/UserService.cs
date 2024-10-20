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
    public class UserService : IUserService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public UserService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<User>> GetAll()
        {
            return await _repositoryWrapper.User.FindAll();
        }

        public async Task<User> GetById(int id)
        {
            var user = await _repositoryWrapper.User
                .FindCondition(x => x.Id == id);
            return user.First();
        }

        public async Task Create(User model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (string.IsNullOrEmpty(model.FirstName))
            {
                throw new ArgumentNullException(nameof(model.FirstName));
            }
            if (string.IsNullOrEmpty(model.LastName))
            {
                throw new ArgumentNullException(nameof(model.LastName));
            }
            if (string.IsNullOrEmpty(model.Username))
            {
                throw new ArgumentNullException(nameof(model.Username));
            }
            if (string.IsNullOrEmpty(model.Email))
            {
                throw new ArgumentNullException(nameof(model.Email));
            }
            if (string.IsNullOrEmpty(model.Gender))
            {
                throw new ArgumentNullException(nameof(model.Gender));
            }
            if (string.IsNullOrEmpty(model.ProfilePicture))
            {
                throw new ArgumentNullException(nameof(model.ProfilePicture));
            }
            if (string.IsNullOrEmpty(model.Bio))
            {
                throw new ArgumentNullException(nameof(model.Bio));
            }
            await _repositoryWrapper.User.Create(model);
            await _repositoryWrapper.Save();
        }
        public async Task Update(User model)
        {
            await _repositoryWrapper.User.Update(model);
            await _repositoryWrapper.Save();
        }
        public async Task Delete(int id)
        {
            var user = await _repositoryWrapper.User
                .FindCondition(x => x.Id == id);

            await _repositoryWrapper.User.Delete(user.First());
            await _repositoryWrapper.Save();
        }

    }
}
