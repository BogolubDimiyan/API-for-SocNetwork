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
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (string.IsNullOrEmpty(model.ProfileVisibility))
            {
                throw new ArgumentNullException(nameof(model.ProfileVisibility));
            }
            if (string.IsNullOrEmpty(model.ProfileVisibility))
            {
                throw new ArgumentNullException(nameof(model.PostVisibility));
            }
            if (model.UserId == 0)
            {
                throw new ArgumentNullException(nameof(model.UserId));
            }


            await _repositoryWrapper.Priv.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(PrivacySetting model)
        {
            await _repositoryWrapper.Priv.Update(model);
            await _repositoryWrapper.Save();
        }
        public async Task Delete(int id)
        {
            var priv = await _repositoryWrapper.Priv
                .FindCondition(x => x.Id == id);

            await _repositoryWrapper.Priv.Delete(priv.First());
            await _repositoryWrapper.Save();
        }

    }
}
