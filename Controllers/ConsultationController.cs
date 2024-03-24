using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalProject.Data;
using FinalProject.Models;

namespace FinalProject.Controllers
{
    public class ConsultationController : Controller
    {
        private readonly FinalProjectContext _context;

        public ConsultationController(FinalProjectContext context)
        {
            _context = context;
        }
        // GET: Consultation
        public async Task<IActionResult> Index()
        {
            try
            {
                return _context.Consultation != null ?
                    View(await _context.Consultation.ToListAsync()) :
                    Problem("Entity set 'testingProjectContext.Consultation' is null.");
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel());
            }
        }


        // GET: Consultation/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null || _context.Consultation == null)
                {
                    return NotFound();
                }

                var consultation = await _context.Consultation
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (consultation == null)
                {
                    return NotFound();
                }

                return View(consultation);
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel());
            }
        }


        // GET: Consultation/Create
        public IActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel());
            }
        }


        // POST: Consultation/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,Phone,ReasonForConsultation,ConsultationType,PackageType,ContactMethod,AvailabilityDate,Style,Message")] Consultation consultation)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(consultation);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(consultation);
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel());
            }
        }


        // GET: Consultation/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null || _context.Consultation == null)
                {
                    return NotFound();
                }

                var consultation = await _context.Consultation.FindAsync(id);
                if (consultation == null)
                {
                    return NotFound();
                }
                return View(consultation);
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel());
            }
        }


        // POST: Consultation/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email,Phone,ReasonForConsultation,ConsultationType,PackageType,ContactMethod,AvailabilityDate,Style,Message")] Consultation consultation)
        {
            try
            {
                if (id != consultation.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(consultation);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ConsultationExists(consultation.Id))
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
                return View(consultation);
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel());
            }
        }


        // GET: Consultation/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null || _context.Consultation == null)
                {
                    return NotFound();
                }

                var consultation = await _context.Consultation
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (consultation == null)
                {
                    return NotFound();
                }

                return View(consultation);
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel());
            }
        }


        // POST: Consultation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                if (_context.Consultation == null)
                {
                    return Problem("Entity set 'testingProjectContext.Consultation' is null.");
                }
                var consultation = await _context.Consultation.FindAsync(id);
                if (consultation != null)
                {
                    _context.Consultation.Remove(consultation);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel());
            }
        }


        private bool ConsultationExists(int id)
        {
            try
            {
                return (_context.Consultation?.Any(e => e.Id == id)).GetValueOrDefault();
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
