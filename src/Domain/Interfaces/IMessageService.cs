using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IMessageService
    {
        Task<List<Message>> GetAll();
        Task<Message> GetById(int id);
        Task Create(Message model);

        Task Update(Message model);
        Task Delete(int id);
    }
}
