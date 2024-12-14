using Microsoft.AspNetCore.Mvc;

namespace DKCommerceUI.Controllers
{
    [Route("categoria")]
    public class CategoriaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
