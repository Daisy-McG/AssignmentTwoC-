using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTerraformMars.Models
{
    public class ApplicantService : IApplicantRepository
    {
        private readonly ProjectTerraformMarsContext _context;

        public ApplicantService(ProjectTerraformMarsContext context)
        {
            _context = context;
        }

        public void AddNewApplicant(Applicant applicant)
        {
            _context.Add(applicant);
            _context.SaveChanges();
        }

        public Applicant GetApplicantById(int? id)
        {
            var applicant = _context.Applicant.FirstOrDefault(a => a.Id == id);
            return applicant;
        }

        public List<Applicant> GetApplicants()
        {
            return _context.Applicant.ToList();
        }

        public void RemoveApplicant(Applicant applicant)
        {
            _context.Remove(applicant);
            _context.SaveChanges();
        }

        public void UpdateApplicant(Applicant applicant)
        {
            _context.Update(applicant);
            _context.SaveChanges();
        }
    }
}
    