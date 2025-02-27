using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using DKCommerceUI.Models;
using DKCommerceBussinesEntity;
using Libreria;
using MercurioUI.Models;



namespace DKCommerceUI.Controllers
{
    [Route("producto")]

    public class ProductoController : Controller
    {
        private readonly IMapper _mapper;// Se define una interfaz para realizar el mapeo

        public ProductoController()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });

            _mapper = config.CreateMapper();
        }
        public IActionResult Index()
        {
            return View();
        }


    }
}
