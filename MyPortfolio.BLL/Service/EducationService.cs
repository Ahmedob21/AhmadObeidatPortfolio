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
    public class EducationService : IEducationService
    {
        private readonly IEducationRepository _educationRepository;

        public EducationService(IEducationRepository educationRepository)
        {
            _educationRepository = educationRepository;
        }

        public async Task<IEnumerable<EducationResult>> AllEducations()
        {
            try
            {
                return await _educationRepository.AllEducations();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error while retrieving all educations.", ex);
            }
        }

        public async Task CreateEducation(CreateEducation education)
        {
            try
            {
                await _educationRepository.CreateEducation(education);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error while creating education.", ex);
            }
        }

        public async Task DeleteEducation(int educationId)
        {
            try
            {
                await _educationRepository.DeleteEducation(educationId);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error while deleting education.", ex);
            }
        }

        public async Task<EducationResult> GetEducationById(int educationId)
        {
            try
            {
                return await _educationRepository.GetEducationById(educationId);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error while retrieving education by ID.", ex);
            }
        }

        public async Task UpdateEducation(UpdateEducation education)
        {
            try
            {
                await _educationRepository.UpdateEducation(education);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error while updating education.", ex);
            }
        }
    }
}
