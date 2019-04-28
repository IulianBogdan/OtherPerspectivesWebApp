using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OtherPerspectivesWebApp.Data;
using OtherPerspectivesWebApp.Models;

namespace OtherPerspectivesWebApp.Controllers
{
    [Authorize]
    [Route("Product")]
    public class ProductController : Controller
    {
        private readonly OtherPerspectivesContext _context;
        private readonly ApplicationDbContext _userContext;
        private readonly UserManager<ApplicationUser> _userManager;


        public ProductController(OtherPerspectivesContext context, ApplicationDbContext userContext, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userContext = userContext;
            _userManager = userManager;
        }
        
        [HttpGet]
        [Route(" ")]
        public async Task<IActionResult> Products()
        {
            var user = await _userManager.GetUserAsync(User);
            var userId = _context.Users.FirstOrDefault(x => x.Email == user.Email).Id;

            return View("Products", _context.Products.Where(x => x.UserId == userId).ToList());
        }
        
        [Route("{title}")]
        public IActionResult Product(string title)
        {
            var product = _context.Products.FirstOrDefault(x => x.Title == title);
            
            return View("Products", product);
        }
        
        [Authorize]
        [HttpGet, Route("AddNew")]
        public IActionResult Add()
        {
            var user = _userManager.GetUserAsync(User);
            Console.WriteLine(user.Id);
            return View("AddProduct");
        }
        
        [Authorize]
        [HttpPost, Route("AddNew")]
        public async Task< IActionResult> Add([Bind("Name")] Product product)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                product.UserId = _context.Users.FirstOrDefault(x => x.Email == user.Email).Id;
                _context.Products.Add(product);
                _context.SaveChanges();
            }
            
            return RedirectToAction("Product", "Product", new {title = product.Title});
        }
        
        [HttpGet]
        [Route("EditProduct/{id}")]
        public IActionResult Edit(int id)
        {
                return View("EditProduct", _context.Products.FirstOrDefault(x => x.Id == id));
        }
        
        [HttpPost]
        [Route("EditProduct/{id}")]
        public IActionResult Edit([Bind("Id, Name")] Product product)
        {
                _context.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();

            return RedirectToAction("Products");
        }
        
        [Route("DeleteProduct/{id}")]
        public IActionResult Delete(int id)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == id);

            if (product == null) return RedirectToAction("Products");

            _context.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _context.SaveChanges();

            return RedirectToAction("Products");
        }
    }
}