using MyPortfolio.DAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.DAL.IService
{
    public interface IExperienceService
    {
        Task<IEnumerable<ExperienceResult>> AllExperiences();
        Task CreateExperience(CreateExperience experience);
        Task DeleteExperience(int experienceId);
        Task<ExperienceResult> GetExperienceById(int experienceId);
        Task UpdateExperience(UpdateExperience experience);
    }
}
