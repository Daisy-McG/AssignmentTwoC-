using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTerraformMars.Models
{
    public interface IJobRepository
    {
        List<Job> GetJobs();
        Job GetJobById(int? id);
        void AddNewJob(Job job);
        void UpdateJob(Job job);
        void RemoveJob(Job job);
    }
}
