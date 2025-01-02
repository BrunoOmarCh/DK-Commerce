using Microsoft.AspNetCore.Mvc;

namespace DKCommerceUI.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
