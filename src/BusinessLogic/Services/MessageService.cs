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
    public class MessageService : IMessageService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public MessageService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Message>> GetAll()
        {
            return await _repositoryWrapper.Message.FindAll();
        }

        public async Task<Message> GetById(int id)
        {
            var mess = await _repositoryWrapper.Message
                .FindCondition(x => x.Id == id);
            return mess.First();
        }

        public async Task Create(Message model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            await _repositoryWrapper.Message.Create(model);
            await _repositoryWrapper.Save();
        }
        public async Task Update(Message model)
        {
            await _repositoryWrapper.Message.Update(model);
            await _repositoryWrapper.Save();
        }
        public async Task Delete(int id)
        {
            var mess = await _repositoryWrapper.Message
                .FindCondition(x => x.Id == id);

            await _repositoryWrapper.Message.Delete(mess.First());
            await _repositoryWrapper.Save();
        }

    }
}
