using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.DAL.DTOs
{
    public class CreateSkill
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Proficiency { get; set; }
    }
}
