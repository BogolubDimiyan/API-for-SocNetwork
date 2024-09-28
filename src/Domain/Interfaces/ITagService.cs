using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ITagService
    {
        Task<List<Tag>> GetAll();
        Task<Tag> GetById(int id);
        Task Create(Tag model);

        Task Update(Tag model);
        Task Delete(int id);
    }
}
