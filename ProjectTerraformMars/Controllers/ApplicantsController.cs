using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectTerraformMars.Models;

namespace ProjectTerraformMars.Controllers
{
    public class ApplicantsController : Controller
    {
        private readonly IApplicantRepository _applicantRepository;

        public ApplicantsController(IApplicantRepository applicantRepository)
        {
            _applicantRepository = applicantRepository;
        }

        // GET: Applicants
        public IActionResult Index()
        {
            return View(_applicantRepository.GetApplicants());
        }

        // GET: Applicants/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicant = _applicantRepository.GetApplicantById(id);
            if (applicant == null)
            {
                return NotFound();
            }

            return View(applicant);
        }

        // GET: Applicants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Applicants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Address,PhoneNumber,Email")] Applicant applicant)
        {
            if (ModelState.IsValid)
            {
                _applicantRepository.AddNewApplicant(applicant);
                return RedirectToAction(nameof(Index));
            }
            return View(applicant);
        }

        // GET: Applicants/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicant = _applicantRepository.GetApplicantById(id);
            if (applicant == null)
            {
                return NotFound();
            }
            return View(applicant);
        }

        // POST: Applicants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Address,PhoneNumber,Email")] Applicant applicant)
        {
            if (id != applicant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _applicantRepository.UpdateApplicant(applicant);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicantExists(applicant.Id))
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
            return View(applicant);
        }

        // GET: Applicants/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicant = _applicantRepository.GetApplicantById(id);
            if (applicant == null)
            {
                return NotFound();
            }

            return View(applicant);
        }

        // POST: Applicants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var applicant = _applicantRepository.GetApplicantById(id);
            _applicantRepository.RemoveApplicant(applicant);
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicantExists(int id)
        {
            return _applicantRepository.GetApplicantById(id) != null;
        }
    }
}
