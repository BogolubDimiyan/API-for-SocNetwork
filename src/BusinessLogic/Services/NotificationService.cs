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
            _repositoryWrapper.Noti.Create(model);
            _repositoryWrapper.Save();
        }
        public async Task Update(Notification model)
        {
            _repositoryWrapper.Noti.Update(model);
            _repositoryWrapper.Save();
        }
        public async Task Delete(int id)
        {
            var noti = await _repositoryWrapper.Noti
                .FindCondition(x => x.Id == id);

            _repositoryWrapper.Noti.Delete(noti.First());
            _repositoryWrapper.Save();
        }

    }
}
