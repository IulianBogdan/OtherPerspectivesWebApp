using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OtherPerspectivesWebApp.Models;

namespace OtherPerspectivesWebApp.Controllers
{
    [Route("Home")]
    public class HomeController : Controller
    {
        public IActionResult Home()
        {
            return Ok();
        }
        
        [Route("About")]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return Ok();
        }
        
        [Route("Contact")]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return Ok();
        }
        
        public IActionResult Error()
        {
            return Ok();
        }
    }
}