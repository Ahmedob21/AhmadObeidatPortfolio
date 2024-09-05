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
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _skillRepository;

        public SkillService(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public async Task<IEnumerable<SkillResult>> AllSkills()
        {
            try
            {
                return await _skillRepository.AllSkills();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error while retrieving all skills.", ex);
            }
        }

        public async Task CreateSkill(CreateSkill skill)
        {
            try
            {
                await _skillRepository.CreateSkill(skill);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error while creating skill.", ex);
            }
        }

        public async Task DeleteSkill(int skillId)
        {
            try
            {
                await _skillRepository.DeleteSkill(skillId);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error while deleting skill.", ex);
            }
        }

        public async Task<SkillResult> GetSkillById(int skillId)
        {
            try
            {
                return await _skillRepository.GetSkillById(skillId);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error while retrieving skill by ID.", ex);
            }
        }

        public async Task UpdateSkill(UpdateSkill skill)
        {
            try
            {
                await _skillRepository.UpdateSkill(skill);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error while updating skill.", ex);
            }
        }
    }
}
