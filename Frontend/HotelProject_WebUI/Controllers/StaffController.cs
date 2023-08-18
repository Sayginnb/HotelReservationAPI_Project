using Microsoft.AspNetCore.Mvc;

namespace HotelProject_WebUI.Controllers
{
    public class StaffController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
