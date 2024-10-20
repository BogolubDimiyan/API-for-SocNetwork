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
    public class NotificationService : INotificationService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public NotificationService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Notification>> GetAll()
        {
            return await _repositoryWrapper.Noti.FindAll();
        }

        public async Task<Notification> GetById(int id)
        {
            var noti = await _repositoryWrapper.Noti
                .FindCondition(x => x.Id == id);
            return noti.First();
        }

        public async Task Create(Notification model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (model.UserId == 0)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (string.IsNullOrEmpty(model.Message))
            {
                throw new ArgumentNullException(nameof(model.Message));
            }
            if (string.IsNullOrEmpty(model.Type))
            {
                throw new ArgumentNullException(nameof(model.Type));
            }
            await _repositoryWrapper.Noti.Create(model);
            await _repositoryWrapper.Save();
        }
        public async Task Update(Notification model)
        {
            await _repositoryWrapper.Noti.Update(model);
            await _repositoryWrapper.Save();
        }
        public async Task Delete(int id)
        {
            var noti = await _repositoryWrapper.Noti
                .FindCondition(x => x.Id == id);

            await _repositoryWrapper.Noti.Delete(noti.First());
            await _repositoryWrapper.Save();
        }

    }
}
