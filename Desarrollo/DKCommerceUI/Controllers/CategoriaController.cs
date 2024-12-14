using AutoMapper;
using MercurioUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DKCommerceUI.Controllers
{
    [Route("categoria")]
    public class CategoriaController : Controller
    {
        private IMapper _mapper;// IMapper: Es una interfaz, es decir, permite 'herededar' de una clase adicional

        public CategoriaController()
        {
            var config = new MapperConfiguration(
                x =>
                {
                    x.AddProfile(new MappingProfile());
                });
            _mapper = config.CreateMapper();
        }
        [HttpGet]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }

    }
}
