using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.DAL.DAL.DataContext;
using MyPortfolio.DAL.DAL.Models;
using MyPortfolio.DAL.DTOs;
using MyPortfolio.DAL.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.BLL.Repository
{
    public class SkillRepository : ISkillRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public SkillRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SkillResult>> AllSkills()
        {
            try
            {
                var skills = await _dbContext.Skills.ToListAsync();
                return _mapper.Map<IEnumerable<SkillResult>>(skills);
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
                var skillEntity = _mapper.Map<Skill>(skill);
                await _dbContext.Skills.AddAsync(skillEntity);
                await _dbContext.SaveChangesAsync();
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
                var skill = await _dbContext.Skills.FindAsync(skillId);
                if (skill != null)
                {
                    _dbContext.Skills.Remove(skill);
                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    throw new KeyNotFoundException($"Skill with ID {skillId} not found.");
                }
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
                var skill = await _dbContext.Skills.SingleOrDefaultAsync(s => s.Id == skillId);

                if (skill == null)
                {
                    throw new KeyNotFoundException($"Skill with ID {skillId} not found.");
                }

                return _mapper.Map<SkillResult>(skill);
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
                var existingSkill = await _dbContext.Skills.FindAsync(skill.Id);
                if (existingSkill == null)
                {
                    throw new KeyNotFoundException($"Skill with ID {skill.Id} not found.");
                }

                _mapper.Map(skill, existingSkill);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error while updating skill.", ex);
            }
        }
    }
}
