using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DA1.Areas.Admin.Data;
using DA1.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;

namespace DA1.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public class NATIONALsController : Controller
    {
        private readonly DataContext _context;

        public NATIONALsController(DataContext context)
        {
            _context = context;
        }

        // GET: Admin/NATIONALs
        public async Task<IActionResult> Index()
        {
            return View(await _context.NATIONALs.ToListAsync());
        }

        // GET: Admin/NATIONALs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nATIONAL = await _context.NATIONALs
                .FirstOrDefaultAsync(m => m.NationalId == id);
            if (nATIONAL == null)
            {
                return NotFound();
            }

            return View(nATIONAL);
        }

        // GET: Admin/NATIONALs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/NATIONALs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NationalId,NationalName")] NATIONAL nATIONAL)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nATIONAL);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nATIONAL);
        }

        // GET: Admin/NATIONALs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nATIONAL = await _context.NATIONALs.FindAsync(id);
            if (nATIONAL == null)
            {
                return NotFound();
            }
            return View(nATIONAL);
        }

        // POST: Admin/NATIONALs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NationalId,NationalName")] NATIONAL nATIONAL)
        {
            if (id != nATIONAL.NationalId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nATIONAL);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NATIONALExists(nATIONAL.NationalId))
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
            return View(nATIONAL);
        }

        // GET: Admin/NATIONALs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nATIONAL = await _context.NATIONALs
                .FirstOrDefaultAsync(m => m.NationalId == id);
            if (nATIONAL == null)
            {
                return NotFound();
            }

            return View(nATIONAL);
        }

        // POST: Admin/NATIONALs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nATIONAL = await _context.NATIONALs.FindAsync(id);
            _context.NATIONALs.Remove(nATIONAL);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NATIONALExists(int id)
        {
            return _context.NATIONALs.Any(e => e.NationalId == id);
        }
    }
}
