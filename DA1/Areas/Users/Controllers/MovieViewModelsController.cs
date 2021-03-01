using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DA1.Models;
using AutoMapper;
using DA1.Areas.Admin.Data;
using Microsoft.VisualBasic;
using DA1.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using X.PagedList;
using X.PagedList.Mvc.Core;

namespace DA1.Controllers
{
   [Area("Users")]

    public class MovieViewModelsController : Controller
    {
        private readonly DataContext _context;
        IMapper mapper;

        public MovieViewModelsController(DataContext context,IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }
        public IActionResult Main()
        {
            var item = _context.MOVIEs.Include(m => m.CATEGORY).Include(m=>m.NATIONAL);
           
            var mappperItem = mapper.Map<List<MovieViewModel>>(item);
            return View(mappperItem);
        }

        // GET: MovieViewModels
     

        // GET: MovieViewModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var movie = await _context.MOVIEs.Include(m => m.CATEGORY).Include(m => m.NATIONAL)
                .FirstOrDefaultAsync(m => m.MovieId == id);
            
            var model = mapper.Map<MovieViewModel>(movie);
           


            return View(model);
        }
        [Authorize(Roles ="Visitor,Administrator")]

        [OutputCache(Duration = 20)]
        // GET: MovieViewModels/Create
        public async Task<IActionResult> WatchMovie(int? id)
        {
            var movie = await _context.MOVIEs.SingleOrDefaultAsync(u => u.MovieId == id);

            var model = mapper.Map<MovieViewModel>(movie);

            return View(model);
        }
        public ActionResult Search(string search)
        {
            var item = from x in _context.MOVIEs
                       select x;
            if (!String.IsNullOrEmpty(search))
            {
                item = item.Where(x => x.MovieName.Contains(search)).Include(m => m.CATEGORY).Include(m => m.NATIONAL);
            }
            var mappperItem = mapper.Map<List<MovieViewModel>>(item);
            return View(mappperItem);
        }
        public ActionResult Category(int? page)
        {
            if (page == null) page = 1;
            var item = (from x in _context.MOVIEs
                        select x).OrderBy(x => x.MovieId);
            int pageSize = 8;
            var mappperItem = mapper.Map<List<MovieViewModel>>(item);
            int pageNumber = (page ?? 1);
            return View(mappperItem.ToPagedList(pageNumber, pageSize));
        }
        public async Task<IActionResult> Detail(int? id)
        {
            var movie = await _context.MOVIEs.SingleOrDefaultAsync(u => u.MovieId== id);

            var model = mapper.Map<List<MovieViewModel>>(movie);



            return View(model);
        }
        public IActionResult Hanhdong()
        {
            var productCategoryId = (from ProductCategory in _context.MOVIEs.Include(m => m.CATEGORY).Include(m => m.NATIONAL)
                                     where ProductCategory.CategoryId == 2
                                     select ProductCategory);
            var model = mapper.Map<List<MovieViewModel>>(productCategoryId);

            return View(model.ToList());
        }
        public IActionResult Kinhdi()
        {
            var productCategoryId = (from ProductCategory in _context.MOVIEs.Include(m => m.CATEGORY).Include(m => m.NATIONAL)
                                     where ProductCategory.CategoryId == 1
                                     select ProductCategory);
            var model = mapper.Map<List<MovieViewModel>>(productCategoryId);

            return View(model.ToList());
        }
        public IActionResult HaiHuoc()
        {
            var productCategoryId = (from ProductCategory in _context.MOVIEs.Include(m => m.CATEGORY).Include(m => m.NATIONAL)
                                     where ProductCategory.CategoryId == 3
                                     select ProductCategory);
            var model = mapper.Map<List<MovieViewModel>>(productCategoryId);

            return View(model.ToList());
        }
        public IActionResult HoatHinh()
        {
            var productCategoryId = (from ProductCategory in _context.MOVIEs.Include(m => m.CATEGORY).Include(m => m.NATIONAL)
                                     where ProductCategory.CategoryId == 1002
                                     select ProductCategory);
            var model = mapper.Map<List<MovieViewModel>>(productCategoryId);

            return View(model.ToList());
        }
        public IActionResult VienTuong()
        {
            var productCategoryId = (from ProductCategory in _context.MOVIEs.Include(m => m.CATEGORY).Include(m => m.NATIONAL)
                                     where ProductCategory.CategoryId == 1003
                                     select ProductCategory);
            var model = mapper.Map<List<MovieViewModel>>(productCategoryId);

            return View(model.ToList());
        }

        public IActionResult My()
        {
            var productCategoryId = (from ProductCategory in _context.MOVIEs.Include(m => m.CATEGORY).Include(m=>m.NATIONAL)
                                     where ProductCategory.NationalId== 1
                                     select ProductCategory);
            var model = mapper.Map<List<MovieViewModel>>(productCategoryId);

            return View(model.ToList());
        }
        public IActionResult HanQuoc()
        {
            var productCategoryId = (from ProductCategory in _context.MOVIEs.Include(m => m.CATEGORY).Include(m => m.NATIONAL)
                                     where ProductCategory.NationalId == 2
                                     select ProductCategory);
            var model = mapper.Map<List<MovieViewModel>>(productCategoryId);

            return View(model.ToList());
        }
        public IActionResult NhatBan()
        {
            var productCategoryId = (from ProductCategory in _context.MOVIEs.Include(m => m.CATEGORY).Include(m => m.NATIONAL)
                                     where ProductCategory.NationalId == 3
                                     select ProductCategory);
            var model = mapper.Map<List<MovieViewModel>>(productCategoryId);

            return View(model.ToList());
        }
        public IActionResult VietNam()
        {
            var productCategoryId = (from ProductCategory in _context.MOVIEs.Include(m => m.CATEGORY).Include(m => m.NATIONAL)
                                     where ProductCategory.NationalId == 4
                                     select ProductCategory);
            var model = mapper.Map<List<MovieViewModel>>(productCategoryId);

            return View(model.ToList());
        }
    }
}
