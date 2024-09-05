using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.DAL.DTOs
{
    public class ProfileResult
    {
        public int Id { get; set; }

        public string FullName { get; set; } = null!;

        public string? Bio { get; set; }

        public string? ProfilePictureUrl { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Address { get; set; }
    }
}
