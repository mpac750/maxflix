using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DA1.Areas.Admin.Data;
using DA1.Areas.Admin.Models;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;

namespace DA1.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public class CATEGORiesController : Controller
    {
        IMapper mapper;
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public CATEGORiesController(DataContext context,IWebHostEnvironment hostEnvironment, IMapper mapper)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
            this.mapper = mapper;
        }

        // GET: Admin/CATEGORies
        public async Task<IActionResult> Index()
        {
            return View(await _context.CATEGORies.ToListAsync());
        }

        // GET: Admin/CATEGORies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cATEGORY = await _context.CATEGORies
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (cATEGORY == null)
            {
                return NotFound();
            }

            return View(cATEGORY);
        }

        // GET: Admin/CATEGORies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/CATEGORies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryId,CategoryName")] CATEGORY cATEGORY)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cATEGORY);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cATEGORY);
        }

        // GET: Admin/CATEGORies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cATEGORY = await _context.CATEGORies.FindAsync(id);
            if (cATEGORY == null)
            {
                return NotFound();
            }
            return View(cATEGORY);
        }

        // POST: Admin/CATEGORies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryId,CategoryName")] CATEGORY cATEGORY)
        {
            if (id != cATEGORY.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cATEGORY);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CATEGORYExists(cATEGORY.CategoryId))
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
            return View(cATEGORY);
        }

        // GET: Admin/CATEGORies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cATEGORY = await _context.CATEGORies
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (cATEGORY == null)
            {
                return NotFound();
            }

            return View(cATEGORY);
        }

        // POST: Admin/CATEGORies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cATEGORY = await _context.CATEGORies.FindAsync(id);
            _context.CATEGORies.Remove(cATEGORY);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CATEGORYExists(int id)
        {
            return _context.CATEGORies.Any(e => e.CategoryId == id);
        }
    }
}
