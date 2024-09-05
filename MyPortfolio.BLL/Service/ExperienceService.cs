using MyPortfolio.DAL.DTOs;
using MyPortfolio.DAL.IRepository;
using MyPortfolio.DAL.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.BLL.Service
{
    public class ExperienceService : IExperienceService
    {
        private readonly IExperienceRepository _experienceRepository;

        public ExperienceService(IExperienceRepository experienceRepository)
        {
            _experienceRepository = experienceRepository;
        }

        public async Task<IEnumerable<ExperienceResult>> AllExperiences()
        {
            try
            {
                return await _experienceRepository.AllExperiences();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error while retrieving all experiences.", ex);
            }
        }

        public async Task CreateExperience(CreateExperience experience)
        {
            try
            {
                await _experienceRepository.CreateExperience(experience);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error while creating experience.", ex);
            }
        }

        public async Task DeleteExperience(int experienceId)
        {
            try
            {
                await _experienceRepository.DeleteExperience(experienceId);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error while deleting experience.", ex);
            }
        }

        public async Task<ExperienceResult> GetExperienceById(int experienceId)
        {
            try
            {
                return await _experienceRepository.GetExperienceById(experienceId);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error while retrieving experience by ID.", ex);
            }
        }

        public async Task UpdateExperience(UpdateExperience experience)
        {
            try
            {
                await _experienceRepository.UpdateExperience(experience);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error while updating experience.", ex);
            }
        }
    }
}
