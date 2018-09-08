using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using OtherPerspectivesWebApp.Models;

namespace OtherPerspectivesWebApp.Controllers
{
    [Route("Paintings")]
    public class PaintingController : Controller
    {
        private readonly OtherPerspectivesContext _context;

        public PaintingController(OtherPerspectivesContext context)
        {
            _context = context;
        }
        
        [Route("")]
        public IActionResult Index()
        {
           //do some work to display whatever we need for the index page regarding paintings.
            return Ok();
        }
        [Route("{id}")]
        public IActionResult Painting(int id)
        {
            var painting = _context.Paintings.FirstOrDefault(x => x.Id == id);
            return View(painting);
        }
        [Authorize]
        [HttpGet, Route("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost, Route("Create")]
        public IActionResult Create(Painting painting)
        {
            if (!ModelState.IsValid)
                return View();

            _context.Paintings.Add(painting);
            _context.SaveChanges();
            return Ok();
        }
        [Authorize]
        [HttpGet, Route("Edit")]
        public IActionResult Edit(int paintingId)
        {
            var painting = _context.Paintings.FirstOrDefault(x => x.Id == paintingId);
            return View(painting);
        }
        [Authorize]
        [HttpPost, Route("Edit")]
        public IActionResult Edit([FromBody] Painting painting)
        {
            //do work
            return View();
        }
        [Authorize]
        [HttpPost, Route("Delete")]
        public IActionResult Edit(int paintingId)
        {
            //do work
            return View();
        }
    }
}