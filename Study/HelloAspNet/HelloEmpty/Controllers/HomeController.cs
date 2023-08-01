using HelloEmpty.Models;
using Microsoft.AspNetCore.Mvc;

namespace HelloEmpty.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            HelloMessage msg = new HelloMessage()
            {
                Message = "Welcome to Asp.Net MVC !"
            };

            ViewBag.No = "Input message and click";

            return View(msg);
        }
        [HttpPost]
        public IActionResult Index(HelloMessage obj)
        {
            ViewBag.No = "Message Changed";
            return View(obj);
        }
    }
}
