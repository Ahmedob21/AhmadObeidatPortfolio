using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.DAL.DTOs
{
    public class ProjectimageResult
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; } = null!;

        public int? ProjectId { get; set; }
    }
}
