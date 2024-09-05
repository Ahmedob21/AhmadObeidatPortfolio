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
    public class CertificationRepository : ICertificationRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public CertificationRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CertificationResult>> AllCertification()
        {
            try
            {
                var certifications = await _dbContext.Certifications.ToListAsync();
                return _mapper.Map<IEnumerable<CertificationResult>>(certifications);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error while retrieving all certifications.", ex);
            }
        }

        public async Task CreateCertification(CreateCertification certification)
        {
            try
            {
                var certificationEntity = _mapper.Map<Certification>(certification);
                await _dbContext.Certifications.AddAsync(certificationEntity);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error while creating certification.", ex);
            }
        }

        public async Task DeleteCertification(int certificationId)
        {
            try
            {
                var certification = await _dbContext.Certifications.FindAsync(certificationId);
                if (certification != null)
                {
                    _dbContext.Certifications.Remove(certification);
                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    throw new KeyNotFoundException($"Certification with ID {certificationId} not found.");
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error while deleting certification.", ex);
            }
        }

        public async Task<CertificationResult> GeCertificationById(int certificationId)
        {
            try
            {
                var certification = await _dbContext.Certifications.SingleOrDefaultAsync(c => c.Id == certificationId);

                if (certification == null)
                {
                    throw new KeyNotFoundException($"Certification with ID {certificationId} not found.");
                }

                return _mapper.Map<CertificationResult>(certification);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error while retrieving certification by ID.", ex);
            }
        }

        public async Task UpdateCertification(UpdateCertification certification)
        {
            try
            {
                var existingCertification = await _dbContext.Certifications.FindAsync(certification.Id);
                if (existingCertification == null)
                {
                    throw new KeyNotFoundException($"Certification with ID {certification.Id} not found.");
                }

                _mapper.Map(certification, existingCertification);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error while updating certification.", ex);
            }
        }
    }
}
