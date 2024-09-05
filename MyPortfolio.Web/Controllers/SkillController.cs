using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.DTOs;
using MyPortfolio.DAL.IService;

namespace MyPortfolio.Web.Controllers
{
    public class SkillController : Controller
    {
        private readonly ISkillService _skillService;

        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }


        public async Task<IActionResult> AllSkills()
        {
            var skills = await _skillService.AllSkills();
            return View(skills);
        }


        [HttpGet]
        public IActionResult CreateSkill()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateSkill(CreateSkill skill)
        {
            if (ModelState.IsValid)
            {
                await _skillService.CreateSkill(skill);
                return RedirectToAction(nameof(AllSkills));
            }
            return View(skill);
        }


        public async Task<IActionResult> SkillDetails(int id)
        {
            var skill = await _skillService.GetSkillById(id);
            if (skill == null)
            {
                return NotFound();
            }
            return View(skill);
        }


        [HttpGet]
        public async Task<IActionResult> EditSkill(int id)
        {
            var skill = await _skillService.GetSkillById(id);
            if (skill == null)
            {
                return NotFound();
            }

            var updateSkill = new UpdateSkill
            {
                Id = skill.Id,
                Name = skill.Name,
                Proficiency = skill.Proficiency
            };

            return View(updateSkill);
        }


        [HttpPost]
        public async Task<IActionResult> EditSkill(UpdateSkill skill)
        {
            if (ModelState.IsValid)
            {
                await _skillService.UpdateSkill(skill);
                return RedirectToAction(nameof(AllSkills));
            }
            return View(skill);
        }


        [HttpGet]
        public async Task<IActionResult> DeleteSkill(int id)
        {
            var skill = await _skillService.GetSkillById(id);
            if (skill == null)
            {
                return NotFound();
            }
            return View(skill);
        }


        [HttpPost, ActionName("DeleteSkill")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _skillService.DeleteSkill(id);
            return RedirectToAction(nameof(AllSkills));
        }
    }
}
