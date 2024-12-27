using Microsoft.AspNetCore.Mvc;

namespace DKCommerceAPI.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
