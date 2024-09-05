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
    public class EducationRepository : IEducationRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public EducationRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EducationResult>> AllEducations()
        {
            try
            {
                var educations = await _dbContext.Educations.ToListAsync();
                return _mapper.Map<IEnumerable<EducationResult>>(educations);
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
                var educationEntity = _mapper.Map<Education>(education);
                await _dbContext.Educations.AddAsync(educationEntity);
                await _dbContext.SaveChangesAsync();
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
                var education = await _dbContext.Educations.FindAsync(educationId);
                if (education != null)
                {
                    _dbContext.Educations.Remove(education);
                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    throw new KeyNotFoundException($"Education with ID {educationId} not found.");
                }
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
                var education = await _dbContext.Educations.SingleOrDefaultAsync(e => e.Id == educationId);

                if (education == null)
                {
                    throw new KeyNotFoundException($"Education with ID {educationId} not found.");
                }

                return _mapper.Map<EducationResult>(education);
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
                var existingEducation = await _dbContext.Educations.FindAsync(education.Id);
                if (existingEducation == null)
                {
                    throw new KeyNotFoundException($"Education with ID {education.Id} not found.");
                }

                _mapper.Map(education, existingEducation);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error while updating education.", ex);
            }
        }
    }
}
