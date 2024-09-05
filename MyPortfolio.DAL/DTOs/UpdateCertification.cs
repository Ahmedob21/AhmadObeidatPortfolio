using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.DAL.DTOs
{
    public class UpdateCertification
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string? Authority { get; set; }

        public DateTime IssueDate { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public string? CredentialId { get; set; }

        public string? CredentialUrl { get; set; }
    }
}
