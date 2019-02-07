using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTerraformMars.Models
{
    public class JobService : IJobRepository
    {
        private readonly ProjectTerraformMarsContext _context;

        public JobService(ProjectTerraformMarsContext context)
        {
            _context = context;
        }

        public void AddNewJob(Job job)
        {
            _context.Add(job);
            _context.SaveChanges();
        }

        public Job GetJobById(int? id)
        {
            var job = _context.Job.FirstOrDefault(j => j.Id == id);
            return job;
        }

        public List<Job> GetJobs()
        {
            return _context.Job.ToList();
        }

        public void RemoveJob(Job job)
        {
            _context.Remove(job);
            _context.SaveChanges();
        }

        public void UpdateJob(Job job)
        {
            _context.Update(job);
            _context.SaveChanges();
        }
    }
}
