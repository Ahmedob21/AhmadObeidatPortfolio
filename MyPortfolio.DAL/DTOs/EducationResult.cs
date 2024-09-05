using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.DAL.DTOs
{
    public class EducationResult
    {
        public int Id { get; set; }

        public string Degree { get; set; } = null!;

        public string Institution { get; set; } = null!;

        public string FieldOfStudy { get; set; } = null!;

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string? Grade { get; set; }

        public string? Description { get; set; }
    }
}
