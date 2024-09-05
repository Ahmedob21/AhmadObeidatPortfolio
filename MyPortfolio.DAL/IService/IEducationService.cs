using MyPortfolio.DAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.DAL.IService
{
    public interface IEducationService
    {
        Task<IEnumerable<EducationResult>> AllEducations();
        Task CreateEducation(CreateEducation education);
        Task DeleteEducation(int educationId);
        Task<EducationResult> GetEducationById(int educationId);
        Task UpdateEducation(UpdateEducation education);

    }
}
