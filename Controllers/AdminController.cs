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
        private readonly ApplicationDbContext _aspContext;

        //the framework handles this
        public AdminController(OtherPerspectivesContext context, ApplicationDbContext aspContext)
        {
            _context = context;
            _aspContext = aspContext;
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
        [Route("Admin/EditCategory/{id}")]
        public IActionResult EditCategory(int id)
        {
            using (var context = _context)
            {
                return View("EditCategory", context.Categories.First(x => x.Id == id));
            }
        }

        [HttpPost]
        [Route("Admin/EditCategory/{id}")]
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

        [Route("Admin/Orders")]
        public IActionResult Orders()
        {
            using (var context = _context)
            {
                var ordersList = context.Orders.ToList();

                return View("Orders", ordersList);
            }
        }

        [HttpGet]
        [Route("Admin/EditOrder/{id}")]
        public IActionResult EditOrder(int id)
        {
            using (var context = _context)
            {
                return View("EditOrder", context.Orders.First(x => x.Id == id));
            }
        }

        [HttpPost]
        [Route("Admin/EditOrder/{id}")]
        public IActionResult EditOrder([Bind("Quantity, Address")] Order order)
        {
            using (var context = _context)
            {
                context.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }

            return RedirectToAction("Orders");
        }

        [Route("Admin/DeleteOrder/{id}")]
        public IActionResult DeleteOrder(int id)
        {
            using (var context = _context)
            {
                var order = context.Orders.First(x => x.Id == id);

                context.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                context.SaveChanges();
            }

            return RedirectToAction("Orders");
        }

        [Route("Admin/Products")]
        public IActionResult Products()
        {
            using (var context = _context)
            {
                var productsList = context.Products.ToList();

                return View("Products", productsList);
            }
        }

        [HttpGet]
        [Route("Admin/EditProduct/{id}")]
        public IActionResult EditProduct(int id)
        {
            using (var context = _context)
            {
                return View("EditProduct", context.Products.First(x => x.Id == id));
            }
        }

        [HttpPost]
        [Route("Admin/EditProduct/{id}")]
        public IActionResult EditProduct([Bind("Price, Description, Title")] Product product)
        {
            using (var context = _context)
            {
                context.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }

            return RedirectToAction("Products");
        }

        [Route("Admin/DeleteProduct/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            using (var context = _context)
            {
                var product = context.Products.First(x => x.Id == id);

                context.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                context.SaveChanges();
            }

            return RedirectToAction("Products");
        }

        [Route("Admin/Users")]
        public IActionResult Users()
        {
            using (var context = _context)
            {
                var usersList = context.Users.ToList();

                return View("Users", usersList);
            }
        }

        [Route("Admin/DeleteUser/{id}")]
        public IActionResult DeleteUser(int id)
        {
            using (var context = _context)
            {
                var user = context.Users.First(x => x.Id == id);

                var aspUser = _aspContext.Users.First(x => x.Email == user.Email);

                _aspContext.Entry(aspUser).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _aspContext.SaveChanges();

                context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                context.SaveChanges();
            }

            return RedirectToAction("Users");
        }
    }
}
