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
    public class ExperienceRepository : IExperienceRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public ExperienceRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ExperienceResult>> AllExperiences()
        {
            try
            {
                var experiences = await _dbContext.Experiences.ToListAsync();
                return _mapper.Map<IEnumerable<ExperienceResult>>(experiences);
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
                var experienceEntity = _mapper.Map<Experience>(experience);
                await _dbContext.Experiences.AddAsync(experienceEntity);
                await _dbContext.SaveChangesAsync();
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
                var experience = await _dbContext.Experiences.FindAsync(experienceId);
                if (experience != null)
                {
                    _dbContext.Experiences.Remove(experience);
                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    throw new KeyNotFoundException($"Experience with ID {experienceId} not found.");
                }
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
                var experience = await _dbContext.Experiences.SingleOrDefaultAsync(e => e.Id == experienceId);

                if (experience == null)
                {
                    throw new KeyNotFoundException($"Experience with ID {experienceId} not found.");
                }

                return _mapper.Map<ExperienceResult>(experience);
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
                var existingExperience = await _dbContext.Experiences.FindAsync(experience.Id);
                if (existingExperience == null)
                {
                    throw new KeyNotFoundException($"Experience with ID {experience.Id} not found.");
                }

                _mapper.Map(experience, existingExperience);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error while updating experience.", ex);
            }
        }
    }
}
