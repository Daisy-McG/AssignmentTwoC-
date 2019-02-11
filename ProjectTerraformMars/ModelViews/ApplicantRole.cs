using ProjectTerraformMars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTerraformMars.ModelViews
{
    public class ApplicantRole
    {
        public Applicant Applicant { get; set; }
        public Role Role { get; set; }
    }
}
