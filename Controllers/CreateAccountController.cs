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
    public class CreateAccountController : Controller
    {
        private readonly FinalProjectContext _context;

        public CreateAccountController(FinalProjectContext context)
        {
            _context = context;
        }
        // GET: CreateAccount
        public async Task<IActionResult> Index()
        {
            try
            {
                return _context.UserAccount != null ?
                          View(await _context.UserAccount.ToListAsync()) :
                          Problem("Entity set 'testingProjectContext.UserAccount'  is null.");
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel());
            }

        }

        // GET: CreateAccount/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null || _context.UserAccount == null)
                {
                    return NotFound();
                }

                var userAccount = await _context.UserAccount
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (userAccount == null)
                {
                    return NotFound();
                }

                return View(userAccount);
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel());
            }
        }


        // GET: CreateAccount/Create
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

        // POST: CreateAccount/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Username,Email,Password,Phone,Gender,DateOfBirth,Budget,ClothingSize,Address")] UserAccount userAccount)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(userAccount);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(userAccount);
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel());
            }
        }


        // GET: CreateAccount/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null || _context.UserAccount == null)
                {
                    return NotFound();
                }

                var userAccount = await _context.UserAccount.FindAsync(id);
                if (userAccount == null)
                {
                    return NotFound();
                }
                return View(userAccount);
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel());
            }
        }


        // POST: CreateAccount/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Username,Email,Password,Phone,Gender,DateOfBirth,Budget,ClothingSize,Address")] UserAccount userAccount)
        {
            try
            {
                if (id != userAccount.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(userAccount);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!UserAccountExists(userAccount.Id))
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
                return View(userAccount);
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel());
            }
        }


        // GET: CreateAccount/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null || _context.UserAccount == null)
                {
                    return NotFound();
                }

                var userAccount = await _context.UserAccount
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (userAccount == null)
                {
                    return NotFound();
                }

                return View(userAccount);
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel());
            }
        }


        // POST: CreateAccount/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                if (_context.UserAccount == null)
                {
                    return Problem("Entity set 'testingProjectContext.UserAccount' is null.");
                }

                var userAccount = await _context.UserAccount.FindAsync(id);
                if (userAccount != null)
                {
                    _context.UserAccount.Remove(userAccount);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel());
            }
        }


        private bool UserAccountExists(int id)
        {
            try
            {
                return (_context.UserAccount?.Any(e => e.Id == id)).GetValueOrDefault();
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
