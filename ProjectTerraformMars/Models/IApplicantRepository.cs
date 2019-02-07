using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTerraformMars.Models
{
    public interface IApplicantRepository
    {
        List<Applicant> GetApplicants();
        Applicant GetApplicantById(int? id);
        void AddNewApplicant(Applicant applicant);
        void UpdateApplicant(Applicant applicant);
        void RemoveApplicant(Applicant applicant);
    }
}
