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
    public class CertificationService : ICertificationService
    {
        private readonly ICertificationRepository _certificationRepository;

        public CertificationService(ICertificationRepository certificationRepository)
        {
            _certificationRepository = certificationRepository;
        }

        public async Task<IEnumerable<CertificationResult>> AllCertification()
        {
            try
            {
                return await _certificationRepository.AllCertification();
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
                await _certificationRepository.CreateCertification(certification);
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
                await _certificationRepository.DeleteCertification(certificationId);
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
                return await _certificationRepository.GeCertificationById(certificationId);
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
                await _certificationRepository.UpdateCertification(certification);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error while updating certification.", ex);
            }
        }
    }
}
