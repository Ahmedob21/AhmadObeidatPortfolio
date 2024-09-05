using MyPortfolio.DAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.DAL.IRepository
{
    public interface ICertificationRepository
    {
        Task CreateCertification(CreateCertification certification);
        Task DeleteCertification(int certificationId);
        Task<IEnumerable<CertificationResult>> AllCertification();
        Task<CertificationResult> GeCertificationById(int certificationId);
        Task UpdateCertification(UpdateCertification certification);
    }
}
