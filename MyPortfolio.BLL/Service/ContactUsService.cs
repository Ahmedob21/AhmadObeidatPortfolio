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
    public class ContactUsService : IContactUsService
    {
        private readonly IContactUsRepository _contactUsRepository;

        public ContactUsService(IContactUsRepository contactUsRepository)
        {
            _contactUsRepository = contactUsRepository;
        }

        public async Task<IEnumerable<ContactUsResult>> AllContactUsMessages()
        {
            return await _contactUsRepository.AllContactUsMessages();
        }

        public async Task CreateContactUs(CreateContactUs contactUs)
        {
            await _contactUsRepository.CreateContactUs(contactUs);
        }

        public async Task DeleteContactUs(int contactId)
        {
            await _contactUsRepository.DeleteContactUs(contactId);
        }

        public async Task<ContactUsResult> GetMessageByMessageId(int messageId)
        {
            return await _contactUsRepository.GetMessageByMessageId(messageId);
        }
    }
}
