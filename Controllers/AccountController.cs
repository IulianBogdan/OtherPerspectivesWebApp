using Microsoft.AspNetCore.Mvc;

namespace OtherPerspectivesWebApp.Controllers
{
    public class AccountController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return
            View();
        }
    }
}