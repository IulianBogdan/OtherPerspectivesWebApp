using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OtherPerspectivesWebApp.Data;
using OtherPerspectivesWebApp.Models;

namespace OtherPerspectivesWebApp.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly OtherPerspectivesContext _context;

        //the framework handles this
        public AdminController(OtherPerspectivesContext context)
        {
            _context = context;
        }

        [Route("Admin")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("Admin/Categories")]
        public IActionResult Categories()
        {
            using (var context = _context)
            {
                var categoriesList = context.Categories.ToList();

                return View("Categories", categoriesList);
            }
        }

        [HttpPost]
        [Route("Admin/AddCategory")]
        public IActionResult AddCategory([Bind("Name")] Category category)
        {
            using (var context = _context)
            {
                context.Add(category);
                context.SaveChanges();
            }

            return RedirectToAction("Categories");
        }

        [HttpGet]
        [Route("Admin/Edit/{id}")]
        public IActionResult EditCategory(int id)
        {
            using (var context = _context)
            {
                return View("EditCategory", context.Categories.First(x => x.Id == id));
            }
        }

        [HttpPost]
        [Route("Admin/Edit/{id}")]
        public IActionResult EditCategory([Bind("Id, Name")] Category category)
        {
            using (var context = _context)
            {
                context.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }

            return RedirectToAction("Categories");
        }

        [Route("Admin/DeleteCategory/{id}")]
        public IActionResult DeleteCategory(int id)
        {
            using (var context = _context)
            {
                var category = context.Categories.First(x => x.Id == id);

                context.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                context.SaveChanges();
            }

            return RedirectToAction("Categories");
        }
    }
}