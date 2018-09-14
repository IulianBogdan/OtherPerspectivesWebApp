using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OtherPerspectivesWebApp.Models;

namespace OtherPerspectivesWebApp.Controllers
{
    public class HomeController : Controller
    {
            [Route("")]
            public IActionResult Index()
            {
                return View();
            }
    }
}