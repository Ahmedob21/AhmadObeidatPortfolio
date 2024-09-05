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
    public class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProjectRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProjectResult>> AllProjects()
        {
            var projects = await _dbContext.Projects.ToListAsync();

            return _mapper.Map<IEnumerable<ProjectResult>>(projects);
        }

        public async Task CreateProject(CreateProject project)
        {
            try
            {
                var projectEntity = _mapper.Map<Project>(project); 
                await _dbContext.Projects.AddAsync(projectEntity);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error while creating project.", ex);
            }
        }

        public async Task DeleteProject(int projectId)
        {
            try
            {
                var project = await _dbContext.Projects.FindAsync(projectId);
                if (project != null)
                {
                    _dbContext.Projects.Remove(project);
                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    throw new KeyNotFoundException($"Project with ID {projectId} not found.");
                }
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException("Error while deleting Project.", ex);
            }
        }

        public async Task<ProjectResult> GeProjectByProjectId(int projectId)
        {
            try
            {
                var project = await _dbContext.Projects.SingleOrDefaultAsync(project => project.Id == projectId);

                if (project == null)
                {
                    throw new KeyNotFoundException($"project with ID {projectId} not found.");
                }

                return _mapper.Map<ProjectResult>(project);
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException("Error while retrieving project by project ID.", ex);
            }
        }

        public async Task UpdateProject(UpdateProject project)
        {
            try
            {

                var existingProject = await _dbContext.Projects.FindAsync(project.Id);
                if (existingProject == null)
                {
                    throw new KeyNotFoundException($"Project with ID {project.Id} not found.");
                }


                _mapper.Map(project, existingProject);


                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException("Error while updating project.", ex);
            }
        }
    }
}
