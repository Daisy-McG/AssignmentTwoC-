using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectTerraformMars.Models;

namespace ProjectTerraformMars.Models
{
    public class ProjectTerraformMarsContext : DbContext
    {
        public ProjectTerraformMarsContext (DbContextOptions<ProjectTerraformMarsContext> options)
            : base(options)
        {
        }

        public DbSet<ProjectTerraformMars.Models.Applicant> Applicant { get; set; }

        public DbSet<ProjectTerraformMars.Models.Feedback> Feedback { get; set; }

        public DbSet<ProjectTerraformMars.Models.Job> Job { get; set; }

        public DbSet<ProjectTerraformMars.Models.Role> Role { get; set; }
    }
}
