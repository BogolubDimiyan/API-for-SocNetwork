using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IBlockedUserService
    {
        Task<List<BlockedUser>> GetAll();
        Task<BlockedUser> GetById(int id);
        Task Create(BlockedUser model);

        Task Update(BlockedUser model);
        Task Delete(int id);
    }
}
