using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.DTOs;
using MyPortfolio.DAL.IService;

namespace MyPortfolio.Web.Controllers
{
    public class ExperienceController : Controller
    {
        private readonly IExperienceService _experienceService;

        public ExperienceController(IExperienceService experienceService)
        {
            _experienceService = experienceService;
        }


        public async Task<IActionResult> AllExperiences()
        {
            var experiences = await _experienceService.AllExperiences();
            return View(experiences);
        }


        [HttpGet]
        public IActionResult CreateExperience()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateExperience(CreateExperience experience)
        {
            if (ModelState.IsValid)
            {
                await _experienceService.CreateExperience(experience);
                return RedirectToAction(nameof(AllExperiences));
            }
            return View(experience);
        }


        public async Task<IActionResult> GetExperienceById(int id)
        {
            var experience = await _experienceService.GetExperienceById(id);
            if (experience == null)
            {
                return NotFound();
            }
            return View(experience);
        }


        [HttpGet]
        public async Task<IActionResult> UpdateExperience(int id)
        {
            var experience = await _experienceService.GetExperienceById(id);
            if (experience == null)
            {
                return NotFound();
            }

            var updateExperience = new UpdateExperience
            {
                Id = experience.Id,
                Title = experience.Title,
                Company = experience.Company,
                StartDate = experience.StartDate,
                EndDate = experience.EndDate,
                Description = experience.Description
            };

            return View(updateExperience);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateExperience(UpdateExperience experience)
        {
            if (ModelState.IsValid)
            {
                await _experienceService.UpdateExperience(experience);
                return RedirectToAction(nameof(AllExperiences));
            }
            return View(experience);
        }


        [HttpGet]
        public async Task<IActionResult> DeleteExperience(int id)
        {
            var experience = await _experienceService.GetExperienceById(id);
            if (experience == null)
            {
                return NotFound();
            }
            return View(experience);
        }


        [HttpPost, ActionName("DeleteExperience")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _experienceService.DeleteExperience(id);
            return RedirectToAction(nameof(AllExperiences));
        }
    }
}
