using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTerraformMars.Models
{
    public class Job
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Applicant")]
        public int ApplicantId { get; set; }
        [Required]
        [Display(Name = "Role")]
        public int RoleId { get; set; }
    }
}
