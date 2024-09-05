using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.DTOs;
using MyPortfolio.DAL.IService;

namespace MyPortfolio.Web.Controllers
{
    public class EducationController : Controller
    {
        private readonly IEducationService _educationService;

        public EducationController(IEducationService educationService)
        {
            _educationService = educationService;
        }

        // List all educations
        public async Task<IActionResult> AllEducations()
        {
            var educations = await _educationService.AllEducations();
            return View(educations);
        }

        // Display form for creating a new education
        [HttpGet]
        public IActionResult CreateEducation()
        {
            return View();
        }

        // Handle the submission of a new education
        [HttpPost]
        public async Task<IActionResult> CreateEducation(CreateEducation education)
        {
            if (ModelState.IsValid)
            {
                await _educationService.CreateEducation(education);
                return RedirectToAction(nameof(AllEducations));
            }
            return View(education);
        }

        // Display details of a specific education
        public async Task<IActionResult> GetEducationById(int id)
        {
            var education = await _educationService.GetEducationById(id);
            if (education == null)
            {
                return NotFound();
            }
            return View(education);
        }

        // Display form for editing an existing education
        [HttpGet]
        public async Task<IActionResult> UpdateEducation(int id)
        {
            var education = await _educationService.GetEducationById(id);
            if (education == null)
            {
                return NotFound();
            }

            var updateEducation = new UpdateEducation
            {
                Id = education.Id,
                Degree = education.Degree,
                Institution = education.Institution,
                FieldOfStudy = education.FieldOfStudy,
                StartDate = education.StartDate,
                EndDate = education.EndDate,
                Grade = education.Grade,
                Description = education.Description
            };

            return View(updateEducation);
        }

        // Handle the submission of an edited education
        [HttpPost]
        public async Task<IActionResult> UpdateEducation(UpdateEducation education)
        {
            if (ModelState.IsValid)
            {
                await _educationService.UpdateEducation(education);
                return RedirectToAction(nameof(AllEducations));
            }
            return View(education);
        }

        // Display confirmation for deleting an education
        [HttpGet]
        public async Task<IActionResult> DeleteEducation(int id)
        {
            var education = await _educationService.GetEducationById(id);
            if (education == null)
            {
                return NotFound();
            }
            return View(education);
        }

        // Handle the confirmation of deleting an education
        [HttpPost, ActionName("DeleteEducation")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _educationService.DeleteEducation(id);
            return RedirectToAction(nameof(AllEducations));
        }
    }
}
