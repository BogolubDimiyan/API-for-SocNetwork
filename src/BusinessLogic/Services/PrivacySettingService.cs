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
    public class PrivascySettingService : IPrivacySettingService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public PrivascySettingService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<PrivacySetting>> GetAll()
        {
            return await _repositoryWrapper.Priv.FindAll();
        }

        public async Task<PrivacySetting> GetById(int id)
        {
            var priv = await _repositoryWrapper.Priv
                .FindCondition(x => x.Id == id);
            return priv.First();
        }

        public async Task Create(PrivacySetting model)
        {
            _repositoryWrapper.Priv.Create(model);
            _repositoryWrapper.Save();
        }
        public async Task Update(PrivacySetting model)
        {
            _repositoryWrapper.Priv.Update(model);
            _repositoryWrapper.Save();
        }
        public async Task Delete(int id)
        {
            var priv = await _repositoryWrapper.Priv
                .FindCondition(x => x.Id == id);

            _repositoryWrapper.Priv.Delete(priv.First());
            _repositoryWrapper.Save();
        }

    }
}
