using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.DTOs;
using MyPortfolio.DAL.IService;

namespace MyPortfolio.Web.Controllers
{
    public class ContactUsController : Controller
    {
        private readonly IContactUsService _contactUsService;

        public ContactUsController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }

        public async Task<IActionResult> AllMessages()
        {
            var messages = await _contactUsService.AllContactUsMessages();
            return View(messages);
        }

        [HttpGet]
        public IActionResult CreateContactUs()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateContactUs(CreateContactUs contactUs)
        {
            if (ModelState.IsValid)
            {
                await _contactUsService.CreateContactUs(contactUs);
                return RedirectToAction(nameof(AllMessages));
            }

            return View(contactUs);
        }


        [HttpGet]

        public async Task<IActionResult> GetMessageByMessageId(int messageId)
        {
            if (messageId == 0)
            {
                return NotFound();
            }

            var message = await _contactUsService.GetMessageByMessageId(messageId);

            if (message == null)
            {
                return NotFound();
            }

            return View(message);
        }


        [HttpGet]
        public async Task<IActionResult> DeleteContactMessage(int messageId)
        {
            if (messageId == 0)
            {
                return NotFound();
            }

            var message = await _contactUsService.GetMessageByMessageId(messageId);


            if (message == null)
            {
                return NotFound();
            }

            return View(message);
        }

        [HttpPost, ActionName("DeleteContactMessage")]

        public async Task<IActionResult> DeleteConfirmed(int messageId)
        {
            var message = await _contactUsService.GetMessageByMessageId(messageId);
            if (message != null)
            {
                await _contactUsService.DeleteContactUs(messageId);
                return RedirectToAction(nameof(AllMessages));
            }

            return NotFound();
        }
    }
}
