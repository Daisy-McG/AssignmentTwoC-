using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectTerraformMars.Models;
using ProjectTerraformMars.ModelViews;

namespace ProjectTerraformMars.Controllers
{
    public class JobsController : Controller
    {
        private readonly IJobRepository _jobRepository;
        private readonly IApplicantRepository _applicantRepository;
        private readonly IRoleRepository _roleRepository;

        public JobsController(IJobRepository jobRepository, IApplicantRepository applicantRepository, IRoleRepository roleRepository)
        {
            _jobRepository = jobRepository;
            _applicantRepository = applicantRepository;
            _roleRepository = roleRepository;
        }

        // GET: Jobs
        public IActionResult Index()
        {
            return View(_jobRepository.GetJobs());
        }

        // GET: Jobs/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = _jobRepository.GetJobById(id);
            ApplicantRole applicantRole = new ApplicantRole
            {
                Applicant = _applicantRepository.GetApplicantById(job.ApplicantId),
                Role = _roleRepository.GetRoleById(job.RoleId)
            };
            if (job == null)
            {
                return NotFound();
            }

            return View(applicantRole);
        }

        // GET: Jobs/Create
        public IActionResult Create()
        {
            ViewData["ApplicantId"] = new SelectList(_applicantRepository.GetApplicants(), "Id", "Name");
            ViewData["RoleId"] = new SelectList(_roleRepository.GetRoles(), "Id", "RoleName");
            return View();
        }

        // POST: Jobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,ApplicantId,RoleId")] Job job)
        {
            if (ModelState.IsValid)
            {
                _jobRepository.AddNewJob(job);
                return RedirectToAction(nameof(Index));
            }
            return View(job);
        }

        // GET: Jobs/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = _jobRepository.GetJobById(id);
            if (job == null)
            {
                return NotFound();
            }
            return View(job);
        }

        // POST: Jobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,ApplicantId,RoleId")] Job job)
        {
            if (id != job.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _jobRepository.UpdateJob(job);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobExists(job.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(job);
        }

        // GET: Jobs/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = _jobRepository.GetJobById(id);
            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var job = _jobRepository.GetJobById(id);
            _jobRepository.RemoveJob(job);
            return RedirectToAction(nameof(Index));
        }

        private bool JobExists(int id)
        {
            return _jobRepository.GetJobById(id) != null;
        }
    }
}
