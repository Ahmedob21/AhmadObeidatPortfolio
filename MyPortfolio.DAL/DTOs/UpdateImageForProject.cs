using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.DAL.DTOs
{
    public class UpdateImageForProject
    {
        public int Id { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }
        public int? ProjectId { get; set; }
        public string ImageUrl { get; set; } = null!;
    }
}
