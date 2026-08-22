using Microsoft.AspNetCore.Mvc;

namespace TechStore.Controllers
{
    public class ContactoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
