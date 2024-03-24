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
    public class JoinController : Controller
    {
        private readonly FinalProjectContext _context;

        public JoinController(FinalProjectContext context)
        {
            _context = context;
        }

        // GET: Join
        public async Task<IActionResult> Index()
        {
            try
            {
                return _context.StylistAccount != null ?
                    View(await _context.StylistAccount.ToListAsync()) :
                    Problem("Entity set 'testingProjectContext.StylistAccount' is null.");
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel());
            }
        }


        // GET: Join/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null || _context.StylistAccount == null)
                {
                    return NotFound();
                }

                var stylistAccount = await _context.StylistAccount
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (stylistAccount == null)
                {
                    return NotFound();
                }

                return View(stylistAccount);
            }
            catch (Exception ex)
            {
                // Handle the exception or log it
                return View("Error", new ErrorViewModel());
            }
        }


        // GET: Join/Create
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

        // POST: Join/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Username,Email,Password,Phone,Gender,DateOfBirth,YearsOfExperience,LicenseNumber,PricesCharged,AreasOfExpertise,Address")] StylistAccount stylistAccount)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(stylistAccount);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(stylistAccount);
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel());
            }
        }


        // GET: Join/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null || _context.StylistAccount == null)
                {
                    return NotFound();
                }

                var stylistAccount = await _context.StylistAccount.FindAsync(id);
                if (stylistAccount == null)
                {
                    return NotFound();
                }
                return View(stylistAccount);
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel());
            }
        }


        // POST: Join/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Username,Email,Password,Phone,Gender,DateOfBirth,YearsOfExperience,LicenseNumber,PricesCharged,AreasOfExpertise,Address")] StylistAccount stylistAccount)
        {
            try
            {
                if (id != stylistAccount.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(stylistAccount);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!StylistAccountExists(stylistAccount.Id))
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
                return View(stylistAccount);
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel());
            }
        }


        // GET: Join/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null || _context.StylistAccount == null)
                {
                    return NotFound();
                }

                var stylistAccount = await _context.StylistAccount
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (stylistAccount == null)
                {
                    return NotFound();
                }

                return View(stylistAccount);
            }
            catch (Exception ex)
            {
                // Handle the exception or log it
                return View("Error", new ErrorViewModel());
            }
        }


        // POST: Join/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                if (_context.StylistAccount == null)
                {
                    return Problem("Entity set 'testingProjectContext.StylistAccount' is null.");
                }

                var stylistAccount = await _context.StylistAccount.FindAsync(id);
                if (stylistAccount != null)
                {
                    _context.StylistAccount.Remove(stylistAccount);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel());
            }
        }


        private bool StylistAccountExists(int id)
        {
            try
            {
                return (_context.StylistAccount?.Any(e => e.Id == id)).GetValueOrDefault();
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
