using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.DTOs;
using MyPortfolio.DAL.IService;

namespace MyPortfolio.Web.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        // Display all projects
        public async Task<IActionResult> AllProjects()
        {
            var projects = await _projectService.AllProjects();
            return View(projects);
        }

        // Display the form for creating a new project
        [HttpGet]
        public IActionResult CreateProject()
        {
            return View();
        }

        // Handle the form submission to create a new project
        [HttpPost]
        public async Task<IActionResult> CreateProject(CreateProject project)
        {
            if (ModelState.IsValid)
            {
                await _projectService.CreateProject(project);
                return RedirectToAction(nameof(AllProjects));
            }

            return View(project);
        }

        // Display a single project by ID
        [HttpGet]
        public async Task<IActionResult> GetProjectById(int projectId)
        {
            if (projectId == 0)
            {
                return NotFound();
            }

            var project = await _projectService.GeProjectByProjectId(projectId);

            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // Display the form for updating an existing project
        [HttpGet]
        public async Task<IActionResult> EditProject(int projectId)
        {
            if (projectId == 0)
            {
                return NotFound();
            }

            var project = await _projectService.GeProjectByProjectId(projectId);

            if (project == null)
            {
                return NotFound();
            }

            var updateProjectDto = new UpdateProject
            {
                Id = project.Id,
                Title = project.Title,
                Description = project.Description,
                Date = project.Date
            };

            return View(updateProjectDto);
        }

        // Handle the form submission to update an existing project
        [HttpPost]
        public async Task<IActionResult> EditProject(UpdateProject project)
        {
            if (ModelState.IsValid)
            {
                await _projectService.UpdateProject(project);
                return RedirectToAction(nameof(AllProjects));
            }

            return View(project);
        }

        // Display the confirmation page for deleting a project
        [HttpGet]
        public async Task<IActionResult> DeleteProject(int projectId)
        {
            if (projectId == 0)
            {
                return NotFound();
            }

            var project = await _projectService.GeProjectByProjectId(projectId);

            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // Handle the form submission to confirm deletion of a project
        [HttpPost, ActionName("DeleteProject")]
        public async Task<IActionResult> DeleteConfirmed(int projectId)
        {
            var project = await _projectService.GeProjectByProjectId(projectId);
            if (project != null)
            {
                await _projectService.DeleteProject(projectId);
                return RedirectToAction(nameof(AllProjects));
            }

            return NotFound();
        }
    }
}
