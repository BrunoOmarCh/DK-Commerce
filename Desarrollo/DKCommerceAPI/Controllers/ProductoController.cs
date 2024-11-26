using Microsoft.AspNetCore.Mvc;

namespace DKCommerceAPI.Controllers
{
    public class ProductoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
