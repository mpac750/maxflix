using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DA1.Areas.Admin.Data;
using DA1.Models;
using AutoMapper;

namespace DA1.Areas.Users.Controllers
{
    [Area("Users")]
    public class CategoryViewModelsController : Controller
    {
        private readonly DataContext _context;
        IMapper mapper;
        public CategoryViewModelsController(DataContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            var item = _context.CATEGORies;
            var mappperItem = mapper.Map<List<CategoryViewModel>>(item);
            return View(mappperItem);
        }
        public async Task<IActionResult> Details(int? id)
        {
            var movie = await _context.CATEGORies.FirstOrDefaultAsync(u => u.CategoryId == id);

            var model = mapper.Map<CategoryViewModel>(movie);



            return View(model);
        }

    }
}
