using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ILikeService
    {
        Task<List<Like>> GetAll();
        Task<Like> GetById(int id);
        Task Create(Like model);

        Task Update(Like model);
        Task Delete(int id);
    }
}
