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
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<IEnumerable<ProjectResult>> AllProjects()
        {
            return await _projectRepository.AllProjects();
        }

        public async Task CreateProject(CreateProject project)
        {
            await _projectRepository.CreateProject(project);
        }

        public async Task DeleteProject(int projectId)
        {
            await _projectRepository.DeleteProject(projectId);
        }

        public async Task<ProjectResult> GeProjectByProjectId(int projectId)
        {
            return await _projectRepository.GeProjectByProjectId(projectId);
        }

        public async Task UpdateProject(UpdateProject project)
        {
            await _projectRepository.UpdateProject(project);
        }
    }
}
