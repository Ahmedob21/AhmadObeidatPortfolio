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
    public class ContactUsRepository : IContactUsRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public ContactUsRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ContactUsResult>> AllContactUsMessages()
        {
            var messages = await _dbContext.Contactmessages.ToListAsync();
            return _mapper.Map<IEnumerable<ContactUsResult>>(messages);
        }

        public async Task CreateContactUs(CreateContactUs contactUs)
        {
            try
            {
                var contact = _mapper.Map<Contactmessage>(contactUs);
                await _dbContext.Contactmessages.AddAsync(contact);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException("Error while creating contact us message.", ex);
            }
        }

        public async Task DeleteContactUs(int contactId)
        {
            try
            {
                var contact = await _dbContext.Contactmessages.FindAsync(contactId);
                if (contact != null)
                {
                    _dbContext.Contactmessages.Remove(contact);
                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    throw new KeyNotFoundException($"Contact message with ID {contactId} not found.");
                }
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException("Error while deleting contact us message.", ex);
            }
        }

        public async Task<ContactUsResult> GetMessageByMessageId(int messageId)
        {
            try
            {
                var contact = await _dbContext.Contactmessages
                    .SingleOrDefaultAsync(message => message.Id == messageId);

                if (contact == null)
                {
                    throw new KeyNotFoundException($"Message with ID {messageId} not found.");
                }

                return _mapper.Map<ContactUsResult>(contact);
            }
            catch (Exception ex)
            {
                // Log the exception here
                throw new InvalidOperationException("Error while retrieving contact us message by ID.", ex);
            }
        }
    }
}
