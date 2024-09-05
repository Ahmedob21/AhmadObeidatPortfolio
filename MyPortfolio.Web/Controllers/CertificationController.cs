using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.DTOs;
using MyPortfolio.DAL.IService;

namespace MyPortfolio.Web.Controllers
{
    public class CertificationController : Controller
    {
        private readonly ICertificationService _certificationService;

        public CertificationController(ICertificationService certificationService)
        {
            _certificationService = certificationService;
        }

        // List all certifications
        public async Task<IActionResult> AllCertification()
        {
            var certifications = await _certificationService.AllCertification();
            return View(certifications);
        }

        // Display form for creating a new certification
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Handle the submission of a new certification
        [HttpPost]
        public async Task<IActionResult> Create(CreateCertification certification)
        {
            if (ModelState.IsValid)
            {
                await _certificationService.CreateCertification(certification);
                return RedirectToAction(nameof(AllCertification));
            }
            return View(certification);
        }

        // Display details of a specific certification
        public async Task<IActionResult> Details(int id)
        {
            var certification = await _certificationService.GeCertificationById(id);
            if (certification == null)
            {
                return NotFound();
            }
            return View(certification);
        }

        // Display form for editing an existing certification
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var certification = await _certificationService.GeCertificationById(id);
            if (certification == null)
            {
                return NotFound();
            }

            var updateCertification = new UpdateCertification
            {
                Id = certification.Id,
                Title = certification.Title,
                Authority = certification.Authority,
                IssueDate = certification.IssueDate,
                ExpirationDate = certification.ExpirationDate,
                CredentialId = certification.CredentialId,
                CredentialUrl = certification.CredentialUrl
            };

            return View(updateCertification);
        }

        // Handle the submission of an edited certification
        [HttpPost]
        public async Task<IActionResult> Edit(UpdateCertification certification)
        {
            if (ModelState.IsValid)
            {
                await _certificationService.UpdateCertification(certification);
                return RedirectToAction(nameof(Index));
            }
            return View(certification);
        }

        // Display confirmation for deleting a certification
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var certification = await _certificationService.GeCertificationById(id);
            if (certification == null)
            {
                return NotFound();
            }
            return View(certification);
        }

        // Handle the confirmation of deleting a certification
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _certificationService.DeleteCertification(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
