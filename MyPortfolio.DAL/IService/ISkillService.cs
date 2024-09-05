using MyPortfolio.DAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.DAL.IService
{
    public interface ISkillService
    {
        Task<IEnumerable<SkillResult>> AllSkills();
        Task CreateSkill(CreateSkill skill);
        Task DeleteSkill(int skillId);
        Task<SkillResult> GetSkillById(int skillId);
        Task UpdateSkill(UpdateSkill skill);
    }
}
