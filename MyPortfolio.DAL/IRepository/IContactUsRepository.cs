using MyPortfolio.DAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.DAL.IRepository
{
    public interface IContactUsRepository
    {
        Task CreateContactUs(CreateContactUs contactUs);
        Task DeleteContactUs(int contactId);
        Task<IEnumerable<ContactUsResult>> AllContactUsMessages();
        Task<ContactUsResult> GetMessageByMessageId(int messageId);
    }
}
