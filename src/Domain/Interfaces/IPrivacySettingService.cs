using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPrivacySettingService
    {
        Task<List<PrivacySetting>> GetAll();
        Task<PrivacySetting> GetById(int id);
        Task Create(PrivacySetting model);

        Task Update(PrivacySetting model);
        Task Delete(int id);
    }
}
