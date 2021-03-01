using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using DA1.Areas.Admin.Data;
using DA1.Models;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using DA1.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace DA1.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public class MoviesController : Controller
    {
        IMapper mapper;
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        public MoviesController(DataContext context, IWebHostEnvironment hostEnvironment, IMapper mapper)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
            this.mapper = mapper;
        }
        
        // GET: Movies
        public async Task<IActionResult> Index()
        {

            var dataContext = _context.MOVIEs.Include(m => m.CATEGORY).Include(m=>m.NATIONAL);
            return View(await dataContext.ToListAsync());
        }
   
        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.MOVIEs
                .Include(m => m.CATEGORY).Include(m => m.NATIONAL)
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (movie == null)
            {
                return NotFound();
            }
           
            return View(movie);
        }
        public ActionResult Search(string search)
        {
            var searchmovie = from x in _context.MOVIEs
                              select x;
            if (!String.IsNullOrEmpty(search))
            {
                searchmovie = searchmovie.Where(x => x.MovieName.Contains(search)).Include(m => m.CATEGORY).Include(m => m.NATIONAL);
            }
           
            return View(searchmovie.ToList());
        }
        // GET: Movies/Create

        public IActionResult Create()
        {

            ViewData["CategoryId"] = new SelectList(_context.CATEGORies, "CategoryId", "CategoryName");
            ViewData["NationalId"] = new SelectList(_context.NATIONALs, "NationalId", "NationalName");
            return View();
        }


        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieId,MovieName,MovieImage,MovieVideo,MoviePoint,MovieTrailer,MovieDesc,MovieTime,CategoryId,NationalId")] Movie movie, IFormFile photo, IFormFile trailer, IFormFile video)
        {
            if (ModelState.IsValid)
            {
                Movie movie1 = new Movie();
                if (photo == null || photo.Length == 0)
                {
                    movie1.MovieImage = "endgame.jpg";
                }
                else
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/image", photo.FileName);
                    var stream = new FileStream(path, FileMode.Create);
                    _ = photo.CopyToAsync(stream);
                    movie1.MovieImage = photo.FileName;
                }


                if (trailer == null || trailer.Length == 0)
                {
                    movie1.MovieTrailer = "endgame_trailer.mp4";
                }
                else
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/trailer", trailer.FileName);
                    var stream = new FileStream(path, FileMode.Create);
                    _ = trailer.CopyToAsync(stream);
                    movie1.MovieTrailer = trailer.FileName;
                }


                if (video == null || video.Length == 0)
                {
                    movie1.MovieVideo = "endgame_phim.mp4";

                }
                else
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Movie", video.FileName);
                    var stream = new FileStream(path, FileMode.Create);
                    _ = video.CopyToAsync(stream);
                    movie1.MovieVideo = video.FileName;
                }
                movie1.MovieName = movie.MovieName;
                movie1.MoviePoint = movie.MoviePoint;
                movie1.CategoryId = movie.CategoryId;
                movie1.MovieDesc = movie.MovieDesc;
                movie1.MovieTime = movie.MovieTime;
                ViewData["CategoryId"] = new SelectList(_context.CATEGORies, "CategoryId", "CategoryName", movie1.CategoryId);
                ViewData["CategoryId"] = new SelectList(_context.CATEGORies, "CategoryId", "CategoryId", movie1.CategoryId);
                ViewData["NationalId"] = new SelectList(_context.NATIONALs, "NationalId", "NationalName", movie1.NationalId);
                ViewData["NationalId"] = new SelectList(_context.NATIONALs, "NationalId", "NationalId", movie1.NationalId);
                _context.Add(movie1);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Movies");
            }
            else
            {

                return View(movie);
            }

        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.MOVIEs.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.CATEGORies, "CategoryId", "CategoryName", movie.CategoryId);
            ViewData["NationalId"] = new SelectList(_context.NATIONALs, "NationalId", "NationalName", movie.NationalId);
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MovieId,MovieName,MovieImage,MovieVideo,MoviePoint,MovieTrailer,MovieDesc,MovieTime,CategoryId,NationalId")] Movie movie, IFormFile photo)
        {
            if (id != movie.MovieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.MovieId))
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
            ViewData["CategoryId"] = new SelectList(_context.CATEGORies, "CategoryId", "CategoryName", movie.CategoryId);
            ViewData["NationalId"] = new SelectList(_context.NATIONALs, "NationalId", "NationalName", movie.NationalId);

            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.MOVIEs
                .Include(m => m.CATEGORY).Include(m => m.NATIONAL)
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.MOVIEs.FindAsync(id);
            _context.MOVIEs.Remove(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _context.MOVIEs.Any(e => e.MovieId == id);
        }
        public IActionResult Hanhdong()
        {



            var productCategoryId = (from ProductCategory in _context.MOVIEs.Include(m => m.CATEGORY)
                                     where ProductCategory.CategoryId == 1
                                     select ProductCategory);


            return View(productCategoryId.ToList());
        }
    }
}
